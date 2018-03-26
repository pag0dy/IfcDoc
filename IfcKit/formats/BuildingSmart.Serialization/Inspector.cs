// Name:        Inspector.cs
// Description: Base class for serializers
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2017 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;


namespace BuildingSmart.Serialization
{
    public abstract class Inspector
    {
        Type _projtype;
        Type _roottype;
        string _schema;
        string _release;
        string _application;
        Dictionary<string, Type> _typemap = new Dictionary<string, Type>();
        Dictionary<Type, IList<FieldInfo>> _fieldmap = new Dictionary<Type, IList<FieldInfo>>(); // cached field lists in declaration order
        Dictionary<Type, IList<FieldInfo>> _fieldinv = new Dictionary<Type, IList<FieldInfo>>(); // cached field lists for inverses
        Dictionary<Type, IList<FieldInfo>> _fieldall = new Dictionary<Type, IList<FieldInfo>>(); // combined
        Dictionary<FieldInfo, List<FieldInfo>> _inversemap = new Dictionary<FieldInfo, List<FieldInfo>>();

        /// <summary>
        /// Creates serializer accepting all types within assembly.
        /// </summary>
        /// <param name="typeProject">Type of the root object to load</param>
        public Inspector(Type typeProject)
            : this(typeProject, null, null, null, null)
        {
        }

        public Inspector(Type typeProject, Type[] loadtypes)
            : this(typeProject, loadtypes, null, null, null)
        {
        }

        /// <summary>
        /// Creates serializer accepting specific types.
        /// </summary>
        /// <param name="typeProject">Type of the root object to load</param>
        /// <param name="types">Other types that may be loaded, or null for all types within assembly of typeProject.</param>
        /// <param name="schema">Schema name to use, or null to determine from assembly of typeProject.</param>
        /// <param name="release">Release name to use, or null to determine from assembly of typeProject.</param>
        /// <param name="application">Application name to use, or null to determine from executing assembly.</param>
        public Inspector(Type typeProject, Type[] types, string schema, string release, string application)
        {
            this._projtype = typeProject;

            if (typeProject == null)
                return;

            if (types == null)
            {
                types = typeProject.Assembly.GetTypes();
            }

            AssemblyName aname = typeProject.Assembly.GetName();
            string[] assemblynameparts = aname.Name.Split('.');

            // determine the schema according to the last part of the assembly name
            // e.g. BuildingSmart.IFC4X1
            if (schema != null)
            {
                this._schema = schema;
            }
            else
            {
                this._schema = assemblynameparts[assemblynameparts.Length - 1];
            }

            if (release != null)
            {
                this._release = release;
            }
            else
            {
                this._release = "final"; // assume final release unless specified otherwise
                if (aname.Version != null)//attrVersion != null)
                {
                    int addendum = aname.Version.MajorRevision;
                    int corrigendum = aname.Version.MinorRevision;
                    {
                        StringBuilder specrelease = new StringBuilder();
                        if (addendum > 0)
                        {
                            specrelease.Append("Add");
                            specrelease.Append(addendum.ToString());

                            if (corrigendum > 0)
                            {
                                specrelease.Append("TC");
                                specrelease.Append(corrigendum.ToString());
                            }
                        }

                        if (specrelease.Length > 0)
                        {
                            this._release = specrelease.ToString();
                        }
                    }
                }
            }

            // determine the root class (IfcRoot) according to the root class of the passed in object (IfcProject)
            Type typeRoot = typeProject.BaseType;
            while (typeRoot.BaseType != typeof(object))
            {
                typeRoot = typeRoot.BaseType;
            }

            this._roottype = typeRoot;

            // cache types by name for deserialization
            foreach (Type t in types)
            {
                // map fields for quick loading of inverse fields
                FieldInfo[] fields = t.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (FieldInfo fTarget in fields)
                {
                    InversePropertyAttribute[] attrs = (InversePropertyAttribute[])fTarget.GetCustomAttributes(typeof(InversePropertyAttribute), false);
                    if (attrs.Length == 1)
                    {
                        Type typeElement;
                        if (fTarget.FieldType.IsGenericType)
                        {
                            // inverse set (most common)
                            typeElement = fTarget.FieldType.GetGenericArguments()[0];
                        }
                        else
                        {
                            // inverse scalar (more obscure)
                            typeElement = fTarget.FieldType;
                        }

                        FieldInfo fSource = this.GetFieldByName(typeElement, "_" + attrs[0].Property); // dictionary requires reference uniqueness
                        if (fSource != null)
                        {
                            List<FieldInfo> listField = null;
                            if (!_inversemap.TryGetValue(fSource, out listField))
                            {
                                listField = new List<FieldInfo>();
                                _inversemap.Add(fSource, listField);
                            }

                            listField.Add(fTarget);
                        }
                    }
                }

                if (t.IsPublic && !t.IsAbstract)
                {
                    string name = t.Name.ToUpper();
                    if (!_typemap.ContainsKey(name))
                    {
                        _typemap.Add(name, t);
                    }
                }
            }

            if (application != null)
            {
                this._application = application;
            }
            else
            {
                Assembly assm = Assembly.GetEntryAssembly();
                AssemblyTitleAttribute title = assm.GetCustomAttribute<AssemblyTitleAttribute>();
                if (title != null)
                {
                    this._application = title.Title + " " + assm.GetName().Version.ToString();
                }
                else
                {
                    this._application = assm.FullName.ToString();
                }
            }
        }

        /// <summary>
        /// Writes characters to indent line.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="indent">The number of levels to indent.</param>
        protected void WriteIndent(StreamWriter writer, int indent)
        {
            // current implementation uses tabs -- could be configurable to use spaces
            // tabs are used for efficient replacement when generating marked up example with hyperlinks

            for (int i = 0; i < indent; i++)
            {
                //writer.Write(" "); // previous setting
                writer.Write("\t");
            }
        }

        /// <summary>
        /// The schema identifier (e.g "IFC4")
        /// </summary>
        protected string Schema
        {
            get
            {
                return this._schema;
            }
        }

        /// <summary>
        /// The release identifier (e.g. "Add2TC1")
        /// </summary>
        protected string Release
        {
            get
            {
                return this._release;
            }
        }

        public string BaseURI
        {
            get
            {
                return "http://www.buildingsmart-tech.org/ifc/" + this.Schema + "/" + this.Release;
            }
        }

        protected string Application
        {
            get
            {
                return this._application;
            }
        }

        /// <summary>
        /// The project type (IfcProject)
        /// </summary>
        protected Type ProjectType
        {
            get
            {
                return this._projtype;
            }
        }

        /// <summary>
        /// The root type of indexable objects (IfcRoot)
        /// </summary>
        protected Type RootType
        {
            get
            {
                return this._roottype;
            }
        }

        /// <summary>
        /// Returns the collection type to be instantiated for the declared field type, 
        /// e.g. ISet<IfcObject> ==> HashSet<IfcObject>, IList<IfcObject> ==> List<IfcObject>
        /// </summary>
        /// <param name="typeDeclared"></param>
        /// <returns></returns>
        protected Type GetCollectionInstanceType(Type typeDeclared)
        {
            // use instantiable collection type
            Type typeCollection = typeDeclared;
            Type typeGeneric = typeDeclared.GetGenericTypeDefinition();
            Type typeElement = typeDeclared.GetGenericArguments()[0];
            if (typeGeneric == typeof(ISet<>))
            {
                typeCollection = typeof(HashSet<>).MakeGenericType(typeElement);
            }
            else if (typeGeneric == typeof(IList<>))
            {
                typeCollection = typeof(List<>).MakeGenericType(typeElement);
            }

            return typeCollection;
        }

        /// <summary>
        /// Finds type according to name as serialized.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected Type GetTypeByName(string name)
        {
            Type type = null;
            if (this._typemap.TryGetValue(name.ToUpper(), out type))
            {
                return type;
            }

            return null;
        }

        protected Type[] GetTypes()
        {
            return this._typemap.Values.ToArray<Type>();
        }

        /// <summary>
        /// Returns a declared field on an object.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        protected FieldInfo GetFieldByName(Type type, string name)
        {
            IList<FieldInfo> fields = this.GetFieldsOrdered(type);
            foreach (FieldInfo field in fields)
            {
                if (field != null && field.Name.Equals(name))
                    return field;
            }

            return null;
        }

        protected FieldInfo GetFieldInverse(FieldInfo field, Type t)
        {
            List<FieldInfo> listFields = null;

            if (this._inversemap.TryGetValue(field, out listFields))
            {
                foreach (FieldInfo fieldTarget in listFields)
                {
                    if (fieldTarget.DeclaringType.IsAssignableFrom(t))
                    {
                        return fieldTarget;
                    }
                }
            }
            return null;
        }

        protected IList<FieldInfo> GetFieldsAll(Type type)
        {
            IList<FieldInfo> fields = null;
            if (_fieldall.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildFieldList(type, fields, true, true);
            _fieldall.Add(type, fields);

            return fields;
        }

        /// <summary>
        /// Returns all fields on an entity type in order of persistence, including inherited types.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected IList<FieldInfo> GetFieldsOrdered(Type type)
        {
            IList<FieldInfo> fields = null;
            if (_fieldmap.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildFieldList(type, fields, true, false);
            _fieldmap.Add(type, fields);
            return fields;
        }


        /// <summary>
        /// Returns all inverse fields for object.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected IList<FieldInfo> GetFieldsInverseAll(Type type)
        {
            IList<FieldInfo> fields = null;
            if (_fieldinv.TryGetValue(type, out fields))
            {
                return fields;
            }

            fields = new List<FieldInfo>();
            BuildInverseListAll(type, fields);
            _fieldinv.Add(type, fields);

            return fields;
        }

        protected void BuildInverseListAll(Type type, IList<FieldInfo> list)
        {
            if (type.BaseType != typeof(object) && type.BaseType != typeof(Serializer))
            {
                BuildInverseListAll(type.BaseType, list);
            }

            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(InversePropertyAttribute), false))
                {
                    list.Add(field);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="list"></param>
        /// <param name="inherit"></param>
        /// <param name="inverse"></param>
        /// <param name="platform">Specific version, or UNSET to use default (latest)</param>
        private void BuildFieldList(Type type, IList<FieldInfo> list, bool inherit, bool inverse)
        {
            if (inherit && type.BaseType != typeof(object) && type.BaseType != typeof(Serializer))
            {
                BuildFieldList(type.BaseType, list, inherit, inverse);

                // zero-out any fields that are overridden as derived at subtype (e.g. IfcSIUnit.Dimensions)
                for (int iField = 0; iField < list.Count; iField++)
                {
                    FieldInfo field = list[iField];
                    if (field != null)
                    {
                        PropertyInfo prop = type.GetProperty(field.Name.Substring(1), BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
                        if (prop != null)
                        {
                            list[iField] = null; // hide derived fields
                        }
                    }
                }
            }

            FieldInfo[] fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            FieldInfo[] sorted = new FieldInfo[fields.Length];
            foreach (FieldInfo field in fields)
            {
                if (field.IsDefined(typeof(DataMemberAttribute), false))
                {
                    DataMemberAttribute attr = (DataMemberAttribute)field.GetCustomAttributes(typeof(DataMemberAttribute), false)[0];
                    sorted[attr.Order] = field;
                }
            }

            foreach (FieldInfo sort in sorted)
            {
                if (sort != null)
                {
                    list.Add(sort);
                }
            }

            // now inverse -- need particular order???
            if (inverse)
            {
                fields = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                foreach (FieldInfo field in fields)
                {
                    if (field.IsDefined(typeof(InversePropertyAttribute), false))
                    {
                        list.Add(field);
                    }
                }
            }
        }

        protected void UpdateInverse(object instance, FieldInfo field, object value)
        {
            if (value is string || value is Byte[] || value is ValueType)
                return;

            // set inverse link for singular references
            if (value is IEnumerable)
            {
                Type typeelem = field.FieldType.GetGenericArguments()[0];
                if (typeelem.IsInterface || typeelem.IsClass)
                {
                    // set reverse field
                    IEnumerable listSource = (IEnumerable)value;
                    foreach (object listItem in listSource)
                    {
                        if (listItem is object)
                        {
                            object itemSource = listItem;
                            FieldInfo fieldInverse = this.GetFieldInverse(field, itemSource.GetType());
                            if (fieldInverse != null && fieldInverse.FieldType.IsGenericType)
                            {
                                IEnumerable listTarget = (IEnumerable)fieldInverse.GetValue(itemSource);
                                if (listTarget == null)
                                {
                                    // must allocate list
                                    Type typeList = GetCollectionInstanceType(fieldInverse.FieldType);
                                    listTarget = (IEnumerable)Activator.CreateInstance(typeList);
                                    fieldInverse.SetValue(itemSource, listTarget);
                                }

                                // now add to inverse set -- perf: change this to use generated code for much better perfomance
                                MethodInfo methodAdd = listTarget.GetType().GetMethod("Add");
                                if (methodAdd != null)
                                {
                                    methodAdd.Invoke(listTarget, new object[] { instance });
                                }
                                //listTarget.Add(instance);
                            }
                        }
                    }
                }
            }
            else if (value != null)
            {
                FieldInfo fieldInverse = this.GetFieldInverse(field, value.GetType());
                if (fieldInverse != null)
                {
                    // set reverse field
                    if (typeof(IEnumerable).IsAssignableFrom(fieldInverse.FieldType))
                    {
                        IEnumerable list = (IEnumerable)fieldInverse.GetValue(value);
                        if (list == null)
                        {
                            // must allocate list
                            Type typeList = GetCollectionInstanceType(fieldInverse.FieldType);
                            list = (IEnumerable)Activator.CreateInstance(typeList);
                            fieldInverse.SetValue(value, list);
                        }

                        // now add to inverse set
                        //list.Add(instance);
                        MethodInfo methodAdd = list.GetType().GetMethod("Add");
                        if (methodAdd != null)
                        {
                            methodAdd.Invoke(list, new object[] { instance });
                        }

                    }
                    else
                    {
                        fieldInverse.SetValue(value, instance);
                    }
                }
            }
        }

    }
}
