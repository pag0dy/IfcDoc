// Name:        Compiler.cs
// Description: .NET Assembly Generator
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart International Ltd. and Georgia Tech by Constructivity.com LLC.
// Copyright:   (c) 2012-2014 BuildingSmart International Ltd., (c) 2014 Georgia Tech
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;

using IfcDoc.Schema;
using IfcDoc.Schema.DOC;

namespace IfcDoc
{
    public class Compiler
    {
        private DocProject m_project;
        private DocModelView[] m_views;
        private AssemblyBuilder m_assembly;
        private ModuleBuilder m_module;
        private Dictionary<string, DocObject> m_definitions;
        private Dictionary<string, Type> m_types;
        private Dictionary<string, string> m_namespaces;
        private Dictionary<Type, Dictionary<string, FieldInfo>> m_fields;
        private Dictionary<DocTemplateDefinition, MethodInfo> m_templates;

        public Compiler(DocProject project, DocModelView[] views)
        {
            this.m_project = project;
            this.m_views = views;

            this.m_assembly = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("IFC4"), AssemblyBuilderAccess.RunAndSave);
            this.m_module = this.m_assembly.DefineDynamicModule("IFC4.dll", "IFC4.dll");
            this.m_definitions = new Dictionary<string, DocObject>();
            this.m_types = new Dictionary<string, Type>();
            this.m_fields = new Dictionary<Type, Dictionary<string, FieldInfo>>();
            this.m_templates = new Dictionary<DocTemplateDefinition, MethodInfo>();
            this.m_namespaces = new Dictionary<string, string>();

            Dictionary<DocObject, bool> included = null;
            if (this.m_views != null)
            {
                included = new Dictionary<DocObject, bool>();
                foreach (DocModelView docView in this.m_views)
                {
                    this.m_project.RegisterObjectsInScope(docView, included);
                }
            }

            foreach (DocSection docSection in project.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        //if (included == null || included.ContainsKey(docEntity))
                        {
                            this.m_definitions.Add(docEntity.Name, docEntity);
                            this.m_namespaces.Add(docEntity.Name, docSchema.Name);
                        }
                    }

                    foreach (DocType docType in docSchema.Types)
                    {
                        //if (included == null || included.ContainsKey(docType))
                        {
                            this.m_definitions.Add(docType.Name, docType);
                            this.m_namespaces.Add(docType.Name, docSchema.Name);
                        }
                    }
                }
            }

            // first register types and fields
            foreach (string key in this.m_definitions.Keys)
            {
                RegisterType(key);
            }

            // now register template functions (may depend on fields existing)

            // find associated ConceptRoot for model view, define validation function
            if (this.m_views != null)
            {
                foreach (DocModelView view in this.m_views)
                {
                    string viewname = view.Code;
                    foreach (DocConceptRoot root in view.ConceptRoots)
                    {
                        Type tOpen= null;
                        
                        if (this.m_types.TryGetValue(root.ApplicableEntity.Name, out tOpen) && tOpen is TypeBuilder)
                        {
                            TypeBuilder tb = (TypeBuilder)tOpen;
                            foreach (DocTemplateUsage concept in root.Concepts)
                            {
                                // bool ConceptTemplateA([Parameter1, ...]);
                                // {
                                //    // for loading reference value:
                                //    .ldfld [AttributeRule]
                                //    .ldelem [Index] // for collection, get element by index
                                //    .castclass [EntityRule] for entity, cast to expected type; 
                                //    // for object graphs, repeat the above instructions to load value
                                //    
                                //    for loading constant:
                                //    .ldstr 'value'
                                //
                                //    for comparison functions:
                                //    .cge
                                //
                                //    for logical aggregations, repeat each item, pushing 2 elements on stack, then run comparison
                                //    .or
                                //
                                //    return the boolean value on the stack
                                //    .ret;
                                // }

                                // bool[] ConceptA()
                                // {
                                //    bool[] result = new bool[2];
                                // 
                                //    if parameters are specified, call for each template rule; otherwise call just once
                                //    result[0] = ConceptTemplateA([Parameter1, ...]); // TemplateRule#1
                                //    result[1] = ConceptTemplateA([Parameter1, ...]); // TemplateRule#2
                                // 
                                //    return result;
                                // }

                                // compile a method for the template definition, where parameters are passed to the template
                                if (concept.Definition != null)
                                {
                                    MethodInfo methodTemplate = this.RegisterTemplate(concept.Definition);

                                    // verify that definition is compatible with entity (user error)
                                    if (methodTemplate != null && methodTemplate.DeclaringType.IsAssignableFrom(tb))
                                    {
                                        string methodname = viewname + "_" + concept.Definition.Name.Replace(' ', '_').Replace(':', '_').Replace('-', '_');
                                        MethodBuilder method = tb.DefineMethod(methodname, MethodAttributes.Public, CallingConventions.HasThis, typeof(bool[]), null);
                                        ILGenerator generator = method.GetILGenerator();

                                        if (concept.Items != null && concept.Items.Count > 0)
                                        {
                                            // allocate array of booleans, store as local variable
                                            generator.DeclareLocal(typeof(bool[]));
                                            generator.Emit(OpCodes.Ldc_I4, concept.Items.Count);
                                            generator.Emit(OpCodes.Newarr, typeof(bool));
                                            generator.Emit(OpCodes.Stloc_0);

                                            DocModelRule[] parameters = concept.Definition.GetParameterRules();

                                            // call for each item with specific parameters
                                            for (int row = 0; row < concept.Items.Count; row++)
                                            {
                                                DocTemplateItem docItem = concept.Items[row];

                                                generator.Emit(OpCodes.Ldloc_0);   // push the array object onto the stack, for storage later
                                                generator.Emit(OpCodes.Ldc_I4, row); // push the array index onto the stack for storage later

                                                generator.Emit(OpCodes.Ldarg_0);   // push the *this* pointer for the IFC object instance

                                                // push parameters onto stack
                                                for (int col = 0; col < parameters.Length; col++)
                                                {
                                                    DocModelRule docParam = parameters[col];
                                                    string paramvalue = docItem.GetParameterValue(docParam.Identification);
                                                    if (paramvalue != null)
                                                    {
                                                        DocDefinition docParamType = concept.Definition.GetParameterType(docParam.Identification, this.m_definitions);
                                                        if (docParamType is DocDefined)
                                                        {
                                                            DocDefined docDefined = (DocDefined)docParamType;
                                                            switch (docDefined.DefinedType)
                                                            {
                                                                case "INTEGER":
                                                                    {
                                                                        Int64 ival = 0;
                                                                        Int64.TryParse(paramvalue, out ival);
                                                                        generator.Emit(OpCodes.Ldc_I8, ival);
                                                                        generator.Emit(OpCodes.Box);
                                                                    }
                                                                    break;

                                                                case "REAL":
                                                                    {
                                                                        Double dval = 0.0;
                                                                        Double.TryParse(paramvalue, out dval);
                                                                        generator.Emit(OpCodes.Ldc_R8, dval);
                                                                        generator.Emit(OpCodes.Box);
                                                                    }
                                                                    break;

                                                                case "STRING":
                                                                    generator.Emit(OpCodes.Ldstr, paramvalue);
                                                                    break;

                                                                default:
                                                                    generator.Emit(OpCodes.Ldstr, paramvalue);
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            // assume string
                                                            generator.Emit(OpCodes.Ldstr, paramvalue);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        generator.Emit(OpCodes.Ldnull);
                                                    }
                                                }

                                                generator.Emit(OpCodes.Call, methodTemplate); // call the validation function for the concept template
                                                generator.Emit(OpCodes.Stelem_I1); // store the result (bool) into an array slot 
                                            }

                                            // return the array of boolean results
                                            generator.Emit(OpCodes.Ldloc_0);
                                            generator.Emit(OpCodes.Ret);
                                        }
                                        else
                                        {
                                            // allocate array of booleans, store as local variable
                                            generator.DeclareLocal(typeof(bool[]));
                                            generator.Emit(OpCodes.Ldc_I4, 1);
                                            generator.Emit(OpCodes.Newarr, typeof(bool));
                                            generator.Emit(OpCodes.Stloc_0);

                                            generator.Emit(OpCodes.Ldloc_0);   // push the array object onto the stack, for storage later
                                            generator.Emit(OpCodes.Ldc_I4, 0); // push the array index onto the stack for storage later

                                            // call once
                                            generator.Emit(OpCodes.Ldarg_0);   // push the *this* pointer for the IFC object instance
                                            generator.Emit(OpCodes.Call, methodTemplate); // call the validation function for the concept template
                                            generator.Emit(OpCodes.Stelem_I1); // store the result (bool) into an array slot 

                                            // return the array of boolean results
                                            generator.Emit(OpCodes.Ldloc_0);
                                            generator.Emit(OpCodes.Ret);
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Debug.WriteLine("Incompatible template: " + tb.Name + " - " + concept.Definition.Name);
                                    }
                                }
                            }
                        }
                    }
                }
            }



            // seal types once all are built
            List<TypeBuilder> listBase = new List<TypeBuilder>();
            foreach (string key in this.m_definitions.Keys)
            {
                Type tOpen = this.m_types[key];
                while (tOpen is TypeBuilder)
                {
                    listBase.Add((TypeBuilder)tOpen);
                    tOpen = tOpen.BaseType;
                }

                // seal in base class order
                for (int i = listBase.Count - 1; i >= 0; i--)
                {
                    Type tClosed = listBase[i].CreateType();
                    this.m_types[tClosed.Name] = tClosed;
                }
                listBase.Clear();
            }
        }

        public AssemblyBuilder Assembly
        {
            get
            {
                return this.m_assembly;
            }
        }

        public ModuleBuilder Module
        {
            get
            {
                return this.m_module;
            }
        }

        public FieldInfo RegisterField(Type type, string field)
        {
            while (type != null && type != typeof(SEntity))
            {
                Dictionary<string, FieldInfo> map = this.m_fields[type];
                FieldInfo fieldinfo = null;
                if (map.TryGetValue(field, out fieldinfo))
                {
                    return fieldinfo;
                }

                type = type.BaseType;
            }

            return null;
        }

        /// <summary>
        /// Creates or returns emitted type, or NULL if no such type.
        /// </summary>
        /// <param name="map"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public Type RegisterType(string strtype)
        {
            // this implementation maps direct and inverse attributes to fields for brevity; a production implementation would use properties as well

            if (strtype == null)
                return typeof(SEntity);

            Type type = null;

            // resolve standard types
            switch (strtype)
            {
                case "INTEGER":
                    type = typeof(long);
                    break;

                case "REAL":
                case "NUMBER":
                    type = typeof(double);
                    break;

                case "BOOLEAN":
                case "LOGICAL":
                    type = typeof(bool);
                    break;

                case "STRING":
                    type = typeof(string);
                    break;

                case "BINARY":
                case "BINARY (32)":
                    type = typeof(byte[]);
                    break;
            }

            if (type != null)
                return type;

            // check for existing mapped type
            if (this.m_types.TryGetValue(strtype, out type))
            {
                return type;
            }

            // look up
            DocObject docType = null;
            if (!this.m_definitions.TryGetValue(strtype, out docType))
                return null;

            // not yet exist: create it
            TypeAttributes attr = TypeAttributes.Public;
            if (docType is DocEntity)
            {
                attr |= TypeAttributes.Class;

                DocEntity docEntity = (DocEntity)docType;
                if (docEntity.IsAbstract())
                {
                    attr |= TypeAttributes.Abstract;
                }

                Type typebase = RegisterType(docEntity.BaseDefinition);

                // calling base class may result in this class getting defined (IFC2x3 schema with IfcBuildingElement), so check again
                if (this.m_types.TryGetValue(strtype, out type))
                {
                    return type;
                }

                string schema = this.m_namespaces[docType.Name];
                TypeBuilder tb = this.m_module.DefineType(schema + "." + docType.Name, attr, typebase);

                // add typebuilder to map temporarily in case referenced by an attribute within same class or base class
                this.m_types.Add(strtype, tb);

                // interfaces implemented by type (SELECTS)
                foreach (DocDefinition docdef in this.m_definitions.Values)
                {
                    if (docdef is DocSelect)
                    {
                        DocSelect docsel = (DocSelect)docdef;
                        foreach (DocSelectItem dsi in docsel.Selects)
                        {
                            if (strtype.Equals(dsi.Name))
                            {
                                // register
                                Type typeinterface = this.RegisterType(docdef.Name);
                                tb.AddInterfaceImplementation(typeinterface);
                            }
                        }
                    }
                }

                Dictionary<string, FieldInfo> mapField = new Dictionary<string, FieldInfo>();
                this.m_fields.Add(tb, mapField);

                ConstructorInfo conMember = typeof(DataMemberAttribute).GetConstructor(new Type[] { typeof(int) });
                ConstructorInfo conLookup = typeof(DataLookupAttribute).GetConstructor(new Type[] { typeof(string) });
                int order = 0;
                foreach (DocAttribute docAttribute in docEntity.Attributes)
                {
                    // exclude derived attributes
                    if (String.IsNullOrEmpty(docAttribute.Derived))
                    {
                        Type typefield = RegisterType(docAttribute.DefinedType);
                        if (docAttribute.AggregationType != 0)
                        {
                            if (docAttribute.AggregationAttribute != null)
                            {
                                // nested collection, e.g. IfcCartesianPointList3D
                                typefield = typeof(List<>).MakeGenericType(new Type[] { typefield });
                            }

                            typefield = typeof(List<>).MakeGenericType(new Type[] { typefield });
                        }

                        //todo: optional field...

                        FieldBuilder fb = tb.DefineField(docAttribute.Name, typefield, FieldAttributes.Public); // public for now                    
                        mapField.Add(docAttribute.Name, fb);

                        if (String.IsNullOrEmpty(docAttribute.Inverse))
                        {
                            // direct attributes are fields marked for serialization
                            CustomAttributeBuilder cb = new CustomAttributeBuilder(conMember, new object[] { order });
                            fb.SetCustomAttribute(cb);
                            order++;
                        }
                        else
                        {
                            // inverse attributes are fields marked for lookup
                            CustomAttributeBuilder cb = new CustomAttributeBuilder(conLookup, new object[] { docAttribute.Inverse });
                            fb.SetCustomAttribute(cb);
                        }
                    }
                }


                // remove from typebuilder
                this.m_types.Remove(strtype);

                type = tb; // avoid circular conditions -- generate type afterwords
            }
            else if (docType is DocSelect)
            {
                attr |= TypeAttributes.Interface | TypeAttributes.Abstract;
                string schema = this.m_namespaces[docType.Name];
                TypeBuilder tb = this.m_module.DefineType(schema + "." + docType.Name, attr);

                // interfaces implemented by type (SELECTS)
                foreach (DocDefinition docdef in this.m_definitions.Values)
                {
                    if (docdef is DocSelect)
                    {
                        DocSelect docsel = (DocSelect)docdef;
                        foreach (DocSelectItem dsi in docsel.Selects)
                        {
                            if (strtype.Equals(dsi.Name))
                            {
                                // register
                                Type typeinterface = this.RegisterType(docdef.Name);
                                tb.AddInterfaceImplementation(typeinterface);
                            }
                        }
                    }
                }

                type = tb.CreateType();
            }
            else if (docType is DocEnumeration)
            {
                DocEnumeration docEnum = (DocEnumeration)docType;
                EnumBuilder eb = this.m_module.DefineEnum(docType.Name, TypeAttributes.Public, typeof(int));

                for (int i = 0; i < docEnum.Constants.Count; i++)
                {
                    DocConstant docConst = docEnum.Constants[i];
                    eb.DefineLiteral(docConst.Name, (int)i);
                }

                type = eb.CreateType();
            }
            else if (docType is DocDefined)
            {
                DocDefined docDef = (DocDefined)docType;

                attr |= TypeAttributes.Sealed;

                string schema = this.m_namespaces[docType.Name];
                TypeBuilder tb = this.m_module.DefineType(schema + "." + docType.Name, attr, typeof(ValueType));

                // interfaces implemented by type (SELECTS)
                foreach (DocDefinition docdef in this.m_definitions.Values)
                {
                    if (docdef is DocSelect)
                    {
                        DocSelect docsel = (DocSelect)docdef;
                        foreach (DocSelectItem dsi in docsel.Selects)
                        {
                            if (strtype.Equals(dsi.Name))
                            {
                                // register
                                Type typeinterface = RegisterType(docdef.Name);
                                tb.AddInterfaceImplementation(typeinterface);
                            }
                        }
                    }
                }

                Type typeliteral = RegisterType(docDef.DefinedType);

                if (docDef.Aggregation != null && docDef.Aggregation.AggregationType != 0)
                {
                    typeliteral = typeof(List<>).MakeGenericType(new Type[] { typeliteral });
                }
                else
                {
                    FieldInfo fieldval = typeliteral.GetField("Value");
                    while (fieldval != null)
                    {
                        typeliteral = fieldval.FieldType;
                        fieldval = typeliteral.GetField("Value");
                    }
                }

                FieldBuilder fieldValue = tb.DefineField("Value", typeliteral, FieldAttributes.Public);

                type = tb.CreateType();

                Dictionary<string, FieldInfo> mapField = new Dictionary<string, FieldInfo>();
                mapField.Add("Value", fieldValue);
                this.m_fields.Add(type, mapField);
            }

            this.m_types.Add(strtype, type);
            return type;
        }

        private MethodInfo RegisterTemplate(DocTemplateDefinition dtd)
        {
            if (dtd == null || dtd.Rules == null)
                return null;

            MethodInfo methodexist = null;
            if (this.m_templates.TryGetValue(dtd, out methodexist))
                return methodexist;

            Type[] paramtypes = null;
            DocModelRule[] parameters = dtd.GetParameterRules();
            if(parameters != null && parameters.Length > 0)
            {
                paramtypes = new Type[parameters.Length];
                for(int iParam = 0; iParam < parameters.Length; iParam++)
                {
                    DocModelRule param = parameters[iParam];
                    paramtypes[iParam] = RegisterType(param.Name);

                    if(paramtypes[iParam] == null)
                    {
                        paramtypes[iParam] = typeof(object); // fallback
                    }
                }
            }

            TypeBuilder tb = (System.Reflection.Emit.TypeBuilder)this.RegisterType(dtd.Type);
            if (tb == null)
                return null;
            
            string methodname = dtd.Name.Replace(' ', '_').Replace(':', '_').Replace('-', '_');
            MethodBuilder method = tb.DefineMethod(methodname, MethodAttributes.Public, CallingConventions.HasThis, typeof(bool), paramtypes);
            ILGenerator generator = method.GetILGenerator();
            foreach (DocModelRule docRule in dtd.Rules)
            {
                docRule.EmitInstructions(this, generator, dtd);
            }

            // if made it to the end, then successful, so return true
            generator.Emit(OpCodes.Ldc_I4_1);
            generator.Emit(OpCodes.Ret);

            return method;
        }
    }
}
