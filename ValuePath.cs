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
    }



}
