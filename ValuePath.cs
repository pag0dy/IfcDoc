// Name:        ValuePath.cs
// Description: Definitions for encapsulating IfcReference instances
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2013 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{

    /// <summary>
    /// Resolves attribute path expressions. 
    /// Used for importing or exporting data, constraining attributes, and approving attributes.
    /// </summary>
    public class CvtValuePath
    {
        DocDefinition m_type;
        DocAttribute m_property;
        string m_identifier; // identifier is specified
        bool m_vector; // query is for list, not single value
        CvtValuePath m_inner;

        /// <summary>
        /// Constructs a blank value path.
        /// </summary>
        public CvtValuePath()
        {
        }

        /// <summary>
        /// Constructs a value path with all parameters
        /// </summary>
        /// <param name="type"></param>
        /// <param name="property"></param>
        /// <param name="identifier"></param>
        /// <param name="inner"></param>
        public CvtValuePath(DocDefinition type, DocAttribute property, string identifier, CvtValuePath inner)
        {
            this.m_type = type;
            this.m_property = property;
            this.m_identifier = identifier;
            this.m_inner = inner;
        }

        internal static string GetParameterName(string syntax)
        {
            // quick check -- no escaping necessary as syntax is constrained
            if (syntax != null)
            {
                int iParamHead = syntax.IndexOf('@');
                if (iParamHead > 0)
                {
                    int iParamTail = syntax.IndexOf(']', iParamHead + 1);
                    if (iParamTail > iParamHead)
                    {
                        return syntax.Substring(iParamHead + 1, iParamTail - iParamHead - 1);
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Parses a value path from string in ISO-10303-11 (EXPRESS) format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CvtValuePath Parse(string value, Dictionary<string, DocObject> map)
        {
            if (value == null)
                return null;

            string[] tokens = value.Split(new char[] { '\\' }); //???// don't remove empty entries -- if it ends in backslash, then indicates type identifier

            CvtValuePath rootpath = null;
            CvtValuePath outerpath = null;
            foreach (string token in tokens)
            {
                CvtValuePath valuepath = new CvtValuePath();

                string[] parts = token.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 1 && map.ContainsKey(parts[0]))
                {
                    valuepath.Type = map[parts[0]] as DocDefinition;
                    if (valuepath.Type != null && parts.Length == 2)
                    {
                        string propname = parts[1];
                        int bracket = propname.IndexOf('[');
                        if (bracket >= 0)
                        {
                            string content = propname.Substring(bracket + 1, propname.Length - bracket - 2);
                            if (content.StartsWith("'") && content.EndsWith("'"))
                            {
                                // indexed by name                                
                                valuepath.Identifier = content.Substring(1, content.Length - 2);
                            }
                            else if (content.StartsWith("@"))
                            {
                                // indexed by parameter for each line, e.g. value identifies column by name when importing/exporting spreadsheet
                                valuepath.Identifier = content;
                            }
                            else if (content.Length == 0)
                            {
                                valuepath.Vector = true;
                            }

                            propname = propname.Substring(0, bracket);
                        }

                        if (valuepath.Type is DocEntity)
                        {
                            DocEntity docEntity = (DocEntity)valuepath.Type;
                            valuepath.Property = docEntity.ResolveAttribute(propname, map);
                        }
                    }

                }

                // chain
                if (outerpath != null)
                {
                    outerpath.InnerPath = valuepath;
                }
                else
                {
                    rootpath = valuepath;
                }

                outerpath = valuepath;
            }

            // avoid empty head link
            if (rootpath.Type == null && rootpath.Property == null && rootpath.InnerPath != null)
            {
                rootpath = rootpath.InnerPath;
            }

            return rootpath;
        }

        /// <summary>
        /// The type of object for which property applies, or NULL to indicate the type is defined by parameter.
        /// </summary>
        public DocDefinition Type
        {
            get
            {
                return this.m_type;
            }
            private set
            {
                this.m_type = value;
            }
        }

        /// <summary>
        /// The property to query, or NULL to indicate casting to specified type.
        /// </summary>
        public DocAttribute Property
        {
            get
            {
                return this.m_property;
            }
            private set
            {
                this.m_property = value;
            }
        }

        /// <summary>
        /// The identifier of an item within a collection by Name, or NULL to indicate any item in collection.
        /// </summary>
        public string Identifier
        {
            get
            {
                return this.m_identifier;
            }
            private set
            {
                this.m_identifier = value;
            }
        }

        /// <summary>
        /// True indicates query is for multiple items; False indicates single scalar item.
        /// </summary>
        public bool Vector
        {
            get
            {
                return this.m_vector;
            }
            private set
            {
                this.m_vector = value;
            }
        }

        /// <summary>
        /// The inner chain of path elements.
        /// </summary>
        public CvtValuePath InnerPath
        {
            get
            {
                return this.m_inner;
            }
            internal set
            {
                this.m_inner = value;
            }
        }

        /// <summary>
        /// Formats the value path into an expression.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.AppendString(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Internal function for building expression string
        /// </summary>
        /// <param name="sb"></param>
        private void AppendString(StringBuilder sb)
        {
            sb.Append("\\");

            if (this.m_type == null)
            {
                // represents type query, so just backslash
                return;
            }

            sb.Append(this.m_type.Name);
            if (this.m_property == null)
            {
                // represents type cast, so return
                return;
            }

            sb.Append(".");
            sb.Append(this.m_property.Name);

            if (this.m_property.GetAggregation() != DocAggregationEnum.NONE)
            {
                sb.Append("[");
                if (!this.m_vector)
                {
                    if (this.m_identifier != null)
                    {
                        if (this.m_identifier.StartsWith("@"))
                        {
                            sb.Append(this.m_identifier); // @ is a reserved character indicating parameter substitution
                        }
                        else
                        {
                            sb.Append("'");
                            sb.Append(this.m_identifier);
                            sb.Append("'");
                        }
                    }
                    else
                    {
                        sb.Append("*");
                    }
                }
                sb.Append("]");
            }

            if (this.m_inner != null)
            {
                this.m_inner.AppendString(sb);
            }
        }

        /// <summary>
        /// Gets value referenced by path.
        /// </summary>
        /// <param name="target">The relative object to retrieve the value.</param>
        /// <param name="parameters">Optional parameters for substitution.</param>
        /// <returns>The value on the object along the expression path.</returns>
        public object GetValue(SEntity target, Dictionary<string, SEntity> parameters)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            if (this.m_type == null)
            {
                return target.GetType();
            }

            if (!this.m_type.IsInstanceOfType(target))
                return null; // doesn't apply

            if (this.m_property == null)
            {
                return target; // for general case, if no attribute specified, then return object itself
                //return target.GetType(); // need some way to extract type directly such as for COBie
            }

            object value = null;

            if (this.m_property.PropertyType.IsGenericType &&
                typeof(System.Collections.IList).IsAssignableFrom(this.m_property.PropertyType) &&
                (typeof(SEntity).IsAssignableFrom(this.m_property.PropertyType.GetGenericArguments()[0]) || this.m_property.PropertyType.GetGenericArguments()[0].IsInterface))
            {
                System.Collections.IList list = (System.Collections.IList)this.m_property.GetValue(target, null);

                // if expecting array, then return it.
                //if (this.m_vector)
                if (this.m_vector || (this.m_identifier == null && this.m_inner == null)) // 2014-01-20: RICS export of door schedules to show quantity
                {
                    return list;
                }
                else if (this.m_identifier != null && this.m_identifier.StartsWith("@") && parameters == null)
                {
                    // return filtered list based on expected type -- may be none if no compatible types -- e.g. COBie properties only return IfcPropertyEnumeratedValue
                    if (this.InnerPath != null && this.InnerPath.Type != null)
                    {
                        List<SEntity> listFilter = null;
                        foreach (SEntity ent in list)
                        {
                            if (this.InnerPath.Type.IsInstanceOfType(ent))
                            {
                                if (listFilter == null)
                                {
                                    listFilter = new List<SEntity>();
                                }
                                listFilter.Add(ent);
                            }
                        }

                        return listFilter;
                    }
                    else
                    {
                        return list;
                    }
                }

                if (list != null)
                {
                    foreach (object eachelem in list)
                    {
                        // derived class may have its own specific property (e.g. IfcSIUnit, IfcConversionBasedUnit)
                        if (this.m_identifier != null)
                        {
                            Type eachtype = eachelem.GetType();
                            DefaultPropertyAttribute[] attrs = (DefaultPropertyAttribute[])eachtype.GetCustomAttributes(typeof(DefaultPropertyAttribute), true);
                            PropertyInfo propElem = null;
                            if (attrs.Length > 0)
                            {
                                propElem = eachtype.GetProperty(attrs[0].Name);
                            }
                            else
                            {
                                propElem = eachtype.GetProperty("Name");
                            }

                            if (propElem != null)
                            {
                                object eachname = propElem.GetValue(eachelem, null); // IStepValueString, or Enum (e.g. IfcNamedUnit.UnitType)

#if false
                                // special case for properties/quantities
                                if (eachname == null && eachelem is IfcRelDefinesByProperties)
                                {
                                    IfcRelDefinesByProperties rdp = (IfcRelDefinesByProperties)eachelem;
                                    eachname = rdp.RelatingPropertyDefinition.Name.GetValueOrDefault().Value;
                                }
#endif
                                if (eachname != null)
                                {
                                    if (this.m_identifier.StartsWith("@"))
                                    {
                                        // parameterized query -- substitute parameter
                                        if (parameters != null)
                                        {
                                            SEntity specelem = null;
                                            if (parameters.TryGetValue(this.m_identifier.Substring(1), out specelem))
                                            {
                                                if (this.m_inner != null)
                                                {
                                                    object eachvalue = this.m_inner.GetValue(specelem, parameters);
                                                    return eachvalue; // return no matter what, since specific element was requested.
                                                }
                                                else
                                                {
                                                    return specelem;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            return null; // no parameters specified, so can't resolve value.
                                        }
                                    }
                                    else if (this.m_identifier.Equals(eachname.ToString()))
                                    {
                                        if (this.m_inner != null)
                                        {
                                            // yes -- drill in
                                            object eachvalue = this.m_inner.GetValue((SEntity)eachelem, parameters);
                                            if (eachvalue != null)
                                            {
                                                return eachvalue; // if no value, keep going until compatible match is found
                                            }
                                        }
                                        else
                                        {
                                            return eachelem;
                                        }
                                    }
                                }
                            }
                        }
                        else if (this.m_inner != null)
                        {
                            object eachvalue = this.m_inner.GetValue((SEntity)eachelem, parameters);
                            if (eachvalue != null)
                            {
                                return eachvalue;
                            }
                        }
                        else
                        {
                            return eachelem;
                        }
                    }
                }
            }
            else if (this.m_inner != null)
            {
                value = this.m_property.GetValue(target, null);
                if (value is SEntity)
                {
                    value = this.m_inner.GetValue((SEntity)value, parameters);

                    if (this.m_identifier != null && value != null)
                    {
                        // qualify the value
                        Type eachtype = value.GetType();
                        DefaultMemberAttribute[] attrs = (DefaultMemberAttribute[])eachtype.GetCustomAttributes(typeof(DefaultMemberAttribute), true);
                        PropertyInfo propElem = null;
                        if (attrs.Length > 0)
                        {
                            propElem = eachtype.GetProperty(attrs[0].MemberName);
                        }
                        else
                        {
                            propElem = eachtype.GetProperty("Name");
                        }

                        if (propElem != null)
                        {
                            object name = propElem.GetValue(value, null);
                            if (name == null || !this.m_identifier.Equals(name.ToString()))
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            else
            {
                value = this.m_property.GetValue(target, null);
            }

            return value;
        }





    }



}
