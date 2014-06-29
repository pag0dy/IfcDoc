// Name:        SchemaDoc.cs
// Description: IFC documentation schema
// Author:      Tim Chipman
// Origination: Work performed for BuildingSmart by Constructivity.com LLC.
// Copyright:   (c) 2010 BuildingSmart International Ltd.
// License:     http://www.buildingsmart-tech.org/legal

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;

namespace IfcDoc.Schema.DOC
{
    public static class SchemaDOC
    {
        static Dictionary<string, Type> s_types;

        public static Dictionary<string, Type> Types
        {
            get
            {
                if (s_types == null)
                {
                    s_types = new Dictionary<string, Type>();

                    Type[] types = typeof(SchemaDOC).Assembly.GetTypes();
                    foreach (Type t in types)
                    {
                        if (typeof(SEntity).IsAssignableFrom(t) && !t.IsAbstract && t.Namespace.Equals("IfcDoc.Schema.DOC"))
                        {
                            string name = t.Name.ToUpper();
                            s_types.Add(name, t);
                        }
                    }
                }

                return s_types;
            }
        }
    }

    public interface IDocumentation
    {
        string Name
        {
            get;
            set;
        }

        string Documentation
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Localization of a definition for a particular language and region [an MVD-XML Definition]
    /// </summary>
    public class DocLocalization : SEntity,
        IDocumentation,
        IComparable
    {
        [DataMember(Order = 0)] private string _Locale; // language code, e.g. "en-US", "de-CH"
        [DataMember(Order = 1)] private DocCategoryEnum _Category;
        [DataMember(Order = 2)] private string _Name;
        [DataMember(Order = 3)] private string _Documentation;
        [DataMember(Order = 4)] private string _URL;

        public string Locale
        {
            get
            {
                return this._Locale;
            }
            set
            {
                this._Locale = value;
            }
        }

        public DocCategoryEnum Category
        {
            get
            {
                return this._Category;
            }
            set
            {
                this._Category = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public string Documentation
        {
            get
            {
                return this._Documentation;
            }
            set
            {
                this._Documentation = value;
            }
        }

        public string URL
        {
            get
            {
                return this._URL;
            }
            set
            {
                this._URL = value;
            }
        }

        public int CompareTo(object obj)
        {
            if (!(obj is DocLocalization))
                return -1;

            DocLocalization other = (DocLocalization)obj;
            return this.Locale.CompareTo(other.Locale);
        }
    }

    public enum DocCategoryEnum
    {
        Definition = 0,
        Agreement = 1,
        Diagram = 2,
        Instantiation = 3,
        Example = 4,
    }

    public enum DocXsdFormatEnum
    {
        Default = 0,
        Hidden = 1,    // for direct attribute, don't include as inverse is defined instead
        Attribute = 2, // represent as attribute
        Element = 3,   // represent as element
        Content = 4,   // represent as content
    }

    /// <summary>
    /// Abstract base class for any documentation item, having identifier, html documentation, and version history
    /// </summary>
    public abstract class DocObject : SEntity,
        IDocumentation,
        IComparable
    {
        [DataMember(Order = 0)] private string _Name; // the identifier (shows in tree)
        [DataMember(Order = 1)] private string _Documentation; // the documentation (synchronized with Visual Express)
        [DataMember(Order = 2)] private string _Uuid; // V1.8 inserted
        [DataMember(Order = 3)] private string _Code; // V1.8 inserted // e.g. 'bsi-100' 
        [DataMember(Order = 4)] private string _Version; // V1.8 inserted
        [DataMember(Order = 5)] private string _Status; // V1.8 inserted // e.g. 'draft'
        [DataMember(Order = 6)] private string _Author; // V1.8 inserted 
        [DataMember(Order = 7)] private string _Owner; // V1.8 inserted // e.g. 'buildingSMART international'
        [DataMember(Order = 8)] private string _Copyright; // V1.8 inserted
        [DataMember(Order = 9)] private List<DocLocalization> _Localization; // definitions

        // v1.8: inserted fields Code, Version, Status, Author, Owner, Copyright to support MVD-XML

        protected DocObject()
        {
            this._Uuid = Guid.NewGuid().ToString();
            this._Localization = new List<DocLocalization>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override void Delete()
        {
            if (this.Localization != null)
            {
                foreach (DocLocalization docLocal in this.Localization)
                {
                    docLocal.Delete();
                }
            }

            base.Delete();            
        }

        public DocLocalization GetLocalization(string locale)
        {
            DocLocalization docLocal = null;
            foreach (DocLocalization docEach in this.Localization)
            {
                if (docEach.Locale.Equals(locale, StringComparison.OrdinalIgnoreCase))
                {
                    docLocal = docEach;
                    break;
                }
            }

            return docLocal;
        }

        /// <summary>
        /// Creates or replaces a translation
        /// </summary>
        /// <param name="locale"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public DocLocalization RegisterLocalization(string locale, string name, string desc)
        {
            // find existing
            DocLocalization docLocal = null;
            foreach (DocLocalization docEach in this.Localization)
            {
                if (docEach.Locale.Equals(locale, StringComparison.OrdinalIgnoreCase))
                {
                    docLocal = docEach;
                    break;
                }
            }

            if (docLocal == null)
            {
                docLocal = new DocLocalization();
                docLocal.Locale = locale;
                this.Localization.Add(docLocal);
                this.Localization.Sort();
            }

            docLocal.Name = name;
            docLocal.Documentation = desc;
            
            return docLocal;
        }

        [
        Category("Identity"),
        ]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        [        
        Category("Publication"),
        ]
        public string Documentation
        {
            get
            {
                return this._Documentation;
            }
            set
            {
                this._Documentation = value;
            }
        }

        [
        Category("Publication"),
        ]
        public List<DocLocalization> Localization
        {
            get
            {
                return this._Localization;
            }
        }

        [Category("Misc")]
        public Guid Uuid
        {
            get
            {
                // don't generate guid from name, as it is often duplicated
                return SGuid.Parse(this._Uuid);
            }
            set
            {
                this._Uuid = new SGuid(value).ToString();
            }
        }

        [Category("Misc")]
        public string Code
        {
            get
            {
                return this._Code;
            }
            set
            {
                this._Code = value;
            }
        }

        [Category("Misc")]
        public string Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                this._Version = value;
            }
        }

        [Category("Misc")]
        public string Status
        {
            get
            {
                if (this._Status != null)
                {
                    return this._Status.TrimStart('_');
                }

                return null;
            }
            set
            {
                if (this._Status != null && this._Status.StartsWith("_"))
                {
                    this._Status = "_" + value;
                }
                else
                {
                    this._Status = value;
                }
            }
        }

        [Category("Misc")]
        public string Author
        {
            get
            {
                return this._Author;
            }
            set
            {
                this._Author = value;
            }
        }

        [Category("Misc")]
        public string Owner
        {
            get
            {
                return this._Owner;
            }
            set
            {
                this._Owner = value;
            }
        }

        [Category("Misc")]
        public string Copyright
        {
            get
            {
                return this._Copyright;
            }
            set
            {
                this._Copyright = value;
            }
        }


        public int CompareTo(object obj)
        {
            if (!(obj is DocObject))
                return -1;

            DocObject that = (DocObject)obj;
            if (this.Name == null)
                return -1;

            if (that.Name == null)
                return 1;

            return this.Name.CompareTo(that.Name);
        }
    }

    /// <summary>
    /// The single root of the documentation having sections in order of ISO documentation
    /// </summary>
    public class DocProject : SEntity
    {
        [DataMember(Order = 0)] public List<DocSection> Sections;
        [DataMember(Order = 1)] public List<DocAnnex> Annexes; // inserted in 1.2
        [DataMember(Order = 2)] public List<DocTemplateDefinition> Templates;
        [DataMember(Order = 3)] public List<DocModelView> ModelViews; // new in 2.7
        [DataMember(Order = 4)] public List<DocChangeSet> ChangeSets; // new in 2.7
        [DataMember(Order = 5)] public List<DocExample> Examples; // new in 4.2
        [DataMember(Order = 6)] public List<DocReference> NormativeReferences; // new in 4.3
        [DataMember(Order = 7)] public List<DocReference> InformativeReferences; // new in 4.3
        [DataMember(Order = 8)] public List<DocTerm> Terms; // new in 4.3
        [DataMember(Order = 9)] public List<DocAbbreviation> Abbreviations; // new in 4.3

        public DocProject()
        {
            this.Sections = new List<DocSection>();
            this.Annexes = new List<DocAnnex>();
            this.Templates = new List<DocTemplateDefinition>();
            this.ModelViews = new List<DocModelView>();
            this.ChangeSets = new List<DocChangeSet>();
            this.Examples = new List<DocExample>();
            this.NormativeReferences = new List<DocReference>();
            this.InformativeReferences = new List<DocReference>();
            this.Terms = new List<DocTerm>();
            this.Abbreviations = new List<DocAbbreviation>();
        }

        public DocTemplateDefinition GetTemplate(Guid guid)
        {
            foreach (DocTemplateDefinition docTemplate in this.Templates)
            {
                DocTemplateDefinition docEach = docTemplate.GetTemplate(guid);
                if (docEach != null)
                {
                    return docEach;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns an entity or type by name, or null if none
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public DocDefinition GetDefinition(string def)
        {
            if (def == null)
                return null;

            foreach (DocSection docSection in this.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocType docType in docSchema.Types)
                    {
                        if (docType.Name != null && docType.Name.Equals(def))
                            return docType;
                    }

                    foreach (DocEntity docType in docSchema.Entities)
                    {
                        if (docType.Name != null && docType.Name.Equals(def))
                            return docType;
                    }
                }
            }

            return null;
        }

        public DocPropertySet FindPropertySet(string def, out DocSchema schema)
        {
            foreach (DocSection docSection in this.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocPropertySet docType in docSchema.PropertySets)
                    {
                        if (docType.Name != null && docType.Name.Equals(def))
                        {
                            schema = docSchema;
                            return docType;
                        }
                    }
                }
            }

            schema = null;
            return null;
        }

        public DocQuantitySet FindQuantitySet(string def, out DocSchema schema)
        {
            foreach (DocSection docSection in this.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocQuantitySet docType in docSchema.QuantitySets)
                    {
                        if (docType.Name != null && docType.Name.Equals(def))
                        {
                            schema = docSchema;
                            return docType;
                        }
                    }
                }
            }

            schema = null;
            return null;
        }

        public DocSchema GetSchemaOfDefinition(DocDefinition def)
        {
            if (def is DocEntity)
            {
                DocEntity de = (DocEntity)def;
                foreach (DocSection docSection in this.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        if (docSchema.Entities.Contains(de))
                            return docSchema;
                    }
                }
            }
            else if(def is DocType)
            {
                DocType dt = (DocType)def;
                foreach (DocSection docSection in this.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        if (docSchema.Types.Contains(dt))
                            return docSchema;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns a flat list of all templates sorted by order in template hierarchy.
        /// Used for generating tables that preserve order of templates.
        /// </summary>
        /// <returns></returns>
        public List<DocTemplateDefinition> GetTemplateList()
        {
            List<DocTemplateDefinition> listTemplate = new List<DocTemplateDefinition>();
            BuildTemplateList(this.Templates, listTemplate);
            return listTemplate;
        }

        private static void BuildTemplateList(List<DocTemplateDefinition> source, List<DocTemplateDefinition> target)
        {
            foreach (DocTemplateDefinition docTemplate in source)
            {
                target.Add(docTemplate);
                BuildTemplateList(docTemplate.Templates, target);
            }
        }

        /// <summary>
        /// Returns a flat list of all entities sorted by order in schema hierarchy.
        /// Used for generating tables that preserve order of entities.
        /// </summary>
        /// <returns></returns>
        public List<DocEntity> GetEntityList()
        {
            List<DocEntity> listTemplate = new List<DocEntity>();
            foreach (DocSection docSection in this.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        listTemplate.Add(docEntity);
                    }
                }
            }
            return listTemplate;
        }

        public DocModelView GetView(Guid guid)
        {
            foreach (DocModelView docEach in this.ModelViews)
            {
                if (docEach.Uuid == guid)
                {
                    return docEach;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates or returns existing schema of specified name, within particular section
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DocSchema RegisterSchema(string name)
        {
            // map uppercase to mixed case (don't do in vex for now to preserve compatibility when merging)
            string[] schemas = new string[]
            {
                "IfcKernel", 
                "IfcControlExtension", 
                "IfcProcessExtension", 
                "IfcProductExtension",
                
                "IfcSharedBldgElements",
                "IfcSharedBldgServiceElements",
                "IfcSharedComponentElements",
                "IfcSharedFacilitiesElements",
                "IfcSharedMgmtElements",

                "IfcArchitectureDomain",
                "IfcBuildingControlsDomain",
                "IfcConstructionMgmtDomain",
                "IfcElectricalDomain",
                "IfcHvacDomain",
                "IfcPlumbingFireProtectionDomain",
                "IfcStructuralAnalysisDomain",
                "IfcStructuralElementsDomain",

                "IfcActorResource",
                "IfcApprovalResource",
                "IfcConstraintResource",
                "IfcCostResource",
                "IfcDateTimeResource",
                "IfcExternalReferenceResource",
                "IfcGeometricConstraintResource",
                "IfcGeometricModelResource",
                "IfcGeometryResource",
                "IfcMaterialResource",
                "IfcMeasureResource",
                "IfcPresentationAppearanceResource",
                "IfcPresentationDefinitionResource",
                "IfcPresentationOrganizationResource",
                "IfcPresentationResource",
                "IfcProfileResource",
                "IfcPropertyResource",
                "IfcQuantityResource",
                "IfcRepresentationResource",
                "IfcStructuralLoadResource",
                "IfcTopologyResource",
                "IfcUtilityResource",
            };

            // normalize name
            foreach (string s in schemas)
            {
                if (s.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    name = s;
                    break;
                }
            }

            // hard-coded categorization
            string sectionname;
            if (name.EndsWith("Resource", StringComparison.OrdinalIgnoreCase))
            {
                sectionname = "Resource definition data schemas";
            }
            else if (name.EndsWith("Domain", StringComparison.OrdinalIgnoreCase))
            {
                sectionname = "Domain specific data schemas";
            }
            else if (name.StartsWith("IfcShared", StringComparison.OrdinalIgnoreCase))
            {
                sectionname = "Shared element data schemas";
            }
            else
            {
                sectionname = "Core data schemas";
            }

            DocSchema docSchema = null;

            foreach (DocSection section in this.Sections)
            {
                if (sectionname.Equals(section.Name))
                {
                    // if there is an existing schema of same name, replace it
                    for (int i = section.Schemas.Count - 1; i >= 0; i--)
                    {
                        DocSchema existingschema = section.Schemas[i];
                        if (existingschema.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {                            
                            docSchema = existingschema;
                            break;
                        }
                    }

                    // create schema object if it doesn't already exist
                    if (docSchema == null)
                    {
                        docSchema = new DocSchema();
                        docSchema.Name = name;
                        section.Schemas.Add(docSchema);

                        // sort
                        DocSchema kernel = null;
                        SortedList<string, DocSchema> sortSchema = new SortedList<string, DocSchema>();
                        foreach (DocSchema s in section.Schemas)
                        {
                            if (s.Name.Equals("IfcKernel", StringComparison.OrdinalIgnoreCase))
                            {
                                kernel = s;
                            }
                            else
                            {
                                sortSchema.Add(s.Name, s);
                            }
                        }
                        section.Schemas.Clear();

                        // special case for kernel; always comes first
                        if (kernel != null)
                        {
                            section.Schemas.Add(kernel);
                        }

                        foreach (DocSchema s in sortSchema.Values)
                        {
                            section.Schemas.Add(s);
                        }
                    }

                    break;
                }
            }

            return docSchema;
        }

        private void RegisterEntity(Dictionary<DocObject, bool> included, DocEntity entity)
        {
            try
            {

                if (included.ContainsKey(entity))
                    return;

                included[entity] = true;

                if (entity.BaseDefinition != null)
                {
                    DocDefinition docBase = this.GetDefinition(entity.BaseDefinition);
                    if (docBase is DocEntity)
                    {
                        RegisterEntity(included, (DocEntity)docBase);
                    }
                }

                // traverse attributes
                foreach (DocAttribute docAttribute in entity.Attributes)
                {
                    DocDefinition docAttrType = this.GetDefinition(docAttribute.DefinedType);
                    if (!docAttribute.IsOptional() && docAttribute.Inverse == null) // new (4.0): only pull in mandatory attributes
                    {
                        included[docAttribute] = true;

                        if (docAttrType is DocEntity)
                        {
                            DocEntity docRefEntity = (DocEntity)docAttrType;
                            RegisterEntity(included, docRefEntity);
                        }
                        else if(docAttrType is DocType) // otherwise native EXPRESS type
                        {
                            included[docAttrType] = true;
                        }
                    }
                }
            }
            catch(Exception xx)
            {
                xx.ToString();
            }
        }

        private DocAttribute GetEntityAttribute(DocEntity entity, string attr)
        {
            foreach(DocAttribute docAttr in entity.Attributes)
            {
                if(docAttr.Name != null && docAttr.Name.Equals(attr))
                {
                    return docAttr;
                }
            }

            if(entity.BaseDefinition != null)
            {
                DocEntity docBase = this.GetDefinition(entity.BaseDefinition) as DocEntity;
                if(docBase != null)
                {
                    return GetEntityAttribute(docBase, attr);
                }
            }

            return null;
        }

        private void RegisterRule(Dictionary<DocObject, bool> included, DocEntity docEntity, DocModelRuleAttribute docRuleAttr, Dictionary<DocModelRuleAttribute, DocEntity> mapVirtualAttributes)
        {
            // cardinality of 0:0 indicates excluded
            if (docRuleAttr.CardinalityMin == -1 && docRuleAttr.CardinalityMax == -1)
            {
                // excluded
            }
            else
            {
                DocAttribute docAttr = GetEntityAttribute(docEntity, docRuleAttr.Name);
                if (docAttr != null)
                {
                    included[docAttr] = true;

                    // include inverse attribute if any
                    if (!String.IsNullOrEmpty(docAttr.Inverse))
                    {
                        DocEntity docEntInverse = GetDefinition(docAttr.DefinedType) as DocEntity;
                        if (docEntInverse != null)
                        {
                            DocAttribute docAttrInverse = GetEntityAttribute(docEntInverse, docAttr.Inverse);
                            if (docAttrInverse != null)
                            {
                                included[docAttrInverse] = true;
                            }
                        }
                    }

                    if (docRuleAttr.Rules != null)
                    {
                        foreach (DocModelRuleEntity docRuleEntity in docRuleAttr.Rules)
                        {
                            DocDefinition docInner = this.GetDefinition(docRuleEntity.Name);
                            if (docInner != null)
                            {
                                if (docInner is DocEntity)
                                {
                                    RegisterEntity(included, (DocEntity)docInner);
                                    if (docRuleEntity.Rules != null)
                                    {
                                        foreach (DocModelRule docRuleInner in docRuleEntity.Rules)
                                        {
                                            if (docRuleInner is DocModelRuleAttribute)
                                            {
                                                RegisterRule(included, (DocEntity)docInner, (DocModelRuleAttribute)docRuleInner, mapVirtualAttributes);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    included[docInner] = true;
                                }
                            }

                            foreach (DocTemplateDefinition docRef in docRuleEntity.References)
                            {
                                RegisterTemplate(included, docRef, mapVirtualAttributes);
                            }
                        }
                    }
                }
                else
                {
                    // may be defined on subtype, e.g. PredefinedType
                    mapVirtualAttributes.Add(docRuleAttr, docEntity);
                }
            }
        }

        private void RegisterTemplate(Dictionary<DocObject, bool> included, DocTemplateDefinition template, Dictionary<DocModelRuleAttribute, DocEntity> mapVirtualAttributes)
        {
            if(included.ContainsKey(template))
                return;
            
            included[template] = true;

            if (template.Rules != null)
            {
                DocEntity docEnt = this.GetDefinition(template.Type) as DocEntity;
                if (docEnt != null)
                {
                    RegisterEntity(included, docEnt);

                    foreach (DocModelRuleAttribute docRuleAttr in template.Rules)
                    {
                        RegisterRule(included, docEnt, docRuleAttr, mapVirtualAttributes);
                    }
                }
            }
        }

        private bool RegisterBaseTemplates(Dictionary<DocObject, bool> included, DocTemplateDefinition basetemplate)
        {
            //if (included.ContainsKey(basetemplate))
            //    return true;

            if (basetemplate.Templates != null)
            {
                foreach (DocTemplateDefinition docTemplate in basetemplate.Templates)
                {
                    bool check = RegisterBaseTemplates(included, docTemplate);
                    if(check)
                    {
                        included[basetemplate] = true;
                    }
                }
            }

            if (included.ContainsKey(basetemplate))
                return true;

            return false;
        }

        public void RegisterObjectsInScope(DocModelView docView, Dictionary<DocObject, bool> included)
        {
            if(!included.ContainsKey(docView))
            {
                included[docView] = true;
            }

            // special case -- if view references self, then include everything (no filtering)
            if(docView.BaseView != null && docView.BaseView.ToString() == docView.Uuid.ToString())
            {
                foreach (DocSection docSection in this.Sections)
                {
                    foreach(DocSchema docSchema in docSection.Schemas)
                    {
                        included[docSchema] = true;
                        foreach(DocType docType in docSchema.Types)
                        {
                            included[docType] = true;
                        }
                        foreach(DocEntity docEntity in docSchema.Entities)
                        {
                            included[docEntity] = true;
                            foreach(DocAttribute docAttr in docEntity.Attributes)
                            {
                                included[docAttr] = true;
                            }
                        }
                        foreach(DocFunction docFunc in docSchema.Functions)
                        {
                            included[docFunc] = true;
                        }
                        foreach(DocGlobalRule docRule in docSchema.GlobalRules)
                        {
                            included[docRule] = true;
                        }
                        foreach(DocPropertySet docProp in docSchema.PropertySets)
                        {
                            included[docProp] = true;
                        }
                        foreach(DocPropertyEnumeration docEnum in docSchema.PropertyEnums)
                        {
                            included[docEnum] = true;
                        }
                        foreach(DocQuantitySet docQuan in docSchema.QuantitySets)
                        {
                            included[docQuan] = true;
                        }
                    }
                }

            }

            if (this.Examples != null)
            {
                foreach (DocExample docExample in this.Examples)
                {
                    if (docExample.ModelView == docView)
                    {
                        included[docExample] = true;
                    }
                }
            }

            // track referenced attributes that apply to subtypes, e.g. PredefinedType
            Dictionary<DocModelRuleAttribute, DocEntity> mapVirtualAttributes = new Dictionary<DocModelRuleAttribute, DocEntity>();

            foreach (DocConceptRoot docRoot in docView.ConceptRoots)
            {
                RegisterEntity(included, docRoot.ApplicableEntity);

                foreach (DocTemplateUsage docUsage in docRoot.Concepts)
                {
                    if (docUsage.Definition != null)
                    {
                        RegisterTemplate(included, docUsage.Definition, mapVirtualAttributes);

                        // include types referenced at concepts
                        string[] parameters = docUsage.Definition.GetParameterNames();
                        foreach (DocTemplateItem docItem in docUsage.Items)
                        {
                            foreach (string param in parameters)
                            {
                                string val = docItem.GetParameterValue(param);
                                if (val != null && (val.StartsWith("Ifc") || val.StartsWith("Pset_") || val.StartsWith("Qto_"))) // perf shortcut
                                {
                                    DocDefinition docRef = this.GetDefinition(val);
                                    if (docRef is DocEntity)
                                    {
                                        RegisterEntity(included, (DocEntity)docRef);
                                    }
                                    else if (docRef != null)
                                    {
                                        included[docRef] = true;
                                    }
                                    else
                                    {
                                        DocSchema docSchemaRef = null;
                                        DocPropertySet docPset = FindPropertySet(val, out docSchemaRef);
                                        if(docPset != null)
                                        {
                                            included[docPset] = true;
                                        }
                                        else
                                        {
                                            DocQuantitySet docQset = FindQuantitySet(val, out docSchemaRef);
                                            if(docQset != null)
                                            {
                                                included[docQset] = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // now include any templates that have subtemplate included
            foreach (DocTemplateDefinition docTemplate in this.Templates)
            {
                RegisterBaseTemplates(included, docTemplate);
            }

            // now include any attributes on subtypes referenced by name (e.g. PredefinedType)
            foreach (DocModelRuleAttribute docVirtualRule in mapVirtualAttributes.Keys)
            {
                DocEntity docVirtualEntity = mapVirtualAttributes[docVirtualRule];

                foreach (DocSection docSection in this.Sections)
                {
                    foreach (DocSchema docSchema in docSection.Schemas)
                    {
                        foreach (DocEntity docEntity in docSchema.Entities)
                        {
                            if (included.ContainsKey(docEntity))
                            {
                                foreach(DocAttribute docAttr in docEntity.Attributes)
                                {
                                    if(docAttr.Name.Equals(docVirtualRule.Name))
                                    {
                                        // check if it inherits from entity (innermost check as it's expensive)
                                        bool inherits = false;
                                        DocEntity docSuper = docEntity;
                                        while (docSuper != null && !String.IsNullOrEmpty(docSuper.BaseDefinition))
                                        {
                                            docSuper = this.GetDefinition(docSuper.BaseDefinition) as DocEntity;
                                            if (docSuper == docVirtualEntity)
                                            {
                                                inherits = true;
                                                break;
                                            }
                                        }

                                        if (inherits)
                                        {
                                            included[docAttr] = true;

                                            DocDefinition docAttrType = this.GetDefinition(docAttr.DefinedType);
                                            if (docAttrType != null)
                                            {
                                                included[docAttrType] = true;
                                                if (docAttrType is DocEntity)
                                                {
                                                    RegisterEntity(included, (DocEntity)docAttrType);
                                                }
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // now include any schemas that have entities or types included
            foreach (DocSection docSection in this.Sections)
            {
                foreach (DocSchema docSchema in docSection.Schemas)
                {
                    foreach (DocEntity docEntity in docSchema.Entities)
                    {
                        if (included.ContainsKey(docEntity))
                        {
                            included[docSchema] = true;;
                            break;
                        }
                    }

                    foreach (DocType docType in docSchema.Types)
                    {
                        if (included.ContainsKey(docType))
                        {
                            included[docSchema] = true;;
                            break;
                        }
                    }

                    foreach (DocPropertySet docPset in docSchema.PropertySets)
                    {
                        if (included.ContainsKey(docPset))
                        {
                            included[docSchema] = true;

                            // include any types used for properties
                            foreach (DocProperty docProp in docPset.Properties)
                            {
                                string propclass = "IfcPropertySingleValue";
                                switch (docProp.PropertyType)
                                {
                                    case DocPropertyTemplateTypeEnum.P_SINGLEVALUE:
                                        propclass = "IfcPropertySingleValue";
                                        break;

                                    case DocPropertyTemplateTypeEnum.P_BOUNDEDVALUE:
                                        propclass = "IfcPropertyBoundedValue";
                                        break;

                                    case DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE:
                                        propclass = "IfcPropertyEnumeratedValue";
                                        break;

                                    case DocPropertyTemplateTypeEnum.P_LISTVALUE:
                                        propclass = "IfcPropertyListValue";
                                        break;

                                    case DocPropertyTemplateTypeEnum.P_TABLEVALUE:
                                        propclass = "IfcPropertyTableValue";
                                        break;

                                    case DocPropertyTemplateTypeEnum.P_REFERENCEVALUE:
                                        propclass = "IfcPropertyReferenceValue";
                                        break;
                                }
                                DocEntity docPropType = this.GetDefinition(propclass) as DocEntity;
                                if(docPropType != null)
                                {
                                    RegisterEntity(included, docPropType);
                                }

                                DocDefinition docPropData = this.GetDefinition(docProp.PrimaryDataType) as DocDefinition;
                                if (docPropData != null)
                                {
                                    if (docPropData is DocEntity)
                                    {
                                        RegisterEntity(included, (DocEntity)docPropData);
                                    }
                                    else
                                    {
                                        included[docPropData] = true;
                                    }
                                }

                                if (docProp.PropertyType == DocPropertyTemplateTypeEnum.P_ENUMERATEDVALUE)
                                {
                                    // get property enumeration
                                    string propenunmane = docProp.SecondaryDataType.Split(':')[0];

                                    foreach (DocSection docPropSection in this.Sections)
                                    {
                                        foreach (DocSchema docPropSchema in docPropSection.Schemas)
                                        {
                                            foreach (DocPropertyEnumeration docEnum in docPropSchema.PropertyEnums)
                                            {
                                                if (docEnum.Name.Equals(propenunmane))
                                                {
                                                    included[docEnum] = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (!String.IsNullOrEmpty(docProp.SecondaryDataType))
                                {
                                    DocDefinition docPropTime = this.GetDefinition(docProp.SecondaryDataType) as DocDefinition;
                                    if (docPropTime != null)
                                    {
                                        if (docPropTime is DocEntity)
                                        {
                                            RegisterEntity(included, (DocEntity)docPropTime);
                                        }
                                        else
                                        {
                                            included[docPropTime] = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (DocQuantitySet docQset in docSchema.QuantitySets)
                    {
                        if (included.ContainsKey(docQset))
                        {
                            included[docSchema] = true;

                            // include any types used for quantities
                            foreach (DocQuantity docProp in docQset.Quantities)
                            {
                                string propclass = "IfcQuantityCount";
                                switch (docProp.QuantityType)
                                {
                                    case DocQuantityTemplateTypeEnum.Q_AREA:
                                        propclass = "IfcQuantityArea";
                                        break;

                                    case DocQuantityTemplateTypeEnum.Q_COUNT:
                                        propclass = "IfcQuantityCount";
                                        break;

                                    case DocQuantityTemplateTypeEnum.Q_LENGTH:
                                        propclass = "IfcQuantityLength";
                                        break;

                                    case DocQuantityTemplateTypeEnum.Q_TIME:
                                        propclass = "IfcQuantityTime";
                                        break;

                                    case DocQuantityTemplateTypeEnum.Q_VOLUME:
                                        propclass = "IfcQuantityVolume";
                                        break;

                                    case DocQuantityTemplateTypeEnum.Q_WEIGHT:
                                        propclass = "IfcQuantityWeight";
                                        break;
                                }

                                DocEntity docPropType = this.GetDefinition(propclass) as DocEntity;
                                if (docPropType != null)
                                {
                                    RegisterEntity(included, docPropType);
                                }
                            }
                        }
                    }
                }
            }

            // for now, also include all functions and rules -- FUTURE: traverse expression to determine what is referenced
            foreach(DocSection docSection in this.Sections)
            {
                foreach(DocSchema docSchema in docSection.Schemas)
                {
                    if (included.ContainsKey(docSchema))
                    {
                        foreach (DocFunction docFunction in docSchema.Functions)
                        {
                            included[docFunction] = true;
                        }

                        foreach (DocGlobalRule docRule in docSchema.GlobalRules)
                        {
                            included[docRule] = true;
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// A definition of a template which provides boilerplate text for Use Definitions, and is applicable to a particular IFC entity and its descendents.
    /// </summary>
    public class DocTemplateDefinition : DocObject // now inherits from DocObject
    {
        [DataMember(Order = 0)] private string _Type; // applicable entity base type for which this template may be used, e.g. "IfcElement"
        [DataMember(Order = 1), Obsolete] internal string _Description; // text at top of section, e.g. "Materials are defined on the @Type using IfcRelAssociatesMaterial"
        [DataMember(Order = 2), Obsolete] private string _ContentListHead; // text at top of list, if items are present, e.g. "<ul>"
        [DataMember(Order = 3), Obsolete] private string _ContentListItem; // text for each item within list (repeated), e.g. "<li><b>@1</b>: @2</li>"
        [DataMember(Order = 4), Obsolete] private string _ContentListTail; // text at bottom of list, e.g. "</ul>"
        [DataMember(Order = 5), Obsolete] private string _FieldType1; // type of custom field #1, e.g. "IfcLabel"
        [DataMember(Order = 6), Obsolete] private string _FieldType2; // type of custom field #2, e.g. "IfcText"
        [DataMember(Order = 7), Obsolete] private string _FieldType3; // type of custom field #3, e.g. "IfcDistributionSystemTypeEnum"
        [DataMember(Order = 8), Obsolete] private string _FieldType4; // type of custom field #4, e.g. "IfcFlowDirectionEnum"        
        [DataMember(Order = 9)] public List<DocModelRule> Rules; //NEW IN 2.5
        [DataMember(Order = 10)] public List<DocTemplateDefinition> Templates; // NEW IN 2.7 sub-templates

        // Note: for file compatibility, above fields must remain

        public DocTemplateDefinition()
        {
            this.Rules = new List<DocModelRule>();
            this.Templates = new List<DocTemplateDefinition>();
        }

        [Description("IFC Identity Type for which this template applies to its descendents, e.g. 'IfcElement', unless overridden by another template having the same Name.")]
        [Category("General")]
        public string Type { get { return this._Type; } set { this._Type = value; } }

        public DocTemplateDefinition GetTemplate(Guid guid)
        {
            if (this.Uuid == guid)
                return this;

            if (this.Templates == null)
                return null;

            foreach (DocTemplateDefinition docTemplate in this.Templates)
            {
                DocTemplateDefinition docEach = docTemplate.GetTemplate(guid);
                if (docEach != null)
                {
                    return docEach;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns array of parameters available according to rules.
        /// Used to populate use definition tables.
        /// </summary>
        /// <returns></returns>
        public string[] GetParameterNames()
        {
            List<DocModelRule> list = new List<DocModelRule>();
            
            if (this.Rules != null)
            {
                foreach (DocModelRule rule in this.Rules)
                {
                    rule.BuildParameterList(list);
                }
            }

            string[] array = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                array[i] = list[i].Identification;
            }
            return array;
        }

        public DocModelRule[] GetParameterRules()
        {
            List<DocModelRule> list = new List<DocModelRule>();

            if (this.Rules != null)
            {
                foreach (DocModelRule rule in this.Rules)
                {
                    rule.BuildParameterList(list);
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Resolves a template parameter type
        /// </summary>
        /// <param name="docTemplate"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public DocDefinition GetParameterType(string parameter, Dictionary<string, DocObject> map)
        {
            DocObject docEnt = null;
            if (!map.TryGetValue(this.Type, out docEnt) || !(docEnt is DocEntity))
                return null;

            DocEntity docEntity = (DocEntity)docEnt;

            foreach (DocModelRule rule in this.Rules)
            {
                if (rule is DocModelRuleAttribute)
                {
                    DocDefinition docAttr = docEntity.ResolveParameterType((DocModelRuleAttribute)rule, parameter, map);
                    if (docAttr != null)
                    {
                        return docAttr;
                    }
                }
            }

            return null;
        }
        
        internal bool Includes(DocTemplateDefinition docTemplateDefinition)
        {
            if (this == docTemplateDefinition)
                return true;

            foreach (DocTemplateDefinition sub in this.Templates)
            {
                if (sub.Includes(docTemplateDefinition))
                    return true;
            }

            return false;
        }

        public override void Delete()
        {
            if (this.Templates != null)
            {
                foreach (DocTemplateDefinition docTemplate in this.Templates)
                {
                    docTemplate.Delete();
                }
            }

            if (this.Rules != null)
            {
                foreach (DocModelRule docRule in this.Rules)
                {
                    docRule.Delete();
                }
            }

            base.Delete();
        }

        public DocModelRule[] BuildRulePath(DocModelRule docRule)
        {
            List<DocModelRule> list = new List<DocModelRule>();

            foreach (DocModelRule docEach in this.Rules)
            {
                bool result = docEach.BuildRulePath(list, docRule);
                if (result)
                    break;
            }

            return list.ToArray();
        }

        /// <summary>
        /// Finds rule according to path delimited by backslash (as returned from a TreeView)
        /// </summary>
        /// <param name="rulepath"></param>
        /// <returns></returns>
        public DocModelRule[] GetRulePath(string rulepath)
        {
            string[] parts = rulepath.Split('\\'); // ignore first component which is the applicable entity

            DocModelRule[] objpath = new DocModelRule[parts.Length - 1];

            for (int i = 0; i < objpath.Length; i++)
            {
                List<DocModelRule> list;
                if (i == 0)
                {
                    list = this.Rules;
                }
                else
                {
                    list = objpath[i-1].Rules;
                }

                if (list == null)
                    return objpath;

                foreach (DocModelRule docModelRule in list)
                {
                    if (docModelRule.Name != null && docModelRule.Name.Equals(parts[i + 1]))
                    {
                        objpath[i] = docModelRule;
                        break;
                    }
                }

                if (objpath[i] == null)
                    break;
            }

            return objpath;
        }

        /// <summary>
        /// Finds rule and propagates it to all child items
        /// </summary>
        /// <param name="rulepath"></param>
        public void PropagateRule(string rulepath)
        {
            if (this.Templates == null)
                return;

            DocModelRule[] objpath = GetRulePath(rulepath);

            foreach (DocTemplateDefinition docTemplate in this.Templates)
            {
                DocModelRule[] childpath = docTemplate.GetRulePath(rulepath);

                for (int i = 0; i < objpath.Length; i++)
                {
                    if (childpath[i] == null && objpath[i] != null)
                    {
                        // must add rule
                        childpath[i] = (DocModelRule)objpath[i].Clone();
                        if (i > 0)
                        {
                            childpath[i - 1].Rules.Add(childpath[i]);
                        }
                        else
                        {
                            if (docTemplate.Rules == null)
                            {
                                docTemplate.Rules = new List<DocModelRule>();
                            }

                            docTemplate.Rules.Add(childpath[i]);
                        }
                    }
                    else if (objpath[i] == null && childpath[i] != null)
                    {
                        // must delete rule
                        if (i > 0)
                        {
                            childpath[i - 1].Rules.Remove(childpath[i]);
                        }
                        else
                        {
                            docTemplate.Rules.Remove(childpath[i]);
                        }
                        childpath[i].Delete();
                    }
                    else if(objpath[i] != null && childpath[i] != null)
                    {
                        // exists -- must update expression
                        childpath[i].CardinalityMin = objpath[i].CardinalityMin;
                        childpath[i].CardinalityMax = objpath[i].CardinalityMax;
                        childpath[i].Description = objpath[i].Description;
                        childpath[i].Identification = objpath[i].Identification;
                    }
                }

                // cascade downwards
                docTemplate.PropagateRule(rulepath);
            }
        }
    }

    // this is kept as single structure (rather than on ConceptRoot) such that all formatting info can be easily accessed in one place, and not comingle usage of concepts
    /// <summary>
    /// Indicates how attributes should be formatted for an XML schema, for a specific MVD
    /// </summary>
    public class DocXsdFormat : SEntity // new in 5.7
    {
        [DataMember(Order = 0)] public string Entity; // string to avoid referential dependencies
        [DataMember(Order = 1)] public string Attribute; // string to avoid referential dependencies
        [DataMember(Order = 2)] public DocXsdFormatEnum XsdFormat;  
        [DataMember(Order = 3)] public bool XsdTagless;
    }

    // custom field types may be IFC Types (defined types, enumerations) to indicate that a *value* should be specified of the particular type.
    // custom field types may be IFC Entities (e.g. IfcElement) to indicate that an entity *type* should be specified deriving from the particular type.    

    // new in IfcDoc 2.7
    public class DocModelView : DocObject
    {
        [DataMember(Order = 0)] List<DocExchangeDefinition> _Exchanges;
        [DataMember(Order = 1)] List<DocConceptRoot> _ConceptRoots; // new in 3.5
        [DataMember(Order = 2)] string _BaseView; // new in 3.9
        [DataMember(Order = 3)] string _XsdUri; // new in 5.4
        [DataMember(Order = 4)] List<DocXsdFormat> _XsdFormats; // new in 5.7

        private Dictionary<DocObject, bool> m_filtercache; // for performance, remember items within scope of model view; built on demand, cleared whenever there's a change that could impact

        public DocModelView()
        {
            this._Exchanges = new List<DocExchangeDefinition>();
            this._ConceptRoots = new List<DocConceptRoot>();
            this._XsdFormats = new List<DocXsdFormat>();
        }

        public List<DocExchangeDefinition> Exchanges
        {
            get
            {
                return this._Exchanges;
            }
        }

        public List<DocConceptRoot> ConceptRoots
        {
            get
            {
                return this._ConceptRoots;
            }
            set
            {
                this._ConceptRoots = value; // setter because added in V3.5; will be null if deserializing previous versions
            }
        }

        public string BaseView
        {
            get
            {
                return this._BaseView;
            }
            set
            {
                this._BaseView = value;
            }
        }

        public string XsdUri
        {
            get
            {
                return this._XsdUri;
            }
            set
            {
                this._XsdUri = value;
            }
        }

        public List<DocXsdFormat> XsdFormats
        {
            get
            {
                if (this._XsdFormats == null)
                {
                    this._XsdFormats = new List<DocXsdFormat>();
                }

                return this._XsdFormats;
            }
        }

        public DocConceptRoot GetConceptRoot(Guid guid)
        {            
            if (this.ConceptRoots != null)
            {
                foreach (DocConceptRoot docConcept in this.ConceptRoots)
                {
                    if (docConcept.Uuid == guid)
                    {
                        return docConcept;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns filter of objects within model view, caching as necessary
        /// </summary>
        /// <param name="project">The project to use, or null to clear cache for future rebuild</param>
        /// <returns>Dictionary of objects within scope, or null if cleared.</returns>
        public Dictionary<DocObject, bool> Filter(DocProject docProject)
        {
            if (docProject == null)
            {
                this.m_filtercache = null;
            }
            else if (this.m_filtercache == null)
            {
                this.m_filtercache = new Dictionary<DocObject, bool>();
                docProject.RegisterObjectsInScope(this, this.m_filtercache);
            }

            return this.m_filtercache;
        }

        public override void Delete()
        {
            if (this.Exchanges != null)
            {
                foreach (DocExchangeDefinition docLocal in this.Exchanges)
                {
                    docLocal.Delete();
                }
            }

            if(this.ConceptRoots != null)
            {
                foreach(DocConceptRoot docRoot in this.ConceptRoots)
                {
                    docRoot.Delete();
                }
            }

            base.Delete();
        }

    }

    // new in IfcDoc 3.5 -- organizes concepts according to MVD
    public class DocConceptRoot : DocObject
    {
        [DataMember(Order = 0)] DocEntity _ApplicableEntity;
        [DataMember(Order = 1)] List<DocTemplateUsage> _Concepts;

        public DocConceptRoot()
        {
            this._Concepts = new List<DocTemplateUsage>();
        }

        public DocEntity ApplicableEntity
        {
            get
            {
                return this._ApplicableEntity;
            }
            set
            {
                this._ApplicableEntity = value;
            }
        }

        public List<DocTemplateUsage> Concepts
        {
            get
            {                
                return this._Concepts;
            }
        }

        public override void Delete()
        {
            if (this.Concepts != null)
            {
                foreach (DocTemplateUsage docConcept in this.Concepts)
                {
                    docConcept.Delete();
                }
            }

            base.Delete();
        }

        public override string ToString()
        {
            if (this.ApplicableEntity != null)
            {
                return this.ApplicableEntity.Name;
            }

            return base.ToString();
        }
    }

    // new in IfcDoc 2.7
    public class DocExchangeDefinition : DocObject
    {
        [DataMember(Order = 0), Obsolete] internal string _Description; // added in IfcDoc 3.4, obsolete in IfcDoc 4.9 -- description for formatting purposes
        [DataMember(Order = 1)] public byte[] Icon; // embedded PNG file of 16x16 icon // added in IfcDoc 4.9
        [DataMember(Order = 2)] public DocExchangeApplicabilityEnum Applicability;            // added in IfcDoc 4.9
        [DataMember(Order = 3)] public string ExchangeClass; // added in IfcDoc 5.3
        [DataMember(Order = 4)] public string SenderClass; // added in IfcDoc 5.3
        [DataMember(Order = 5)] public string ReceiverClass; // added in IfcDoc 5.3
    }

    // new in IfcDoc 2.5
    public abstract class DocModelRule : SEntity,
        ICloneable// abstract in IfcDoc 2.7
    {
        [DataMember(Order = 0)] public string Name; // the attribute or entity name, case-sensitive
        [DataMember(Order = 1)] public string Description; // used as human description on template rules; otherwise holds special encodings
        [DataMember(Order = 2)] public string Identification; // the template parameter ID
        [DataMember(Order = 3)] public List<DocModelRule> Rules; // subrules
        //[DataMember(Order = 4)] public DocModelRuleTypeEnum Type; // deleted in IfcDoc 2.7        
        [DataMember(Order = 4)] public int CardinalityMin; // -1 means undefined // added in IfcDoc 3.3
        [DataMember(Order = 5)] public int CardinalityMax; // -1 means unbounded // added in IfcDoc 3.3

        public DocModelRule()
        {
            this.Rules = new List<DocModelRule>();
        }

        public override void Delete()
        {
            if (this.Rules != null)
            {
                foreach (DocModelRule docRule in this.Rules)
                {
                    docRule.Delete();
                }
            }

            base.Delete();
        }

        public bool IsCondition()
        {
            // special encoding to indicate rule represents a condition instead of a constraint.
            return (this.Description != null && this.Description.Equals("*"));
        }

        public virtual void BuildParameterList(IList<DocModelRule> list)
        {
            // base implementation recurses
            foreach (DocModelRule sub in this.Rules)
            {
                sub.BuildParameterList(list);
            }
        }

        public string GetCardinalityExpression()
        {
            if (this.CardinalityMin == 0 && this.CardinalityMax == 0)
                return null;

            if(this.CardinalityMin == -1 && this.CardinalityMax == -1)
                return " [0:0]";

            string min = "?";
            string max = "?";
            if (this.CardinalityMin >= 0)
            {
                min = this.CardinalityMin.ToString();
            }
            if (this.CardinalityMax >= 0)
            {
                max = this.CardinalityMax.ToString();
            }

            return " [" + min + ":" + max + "]";
        }

        public abstract bool? Validate(object target, DocTemplateItem docItem, Dictionary<string, Type> typemap, List<DocModelRule> trace);

        /// <summary>
        /// Makes deep copy of rule and all child rules
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            DocModelRule modelrule = (DocModelRule)Activator.CreateInstance(this.GetType()); // force constructor to get called to hook up events MemberwiseClone();
            modelrule.Name = this.Name;
            modelrule.Description = this.Description;
            modelrule.Identification = this.Identification;
            modelrule.CardinalityMin = this.CardinalityMin;
            modelrule.CardinalityMax = this.CardinalityMax;

            foreach (DocModelRule sub in this.Rules)
            {
                modelrule.Rules.Add((DocModelRule)sub.Clone());
            }

            return modelrule;
        }

        public bool BuildRulePath(List<DocModelRule> path, DocModelRule target)
        {
            path.Add(this);

            if (target == this)
                return true;

            if (this.Rules != null)
            {
                foreach (DocModelRule docSub in this.Rules)
                {
                    bool find = docSub.BuildRulePath(path, target);
                    if (find)
                        return true;
                }
            }

            path.Remove(this);

            return false;
        }

        internal virtual void EmitInstructions(
            Compiler context,
            ILGenerator generator,
            DocTemplateDefinition dtd)
        {
            if (this.Rules != null)
            {
                foreach (DocModelRule rule in this.Rules)
                {
                    rule.EmitInstructions(context, generator, dtd);
                }
            }
        }
    }

    public class DocModelRuleAttribute : DocModelRule
    {
        public override void BuildParameterList(IList<DocModelRule> list)
        {
            // add ourselves if marked as parameter
            if (!String.IsNullOrEmpty(this.Identification))
            {
                list.Add(this);
            }

            base.BuildParameterList(list);
        }

        /// <summary>
        /// Checks a value to see if it matches the parameter value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="docItem"></param>
        /// <param name="typemap"></param>
        /// <returns>True if passing, False if failing, Null if inapplicable.</returns>
        private bool? ValidateItem(object value, DocTemplateItem docItem, Dictionary<string, Type> typemap, List<DocModelRule> trace)
        {
            // (3) if parameter is defined, check for match
            if (!String.IsNullOrEmpty(this.Identification))
            {
                if (docItem == null)
                    return true; // parameter must be specified in order to check this rule

                string match = docItem.GetParameterValue(this.Identification);
                if (value == null && String.IsNullOrEmpty(match))
                {
                    return true;
                }
                else if (value is SEntity)
                {
                    if (match != null && value.GetType().Name.Equals(match))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (value != null)
                {
                    // pull out internal value type
                    FieldInfo fieldinfo = value.GetType().GetField("Value");
                    if (fieldinfo != null)
                    {
                        object innervalue = fieldinfo.GetValue(value);
                        if (innervalue == null)
                        {
                            return false;
                        }
                        else if (match != null && innervalue.ToString().Equals(match.ToString(), StringComparison.Ordinal))
                        {
                            return true;
                        }
                        else if (this.IsCondition())
                        {
                            // condition didn't match, so chain of rules does not apply -- return null.
                            return null;
                        }
                        else
                        {
                            // constraint evaluated to false and conditioned applied.
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // (4) recurse through constraints or entity rules
            if (this.Rules != null && this.Rules.Count > 0)
            {
                int tracelen = trace.Count;

                foreach (DocModelRule rule in this.Rules)
                {
                    while (trace.Count > tracelen)
                    {
                        trace.RemoveAt(tracelen);
                    }

                    // attribute rule is true if at least one entity filter matches or one constraint filter matches
                    bool? result = rule.Validate(value, docItem, typemap, trace);
                    if (result != null && result.Value)
                    {
                        return result;
                    }
                }

                // keep last failure path intact
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates an object to meet rule.
        /// </summary>
        /// <param name="target">Required instance to validate.</param>
        /// <param name="docItem">Optional template parameters to use for validation.</param>
        /// <param name="typemap">Map of types to resolve.</param>
        /// <returns></returns>
        public override bool? Validate(object target, DocTemplateItem docItem, Dictionary<string, Type> typemap, List<DocModelRule> trace)
        {
            trace.Add(this);

            if (target == null)
                return false; // todo: verify

            // (1) check if field is defined on target object; if not, then this rule does not apply.
            FieldInfo fieldinfo = target.GetType().GetField(this.Name);
            if (fieldinfo == null)
                return false;

            // (2) extract the value
            object value = fieldinfo.GetValue(target); // may be null

            if (value is System.Collections.IList)
            {
                System.Collections.IList list = (System.Collections.IList)value;
                int pass = 0;
                int fail = 0;

                int tracelen = trace.Count;

                foreach (object o in list)
                {
                    // reset
                    while(trace.Count > tracelen)
                    {
                        trace.RemoveAt(tracelen);
                    }

                    bool? result = ValidateItem(o, docItem, typemap, trace);                    
                    if (result != null)
                    {
                        if (result.Value)
                        {
                            pass++;
                        }
                        else
                        {

                            fail++;
                        }
                    }
                }

                bool? checkcard = null;
                if (this.CardinalityMin == 0 && this.CardinalityMax == 0) // uninitialized; same as schema
                {
                    checkcard = (fail == 0);
                }
                else if(this.CardinalityMin == -1 && this.CardinalityMax == -1)  // restricted (should not be present) (0:0)
                {
                    checkcard = (pass == 0);
                }
                else if (this.CardinalityMin == 0 && this.CardinalityMax == 1)
                {
                    checkcard = (pass == 0 || pass == 1);
                }
                else if (this.CardinalityMin == 1 && this.CardinalityMax == 1)
                {
                    checkcard = (pass == 1);
                }
                else if (this.CardinalityMin == 1)
                {
                    checkcard = (fail == 0);
                }
                else
                {
                    checkcard = true;
                }

                if (checkcard == null || checkcard.Value)
                {
                    while (trace.Count > tracelen)
                    {
                        trace.RemoveAt(tracelen);
                    }

                    trace.Remove(this);
                }
                return checkcard;
            }
            else
            {
                // validate single
                bool? checkitem = ValidateItem(value, docItem, typemap, trace);
                if(checkitem == null || checkitem.Value)
                {
                    trace.Remove(this);
                }

                return checkitem;
            }

        }
    }

    public class DocModelRuleEntity : DocModelRule
    {
        [DataMember(Order = 0)] private List<DocTemplateDefinition> _References; // IfcDoc 6.3: references to chained templates

        public override void BuildParameterList(IList<DocModelRule> list)
        {
            // new: allow specifying value parameter (only for base types though)

#if false //-- entity rules are only for referencing by rules, not for parameters
            // add ourselves if marked as parameter
            if (!String.IsNullOrEmpty(this.Identification))
            {
                list.Add(this);
            }
#endif

            base.BuildParameterList(list);
        }

        public List<DocTemplateDefinition> References
        {
            get
            {
                if(this._References == null)
                {
                    this._References = new List<DocTemplateDefinition>();
                }

                return this._References;
            }
        }

        /// <summary>
        /// Validates rules for an entity.
        /// </summary>
        /// <param name="target">Required object to validate.</param>
        /// <param name="docItem">Template item to validate.</param>
        /// <param name="typemap">Map of type names to type definitions.</param>
        /// <returns>True if passing, False if failing, or null if inapplicable.</returns>
        public override bool? Validate(object target, DocTemplateItem docItem, Dictionary<string, Type> typemap, List<DocModelRule> trace)
        {
            trace.Add(this);

            // checking for matching cast
            Type t = null;
            if (!typemap.TryGetValue(this.Name.ToUpper(), out t))
                return false;

            if (!t.IsInstanceOfType(target))
                return false;

            if (target is SEntity)
            {
                foreach (DocModelRule rule in this.Rules)
                {                    
                    bool? result = rule.Validate((SEntity)target, docItem, typemap, trace);

                    // entity rule is inapplicable if any attribute rules are inapplicable
                    if (result == null)
                    {
                        trace.Remove(this);
                        return null;
                    }

                    // entity rule fails if any attribute rules fail
                    if (!result.Value)
                        return false;
                }
            }

            trace.Remove(this);
            return true;
        }

    }

    public class DocModelRuleConstraint : DocModelRule
    {
        [DataMember(Order = 0)] public DocOpExpression Expression; // new in IfcDoc 6.1

        public override bool? Validate(object target, DocTemplateItem docItem, Dictionary<string, Type> typemap, List<DocModelRule> trace)
        {
            // constraint validation is now done in compiled code -- indicate pass to keep going
            return true;

#if false
            // description holds expression -- for now, only equality is supported; future: support comparison expressions
            if (target != null && target.ToString().Equals(this.Description))
                return true;            

            return false;
#endif
        }

        public override void Delete()
        {
            if(this.Expression != null)
            {
                this.Expression.Delete();
            }

            base.Delete();
        }

        internal override void EmitInstructions(
            Compiler context,
            ILGenerator generator, 
            DocTemplateDefinition dtd)
        {
            if (this.Expression != null)
            {
                this.Expression.Emit(context, generator, dtd, null);

                // if successful, keep going; if not, then return false
                generator.Emit(OpCodes.Brtrue_S, (byte)2);
                generator.Emit(OpCodes.Ldc_I4_0);
                generator.Emit(OpCodes.Ret);
            }
        }
    }    

    // Operators are a strict subset of .NET MSIL operators
    // MSIL is used to enable compilation to machine language for the fastest possible validation when dealing with huge files


    /// <summary>
    /// High-level construct of constraint to enable editing, parsing, and translation to common languages
    /// </summary>
    public abstract class DocOp : SEntity
    {
        [DataMember(Order = 0)] public DocOpCode Operation;

        /// <summary>
        /// Generates CIL code for operation
        /// </summary>
        /// <param name="writer"></param>
        internal virtual LocalBuilder Emit(
            Compiler context,
            ILGenerator generator, 
            DocTemplateDefinition dtd,
            Type valuetype)
        {
            return null;
        }

        public override string ToString()
        {
            return this.Operation.ToString().ToUpper();
        }

        public virtual string ToString(DocTemplateDefinition template)
        {
            return this.ToString();
        }
    }

    public abstract class DocOpExpression : DocOp
    {
    }

    /// <summary>
    /// Compares a variable to a value
    /// </summary>
    public class DocOpStatement : DocOpExpression // ceq|cle|clt|cge|cgt|cne
    {
        [DataMember(Order = 0)] private DocOpReference _Reference;  // statement
        [DataMember(Order = 1)] private DocOpValue _Value; // statement or constant
        [DataMember(Order = 2)] private DocOpCode _Metric; // qualifier for additional operation on reference

        public DocOpReference Reference
        {
            get
            {
                return this._Reference;
            }
            set
            {
                if(this._Reference != null)
                {
                    this._Reference.Delete();
                }

                this._Reference = value;
            }
        }

        public DocOpValue Value
        {
            get
            {
                return this._Value;
            }
            set 
            { 
                if (this._Value != null)
                {
                    this._Value.Delete();
                }

                this._Value = value;
            }
        }

        public DocOpCode Metric
        {
            get
            {
                return this._Metric;
            }
            set
            {
                this._Metric = value;
            }
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public override string ToString(DocTemplateDefinition dtd)
        {
            string opname = "=";
            switch(this.Operation)
            {
                case DocOpCode.CompareEqual:
                    opname = "=";
                    break;

                case DocOpCode.CompareNotEqual:
                    opname = "<>";
                    break;

                case DocOpCode.CompareLessThanOrEqual:
                    opname = "<=";
                    break;

                case DocOpCode.CompareLessThan:
                    opname = "<";
                    break;

                case DocOpCode.CompareGreaterThanOrEqual:
                    opname = ">=";
                    break;

                case DocOpCode.CompareGreaterThan:
                    opname = ">";
                    break;

                case DocOpCode.IsIncluded:
                    opname = "{";
                    break;
            }

            if (this.Reference != null && this.Value != null)
            {
                string metrichead = "";
                string metrictail = "";
                string suffix = " " + opname + " " + this.Value.ToString(dtd);
                switch (this.Metric)
                {
                    case DocOpCode.LoadLength:
                        metrichead = "SIZEOF(";
                        metrictail = ")";
                        break;

                    case DocOpCode.IsInstance:
                        metrichead = "TYPEOF(";
                        metrictail = ")";
                        break;

                    case DocOpCode.IsUnique:
                        metrichead = "UNIQUE(";
                        metrictail = ")";
                        suffix = "";
                        break;
                }
                return metrichead + this.Reference.ToString(dtd) + metrictail + suffix;
            }

            return null;
        }

        public override void Delete()
        {
            if(this.Reference != null)
            {
                this.Reference.Delete();
            }

            if(this.Value != null)
            {
                this.Value.Delete();
            }

            base.Delete();
        }

        internal override LocalBuilder Emit(Compiler context, ILGenerator generator, DocTemplateDefinition dtd, Type valuetype)
        {
            if(this.Reference.EntityRule == null)
            {
                System.Diagnostics.Debug.WriteLine("Invalid statement reference: " + dtd.Name);
                generator.Emit(OpCodes.Ldc_I4_0); // return false;
                return null;
            }
            
            Type typeCompare = context.RegisterType(this.Reference.EntityRule.Name);

            // apply additional operation on reference according to metric
            switch(this.Metric)
            {
                case DocOpCode.NoOperation:
                    {
                        // push the referenced value onto the stack
                        LocalBuilder local = this.Reference.Emit(context, generator, dtd, null);

                        // cast to IComparable if required
                        if (this.Operation == DocOpCode.CompareGreaterThan ||
                            this.Operation == DocOpCode.CompareGreaterThanOrEqual ||
                            this.Operation == DocOpCode.CompareLessThan ||
                            this.Operation == DocOpCode.CompareLessThanOrEqual)
                        {
                            generator.Emit(OpCodes.Castclass, typeof(IComparable));
                        }

                        // push the value to be compared onto the stack
                        if (typeCompare.IsEnum && this.Value is DocOpLiteral)
                        {
                            generator.Emit(OpCodes.Ldtoken, typeCompare);

                            MethodInfo methodTypeFromHandle = typeof(Type).GetMethod("GetTypeFromHandle");
                            generator.Emit(OpCodes.Call, methodTypeFromHandle);

                            FieldInfo fieldEnum = null;
                            string litval = ((DocOpLiteral)this.Value).Value;
                            if (litval != null)
                            {
                                fieldEnum = typeCompare.GetField(litval, BindingFlags.Static | BindingFlags.Public);
                            }

                            if (fieldEnum != null)
                            {
                                int fieldVal = (int)fieldEnum.GetValue(null);
                                generator.Emit(OpCodes.Ldc_I4, fieldVal);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("Invalid enumeration: " + litval + " - " + dtd.Name);
                                generator.Emit(OpCodes.Ldc_I4_0);
                            }

                            // convert it to object
                            MethodInfo methodToObject = typeof(Enum).GetMethod("ToObject", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(Type), typeof(Int32) }, null);
                            generator.Emit(OpCodes.Call, methodToObject);
                        }
                        else
                        {
                            // string
                            this.Value.Emit(context, generator, dtd, typeCompare);
                        }
                    }
                    break;

                case DocOpCode.LoadLength:
                    {
                        // push the referenced value onto the stack
                        LocalBuilder local = this.Reference.Emit(context, generator, dtd, null);

                        generator.Emit(OpCodes.Ldlen);

                        // push the value to be compared onto the stack
                        this.Value.Emit(context, generator, dtd, null);
                    }
                    break;

                case DocOpCode.IsInstance:
                    if (this.Value is DocOpLiteral)
                    {
                        // push the referenced value onto the stack
                        LocalBuilder local = this.Reference.Emit(context, generator, dtd, null);

                        Type typeInstance = context.RegisterType(((DocOpLiteral)this.Value).Value);
                        generator.Emit(OpCodes.Isinst, typeInstance);
                    }
                    return null;

                case DocOpCode.IsUnique: // unique
                    {
                        // create a type with static field to track uniqueness for the particular rule
                        TypeBuilder tb = context.Module.DefineType("_Unique" + this.OID); // give it a unique name based on OID corresponding to rule
                        FieldBuilder fb = tb.DefineField("Hash", typeof(Hashtable), FieldAttributes.Static | FieldAttributes.Public);
                        ConstructorBuilder cb = tb.DefineTypeInitializer();
                        ILGenerator il = cb.GetILGenerator();
                        ConstructorInfo constructorHashtable = typeof(Hashtable).GetConstructor(new Type[]{});
                        il.Emit(OpCodes.Newobj, constructorHashtable);
                        il.Emit(OpCodes.Stsfld, fb);
                        il.Emit(OpCodes.Ret);

                        Type t = tb.CreateType();
                        FieldInfo f = t.GetFields()[0];

                        // track value in local varaible
                        LocalBuilder local = generator.DeclareLocal(typeof(string));

                        // store the referenced value
                        this.Reference.Emit(context, generator, dtd, null);
                        generator.Emit(OpCodes.Stloc, (short)local.LocalIndex);

                        // if null, then not a duplicate, jump to end
                        generator.Emit(OpCodes.Ldloc, (short)local.LocalIndex);
                        generator.Emit(OpCodes.Ldnull);
                        generator.Emit(OpCodes.Beq_S, (byte)34);

                        // check if hash table for rule already contains value
                        MethodInfo methodContainsKey = typeof(Hashtable).GetMethod("ContainsKey");
                        generator.Emit(OpCodes.Ldsfld, f);
                        generator.Emit(OpCodes.Ldloc, (short)local.LocalIndex);
                        generator.Emit(OpCodes.Callvirt, methodContainsKey);

                        // if true, then not unique
                        generator.Emit(OpCodes.Brtrue_S, (byte)18); // skip over to last instruction 

                        // add to hash table
                        MethodInfo methodAdd = typeof(Hashtable).GetMethod("Add");
                        generator.Emit(OpCodes.Ldsfld, f); // 5
                        generator.Emit(OpCodes.Ldloc, (short)local.LocalIndex); // 3
                        generator.Emit(OpCodes.Dup); // 1
                        generator.Emit(OpCodes.Callvirt, methodAdd); // 5

                        // not a duplicate (yet) -- first duplicate instance will push True
                        generator.Emit(OpCodes.Ldc_I4_1); // 1
                        generator.Emit(OpCodes.Br_S, (byte)1); // 2 - skip over

                        // is a duplicate, so not unique: return false
                        generator.Emit(OpCodes.Ldc_I4_0);

                        return null;
                    }
            }

            switch (this.Operation)
            {
                case DocOpCode.IsIncluded:
                    {
                        MethodInfo methodSplit = typeof(String).GetMethod("Split", new Type[] { typeof(Char[])});

                        // Stack: V|S

                        generator.Emit(OpCodes.Ldc_I4_1);             // V|S|I 
                        generator.Emit(OpCodes.Newarr, typeof(Char)); // V|S|A
                        generator.Emit(OpCodes.Dup);                  // V|S|A|A
                        generator.Emit(OpCodes.Ldc_I4_0);             // V|S|A|A|I
                        generator.Emit(OpCodes.Ldc_I4_S, (Byte)',');  // V|S|A|A|I|B
                        generator.Emit(OpCodes.Stelem_I2);            // V|S|A
                        generator.Emit(OpCodes.Call, methodSplit);    // V|A

                        MethodInfo methodCompare = typeof(Object).GetMethod("Equals", new Type[] { typeof(Object), typeof(Object) });

                        // Left argument:  String
                        // Right argument: Array of String: MUST have at least one element

                        LocalBuilder localValue = generator.DeclareLocal(typeof(object));
                        LocalBuilder localArray = generator.DeclareLocal(typeof(string[]));
                        LocalBuilder localIndex = generator.DeclareLocal(typeof(int));
                        LocalBuilder localCheck = generator.DeclareLocal(typeof(bool)); // false until included

                        // save values
                        generator.Emit(OpCodes.Stloc, (short)localArray.LocalIndex);
                        generator.Emit(OpCodes.Stloc, (short)localValue.LocalIndex);

                        // LOOP STARTS HERE

                        // load the array element and compare
                        generator.Emit(OpCodes.Ldloc, (short)localValue.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldloc, (short)localArray.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldloc, (short)localIndex.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldelem_Ref); // 1
                        generator.Emit(OpCodes.Call, methodCompare); // 5

                        // store True if equal (0)
                        generator.Emit(OpCodes.Brtrue_S, (byte)5); // 2
                        generator.Emit(OpCodes.Ldc_I4_1); // 1
                        generator.Emit(OpCodes.Stloc, (short)localCheck.LocalIndex); // 3

                        // increase the position
                        generator.Emit(OpCodes.Ldloc, (short)localIndex.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldc_I4_1); // 1
                        generator.Emit(OpCodes.Add); // 1
                        generator.Emit(OpCodes.Stloc, (short)localIndex.LocalIndex); // 3

                        // go to start of loop 
                        generator.Emit(OpCodes.Ldloc, (short)localIndex.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldloc, (short)localArray.LocalIndex); // 3
                        generator.Emit(OpCodes.Ldlen); // 1
                        generator.Emit(OpCodes.Blt_S, (sbyte)-46);

                        // return the flag
                        generator.Emit(OpCodes.Ldloc, (short)localCheck.LocalIndex);
                    }
                    break;

                case DocOpCode.NoOperation: // backcompat
                case DocOpCode.CompareEqual:
                    {
                        // strings may not necessarily be interned, so can't use comparison opcode -- must call Object.Compare (which checks for null conditions, calls virtual Compare specific to string)
                        MethodInfo methodCompare = typeof(Object).GetMethod("Equals", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(Object), typeof(Object) }, null);
                        generator.Emit(OpCodes.Call, methodCompare);
                    }
                    break;

                case DocOpCode.CompareNotEqual:
                    {
                        MethodInfo methodCompare = typeof(Object).GetMethod("Equals", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(Object), typeof(Object) }, null);
                        generator.Emit(OpCodes.Call, methodCompare); // 0 means they are equal, so non-zero means not equal
                        generator.Emit(OpCodes.Not); // 0 means they are equal, so flip result
                    }
                    break;

                case DocOpCode.CompareGreaterThan:
                    {
                        MethodInfo methodCompare = typeof(IComparable).GetMethod("CompareTo", new Type[] { typeof(Object) });
                        generator.Emit(OpCodes.Castclass, typeof(IComparable));
                        generator.Emit(OpCodes.Callvirt, methodCompare);
                        generator.Emit(OpCodes.Ldc_I4_0);
                        generator.Emit(OpCodes.Cgt);
                    }
                    break;

                case DocOpCode.CompareLessThan:
                    {
                        MethodInfo methodCompare = typeof(IComparable).GetMethod("CompareTo", new Type[] { typeof(Object) });
                        generator.Emit(OpCodes.Castclass, typeof(IComparable));
                        generator.Emit(OpCodes.Callvirt, methodCompare);
                        generator.Emit(OpCodes.Ldc_I4_0);
                        generator.Emit(OpCodes.Clt);
                    }
                    break;

                case DocOpCode.CompareGreaterThanOrEqual:
                    {
                        MethodInfo methodCompare = typeof(IComparable).GetMethod("CompareTo", new Type[] { typeof(Object) });
                        generator.Emit(OpCodes.Castclass, typeof(IComparable));
                        generator.Emit(OpCodes.Callvirt, methodCompare);
                        generator.Emit(OpCodes.Ldc_I4_0);
                    }
                    generator.Emit(OpCodes.Bge_S, (byte)3);
                    generator.Emit(OpCodes.Ldc_I4_0);
                    generator.Emit(OpCodes.Br_S, (byte)1);
                    generator.Emit(OpCodes.Ldc_I4_1);
                    break;

                case DocOpCode.CompareLessThanOrEqual:
                    {
                        MethodInfo methodCompare = typeof(IComparable).GetMethod("CompareTo", new Type[] { typeof(Object) });
                        generator.Emit(OpCodes.Castclass, typeof(IComparable));
                        generator.Emit(OpCodes.Callvirt, methodCompare);
                        generator.Emit(OpCodes.Ldc_I4_0);
                    }
                    generator.Emit(OpCodes.Ble_S, (byte)3);
                    generator.Emit(OpCodes.Ldc_I4_0);
                    generator.Emit(OpCodes.Br_S, (byte)1);
                    generator.Emit(OpCodes.Ldc_I4_1);
                    break;
            }

            return null;
        }
    }

    public class DocOpLogical : DocOpExpression // and|or|xor
    {
        [DataMember(Order = 0)] private DocOpExpression _ExpressionA;
        [DataMember(Order = 1)] private DocOpExpression _ExpressionB;

        public DocOpExpression ExpressionA
        {
            get
            {
                return this._ExpressionA;
            }
            set
            {
                this._ExpressionA = value;
            }
        }

        public DocOpExpression ExpressionB
        {
            get
            {
                return this._ExpressionB;
            }
            set
            {
                this._ExpressionB = value;
            }
        }

        public override void Delete()
        {
            if(this.ExpressionA != null)
            {
                this.ExpressionA.Delete();
            }

            if(this.ExpressionB != null)
            {
                this.ExpressionB.Delete();
            }

            base.Delete();
        }

        /// <summary>
        /// Generates CIL code for operation
        /// </summary>
        /// <param name="writer"></param>
        internal override LocalBuilder Emit(
            Compiler context,
            ILGenerator generator,
            DocTemplateDefinition dtd,
            Type valuetype)
        {
            this.ExpressionA.Emit(context, generator, dtd, null);
            this.ExpressionB.Emit(context, generator, dtd, null);

            switch (this.Operation)
            {
                case DocOpCode.And:
                    generator.Emit(OpCodes.And);
                    break;

                case DocOpCode.Or:
                    generator.Emit(OpCodes.Or);
                    break;

                case DocOpCode.Xor:
                    generator.Emit(OpCodes.Xor);
                    break;

            }

            return null;
        }

    }

    /// <summary>
    /// A value which is either a literal or a variable
    /// </summary>
    public abstract class DocOpValue : DocOp 
    {
    }

    /// <summary>
    /// A parameter passed to the template
    /// </summary>
    public class DocOpParameter : DocOpValue // ldarg
    {
        [DataMember(Order = 0)] public DocModelRuleAttribute AttributeRule;

        public override string ToString()
        {
            return "#" + this.AttributeRule.Identification;
        }

        internal override LocalBuilder Emit(Compiler context, ILGenerator generator, DocTemplateDefinition dtd, Type valuetype)
        {
            // determine the index of the parameter
            DocModelRule[] rules = dtd.GetParameterRules();
            for(int i = 0; i < rules.Length; i++)
            {
                if(rules[i] == this.AttributeRule)
                {
                    // found it
                    switch(i)
                    {
                        case 0:
                            generator.Emit(OpCodes.Ldarg_1);
                            break;

                        case 1:
                            generator.Emit(OpCodes.Ldarg_2);
                            break;

                        case 2:
                            generator.Emit(OpCodes.Ldarg_3);
                            break;

                        default:
                            if (i < 254)
                            {
                                generator.Emit(OpCodes.Ldarg_S, (byte)(i+1));
                            }
                            else
                            {
                                generator.Emit(OpCodes.Ldarg, i+1);
                            }
                            break;
                    }
                    return null;
                }
            }

            generator.Emit(OpCodes.Ldnull); // should never get here
            return null;
        }
    }

    /// <summary>
    /// A variable -- currently limited to a field on an object (no local variables or arguments currently)
    /// </summary>
    public class DocOpReference : DocOpValue // ldfld|ldlen
    {
        [DataMember(Order = 0)] public DocModelRuleEntity EntityRule;

        internal override LocalBuilder Emit(
            Compiler compiler,
            ILGenerator generator, 
            DocTemplateDefinition template,
            Type valuetype)
        {
            // ldarg.0 (this)
            // ldfld + token (calculated from attribute reference) -- recursively until final attribute
            // {leelem} -- for specific indices 

            Type type = compiler.RegisterType(template.Type);
            generator.Emit(OpCodes.Ldarg_0); // this

            Label labelBail = generator.DefineLabel();

            DocModelRule[] rulepath = template.BuildRulePath(this.EntityRule);
            foreach(DocModelRule rule in rulepath)
            {
                if (rule is DocModelRuleAttribute)
                {
                    FieldInfo field = compiler.RegisterField(type, rule.Name);
                    if (field == null)
                    {
                        // bail
                        this.ToString();
                        return null;
                    }
                    generator.Emit(OpCodes.Castclass, type);

                    if (field.FieldType.IsValueType && field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        MethodInfo methodHasValue = field.FieldType.GetMethod("get_HasValue");
                        MethodInfo methodGetValue = field.FieldType.GetMethod("get_Value");

                        generator.Emit(OpCodes.Dup); // 2

                        generator.Emit(OpCodes.Ldflda, field); // field address
                        generator.Emit(OpCodes.Call, methodHasValue);
                        generator.Emit(OpCodes.Brfalse, labelBail);

                        generator.Emit(OpCodes.Ldflda, field); // field address
                        generator.Emit(OpCodes.Call, methodGetValue);
                    }
                    else
                    {
                        generator.Emit(OpCodes.Ldfld, field); // field
                        if (!field.FieldType.IsValueType)
                        {
                            generator.Emit(OpCodes.Dup);
                            generator.Emit(OpCodes.Brfalse, labelBail);
                        }


                        // if field is collection, then get last element
                        if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == typeof(List<>))
                        {
                            // iterate
                            LocalBuilder localList = generator.DeclareLocal(field.FieldType);
                            LocalBuilder localElem = generator.DeclareLocal(field.FieldType.GetGenericArguments()[0]);
                            generator.Emit(OpCodes.Stloc, (short)localList.LocalIndex);

                            // get the length of the list -- go in reverse order to avoid having to check or store length each iteration
                            MethodInfo methodListLength = typeof(ICollection).GetProperty("Count").GetGetMethod();
                            generator.Emit(OpCodes.Ldloc, (short)localList.LocalIndex);
                            generator.Emit(OpCodes.Callvirt, methodListLength);

                            // if 0 length, then return
                            Label labelAfter = generator.DefineLabel();
                            generator.Emit(OpCodes.Brtrue, labelAfter); // if length != 0 then keep going
                            generator.Emit(OpCodes.Ldnull); // push null onto stack
                            generator.Emit(OpCodes.Br, labelBail); // skip any more indirections
                            generator.MarkLabel(labelAfter);

                            // get the first element of the collection -- FUTURE: allow index to be specified
                            generator.Emit(OpCodes.Ldloc, (short)localList.LocalIndex);
                            generator.Emit(OpCodes.Ldc_I4_0); // first element

                            // get the element
                            MethodInfo methodListGet = ((PropertyInfo)typeof(IList).GetDefaultMembers()[0]).GetGetMethod();
                            generator.Emit(OpCodes.Callvirt, methodListGet);
                            if (localElem.LocalType.IsValueType)
                            {
                                // e.g. IfcCartesianPoint.Coordinates[1] : IfcLengthMeasure
                                generator.Emit(OpCodes.Unbox, localElem.LocalType);
                                generator.Emit(OpCodes.Ldobj, localElem.LocalType);//Ldind_R8); // assume 64-bit floating point (float) .. TBD: check for integer
                            }
                            else
                            {
                                generator.Emit(OpCodes.Castclass, localElem.LocalType);
                            }
                            generator.Emit(OpCodes.Stloc, (short)localElem.LocalIndex);

                            // then load the element again
                            generator.Emit(OpCodes.Ldloc, (short)localElem.LocalIndex);
                        }
                    }
                }
                else if (rule is DocModelRuleEntity)
                {
                    type = compiler.RegisterType(rule.Name);

                    if (type.IsEnum)
                    {
                        // box it
                        generator.Emit(OpCodes.Box, type); // needed for Object.Compare
                    }
                    else if (type.IsValueType)
                    {
                        // duplicate it to retain object on stack after instance check (otherwise null)
                        //generator.Emit(OpCodes.Dup);
                        //generator.Emit(OpCodes.Brfalse, labelBail);

                        FieldInfo fieldValue = compiler.RegisterField(type, "Value");
                        generator.Emit(OpCodes.Ldfld, fieldValue);
                        generator.Emit(OpCodes.Box, fieldValue.FieldType); // needed for Object.Compare
                    }
                    else
                    {
                        // check if instance of expected type
                        generator.Emit(OpCodes.Isinst, type); // object -> object (if instance) or null if not

                        // duplicate it to retain object on stack after instance check (otherwise null)
                        generator.Emit(OpCodes.Dup);
                        generator.Emit(OpCodes.Brfalse, labelBail);

                        // otherwise, stack contains object at this point
                    }
                }
            }

            generator.MarkLabel(labelBail); // stack should have exactly one element here -- either the resolved value or NULL if any attribute/entity didn't resolve along the way

            return null;
        }

        public override string ToString(DocTemplateDefinition template)
        {
            if (template == null)
                return this.ToString();

            DocModelRule[] rulepath = template.BuildRulePath(this.EntityRule);
            StringBuilder sb = new StringBuilder();
            sb.Append(template.Type);
            foreach(DocModelRule rule in rulepath)
            {
                if (rule is DocModelRuleAttribute)
                {
                    sb.Append(".");
                }
                else if (rule is DocModelRuleEntity)
                {
                    sb.Append("\\");
                }
                sb.Append(rule.Name);
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            if (this.EntityRule != null)
            {
                return this.EntityRule.ToString();//... convert to path...
            }
            else
            {
                return "Value";
            }
        }
    }

    public class DocOpLiteral : DocOpValue // ldstr|ldc.i8|ldc.r8
    {
        [DataMember(Order = 0)] public string Value;

        internal override LocalBuilder Emit(
            Compiler compiler,
            ILGenerator generator, 
            DocTemplateDefinition dtd,
            Type valuetype)
        {
            // + constant or string metadata token

            if (valuetype != null && valuetype.IsValueType && valuetype.GetFields()[0].FieldType == typeof(double))
            {
                Double literal = 0.0;
                Double.TryParse(this.Value, out literal);
                generator.Emit(OpCodes.Ldc_R8, literal);
                generator.Emit(OpCodes.Box, typeof(Double)); // needed for Object.Compare
            }
            else if (valuetype != null && valuetype.IsValueType && valuetype.GetFields()[0].FieldType == typeof(long))
            {
                Int64 literal = 0L;
                Int64.TryParse(this.Value, out literal);
                generator.Emit(OpCodes.Ldc_I8, literal);
                generator.Emit(OpCodes.Box, typeof(Int64)); // needed for Object.Compare
            }
            else if (valuetype != null && valuetype.IsValueType && valuetype.GetFields()[0].FieldType == typeof(bool))
            {
                Boolean literal = false;
                Boolean.TryParse(this.Value, out literal);
                generator.Emit(OpCodes.Ldc_I4, literal? 1 : 0);
                generator.Emit(OpCodes.Box, typeof(Boolean)); // needed for Object.Compare
            }
            else if (this.Value != null)
            {
                generator.Emit(OpCodes.Ldstr, this.Value);
            }
            else
            {
                generator.Emit(OpCodes.Ldnull);
            }

            return null;
        }

        public override string ToString()
        {
            if(String.IsNullOrEmpty(this.Value))
                return "NULL";
            
            return this.Value;
        }
    }

    /// <summary>
    /// Low-level operation corresponding to .NET MSIL code -- enables compilation to machine language for the fastest possible validation for large building files.
    /// </summary>
    public enum DocOpCode
    {
        NoOperation = 0, // no operation (use value on stack)

        CompareEqual = 0xFE01,    // compare equal
        CompareGreaterThan = 0xFE02,
        CompareGreaterThanOrEqual = 0xFE03,
        CompareLessThan = 0xFE04,
        CompareLessThanOrEqual = 0xFE05,
        CompareNotEqual = 0x66FE01,

        And = 0x5F,    // conditional and
        Or = 0x60,
        Xor = 0x61,

        LoadString = 0x72,  // string
        LoadLength = 0x8e, // load array length
        IsInstance = 0x75, // check type

        LoadArgument = 0x0E, // load argument (parameter)
        LoadField = 0x7B, // load field

        IsIncluded = 0xFF0001, // custom op for checking containment in array
        IsUnique = 0xFF0002, // custom op for uniqueness
    }

    /// <summary>
    /// Concept (usage of a template)
    /// </summary>
    public class DocTemplateUsage : DocObject // now inherits from DocObject
    {
        [DataMember(Order = 0)] private DocTemplateDefinition _Definition; // the template definition to be used for formatting text.
        [DataMember(Order = 1)] private List<DocTemplateItem> _Items; // items to be listed within use definition (rules)
        [DataMember(Order = 2)] private List<DocExchangeItem> _Exchanges; // new in 2.5
        //[DataMember(Order = 3)] private DocModelView _ModelView; // new in 2.7, removed on 3.5; determine from ModelView.ConceptRoot.Concepts hierarchy
        [DataMember(Order = 3)] private bool _Override; // new in 5.0; if true, then any concepts from supertypes are not inherited

        public DocTemplateUsage()
        {
            this._Items = new List<DocTemplateItem>();
            this._Exchanges = new List<DocExchangeItem>();
        }

        public override string ToString()
        {
            if (this.Definition != null)
            {
                return this.Definition.ToString();
            }
            else
            {
                return base.ToString();
            }
        }

        public DocTemplateDefinition Definition
        {
            get
            {
                return this._Definition;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this._Definition = value;
            }
        }

        public List<DocTemplateItem> Items
        {
            get
            {
                return this._Items;
            }
        }

        public List<DocExchangeItem> Exchanges
        {
            get
            {
                return this._Exchanges;
            }
        }

        public bool Override
        {
            get
            {
                return this._Override;
            }
            set
            {
                this._Override = value;
            }
        }

        public DocExchangeItem GetExchange(DocExchangeDefinition definition, DocExchangeApplicabilityEnum applicability)
        {
            foreach (DocExchangeItem docExchange in this._Exchanges)
            {
                if (docExchange.Exchange == definition && docExchange.Applicability == applicability)
                {
                    return docExchange;
                }
            }

            return null;
        }

        public void RegisterExchange(DocExchangeDefinition docExchange, DocExchangeRequirementEnum requirement)
        {
            DocExchangeItem docIm = null;
            DocExchangeItem docEx = null;
            foreach (DocExchangeItem eachEx in this.Exchanges)
            {
                if (eachEx.Exchange == docExchange)
                {
                    if (eachEx.Applicability == DocExchangeApplicabilityEnum.Export)
                    {
                        docEx = eachEx;
                    }
                    else if (eachEx.Applicability == DocExchangeApplicabilityEnum.Import)
                    {
                        docIm = eachEx;
                    }
                }
            }

            if (docEx == null)
            {
                docEx = new DocExchangeItem();
                this.Exchanges.Add(docEx);
                docEx.Exchange = docExchange;
                docEx.Applicability = DocExchangeApplicabilityEnum.Export;
            }

            if (docIm == null)
            {
                docIm = new DocExchangeItem();
                this.Exchanges.Add(docIm);
                docIm.Exchange = docExchange;
                docIm.Applicability = DocExchangeApplicabilityEnum.Import;
            }

            docEx.Requirement = requirement;
            docIm.Requirement = requirement;
        }

        public override void Delete()
        {
            foreach(DocTemplateItem docItem in this.Items)
            {
                docItem.Delete();
            }

            foreach(DocExchangeItem docItem in this.Exchanges)
            {
                docItem.Delete();
            }

            base.Delete();
        }
    }

    public class DocExchangeItem : SEntity
    {
        [DataMember(Order = 0)] public DocExchangeDefinition Exchange; // 2.7: type changed from DocAnnotation
        [DataMember(Order = 1)] public DocExchangeApplicabilityEnum Applicability;
        [DataMember(Order = 2)] public DocExchangeRequirementEnum Requirement;
    }

    public enum DocExchangeApplicabilityEnum
    {
        Export = 1,
        Import = 2,
    }

    public enum DocExchangeRequirementEnum
    {
        Mandatory = 1,
        Optional = 2,
        NotRelevant = 3,
        Excluded = 4,
    }

    public class DocTemplateItem : DocObject // now inherits from DocObject
    {
        [DataMember(Order = 0)] private List<DocTemplateUsage> _Concepts;// IfcDoc 6.3: for parameters consisting of lists of objects -- translates to nested concepts in mvdXML
        //[DataMember(Order = 0), Obsolete] private string _PredefinedType; // e.g. 'TOGGLESWITCH'
        [DataMember(Order = 1), Obsolete] private string _Field1; // e.g. 'Power'
        [DataMember(Order = 2), Obsolete] private string _Field2; // e.g. 'The power from the circuit.'
        [DataMember(Order = 3), Obsolete] private string _Field3; // e.g. 'ELECTRICAL'
        [DataMember(Order = 4), Obsolete] private string _Field4; // e.g. 'SOURCE'

        // new in 2.5
        [DataMember(Order = 5)] private string _RuleInstanceID; // id of the entity rule to instantiate for each item
        [DataMember(Order = 6)] private string _RuleParameters; // parameters and constraints to substitute into the rule

        public List<DocTemplateUsage> Concepts
        {
            get
            {
                if(this._Concepts == null)
                {
                    this._Concepts = new List<DocTemplateUsage>();
                }

                return this._Concepts;
            }
        }

        public string RuleInstanceID
        {
            get
            {
                return this._RuleInstanceID;
            }
            set
            {
                this._RuleInstanceID = value;
            }
        }

        public string RuleParameters
        {
            get
            {
                return this._RuleParameters;
            }
            set
            {
                this._RuleParameters = value;
            }
        }

        public DocTemplateUsage GetParameterConcept(string parameter, DocTemplateDefinition def)
        {
            foreach (DocTemplateUsage docEachUsage in this.Concepts)
            {
                if (docEachUsage.Name.Equals(parameter) && docEachUsage.Definition == def)
                {
                    return docEachUsage;
                }
            }

            return null;
        }

        public DocTemplateUsage RegisterParameterConcept(string parameter, DocTemplateDefinition def)
        {
            DocTemplateUsage docUsage = this.GetParameterConcept(parameter, def);
            if (docUsage == null)
            {
                docUsage = new DocTemplateUsage();
                docUsage.Name = parameter;
                docUsage.Definition = def;
                this.Concepts.Add(docUsage);
            }
            return docUsage;
        }

        public string GetParameterValue(string key)
        {
            if (this.RuleParameters == null)
                return null;

            string[] parms = this.RuleParameters.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string parm in parms)
            {
                // for now, only equals supported
                string[] args = parm.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                if (args.Length == 2)
                {
                    if (args[0].Equals(key))
                    {
                        return args[1];
                    }
                }
            }

            return null; // no such parameters
        }
    }
  
    /// <summary>
    /// Represents a top-level documentation clause such as "Core Layer", "Extension Layer", "Domain Layer", or "Resource Layer"
    /// </summary>
    public class DocSection : DocObject
    {
        [DataMember(Order = 0)] public List<DocAnnotation> Annotations; // v1.8 inserted  TBD - use MVD-XML concept instead
        [DataMember(Order = 1)] public List<DocSchema> Schemas;        

        public DocSection(string name)
        {
            this.Name = name;
            this.Annotations = new List<DocAnnotation>();
            this.Schemas = new List<DocSchema>();
        }
    }

    /// <summary>
    /// Represents a top-level documentation annex
    /// </summary>
    public class DocAnnex : DocObject
    {
        public DocAnnex(string name)
        {
            this.Name = name;
        }
    }

    /// <summary>
    /// Represents a generic definition
    /// </summary>
    public class DocAnnotation : DocObject
    {
        [DataMember(Order = 0)] public List<DocAnnotation> Annotations;

        public DocAnnotation()
        {
            this.Annotations = new List<DocAnnotation>();
        }
    }

    /// <summary>
    /// A reference which may be normative or non-normative (in bibliography)
    /// </summary>
    public class DocReference : DocObject
    {
    }

    public class DocTerm : DocObject
    {
        [DataMember(Order = 0)] private List<DocTerm> _Terms; // added in V7.3  // sub-terms

        public List<DocTerm> Terms
        {
            get
            {
                if(this._Terms == null)
                {
                    this._Terms = new List<DocTerm>();
                }

                return this._Terms;
            }
        }
    }
    
    public class DocAbbreviation : DocObject
    {
    }

    public abstract class DocGeometry : SEntity
    {
    }

    // new in IfcDoc 3.5 for capturing Express-G diagrams
    public class DocPoint : DocGeometry
    {
        [DataMember(Order = 0)] public double X;
        [DataMember(Order = 1)] public double Y;

        public DocPoint()
        {
        }

        public DocPoint(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    // new in IFcDoc 5.8 for capturing nested tree structures of lines
    public class DocLine : SEntity
    {
        [DataMember(Order = 0)] private List<DocPoint> _DiagramLine; // required points
        [DataMember(Order = 1)] private List<DocLine> _Tree; // optional set of nested lines
        [DataMember(Order = 2)] private DocDefinition _Definition; // optional target that the line points to

        public DocLine()
        {
        }

        public List<DocPoint> DiagramLine
        {
            get
            {
                if(this._DiagramLine == null)
                {
                    this._DiagramLine = new List<DocPoint>();
                }

                return this._DiagramLine;
            }
        }

        public List<DocLine> Tree
        {
            get
            {
                if(this._Tree == null)
                {
                    this._Tree = new List<DocLine>();
                }

                return this._Tree;
            }
        }

        public DocDefinition Definition
        {
            get
            {
                return this._Definition;
            }
            set
            {
                this._Definition = value;
            }
        }

        public override void Delete()
        {
            base.Delete();

            foreach(DocPoint docPoint in this.DiagramLine)
            {
                docPoint.Delete();
            }

            foreach(DocLine docLine in this.Tree)
            {
                docLine.Delete();
            }
        }
    }

    // new in IfcDoc 3.5 for capturing Express-G diagrams
    public class DocRectangle : DocGeometry
    {
        [DataMember(Order = 0)] public double X;
        [DataMember(Order = 1)] public double Y;
        [DataMember(Order = 2)] public double Width;
        [DataMember(Order = 3)] public double Height;
    }

    /// <summary>
    /// Reference to another schema
    /// </summary>
    public class DocSchemaRef : DocObject // new in v4.9
    {
        [DataMember(Order = 0)] public List<DocDefinitionRef> _Definitions;

        public DocSchemaRef()
        {
            this._Definitions = new List<DocDefinitionRef>();
        }

        /// <summary>
        /// Definitions referenced within schema reference
        /// </summary>
        public List<DocDefinitionRef> Definitions
        {
            get
            {
                return this._Definitions;
            }
        }
    }

    /// <summary>
    /// Reference to a definition within another schema.
    /// </summary>
    public class DocDefinitionRef : DocDefinition, // new in v4.9
        IDocTreeHost
    {
        [DataMember(Order = 0)] private List<DocLine> _Tree; // new in 5.8 

        public List<DocLine> Tree
        {
            get
            {
                if (this._Tree == null)
                {
                    this._Tree = new List<DocLine>();
                }

                return this._Tree;
            }
        }
    }

    /// <summary>
    /// Comment
    /// </summary>
    public class DocComment : DocDefinition
    {
    }

    /// <summary>
    /// Represents a Schema
    /// </summary>
    public class DocSchema : DocObject
    {
        // ORDER CHANGED in V1.8
        [DataMember(Order = 0)] public List<DocAnnotation> Annotations;   // 5.1.1 Definitions     // inserted in 1.8      
        [DataMember(Order = 1)] public List<DocType> Types;               // 5.1.2 Types           // moved up in 1.8
        [DataMember(Order = 2)] public List<DocEntity> Entities;          // 5.1.3 Entities        // moved down in 1.8
        [DataMember(Order = 3)] public List<DocFunction> Functions;       // 5.1.4 Functions
        [DataMember(Order = 4)] public List<DocGlobalRule> GlobalRules;   // 5.1.5 Global Rules    // inserted in 1.2
        [DataMember(Order = 5)] public List<DocPropertySet> PropertySets; // 5.1.6 Property Sets
        [DataMember(Order = 6)] public List<DocQuantitySet> QuantitySets; // 5.1.7 Quantity Sets
        [DataMember(Order = 7)] private List<DocPageTarget> _PageTargets;   // inserted in 3.5, renamed to DocPageTarget in 4.9
        [DataMember(Order = 8)] private List<DocSchemaRef> _SchemaRefs;     // inserted in 4.9
        [DataMember(Order = 9)] private List<DocComment> _Comments;         // inserted in 4.9
        [DataMember(Order = 10)] private List<DocPropertyEnumeration> _PropertyEnums; // inserted in 5.8
        [DataMember(Order = 11)] private List<DocPrimitive> _Primitives;    // inserted in 5.8
        [DataMember(Order = 12)] public int DiagramPagesHorz; // inserted in 5.8
        [DataMember(Order = 13)] public int DiagramPagesVert; // inserted in 5.8

        public DocSchema()
        {
            this.Annotations = new List<DocAnnotation>();
            this.Entities = new List<DocEntity>();
            this.Types = new List<DocType>();
            this.Functions = new List<DocFunction>();
            this.GlobalRules = new List<DocGlobalRule>();
            this.PropertySets = new List<DocPropertySet>();
            this.QuantitySets = new List<DocQuantitySet>();
        }

        public List<DocPageTarget> PageTargets
        {
            get
            {
                if(this._PageTargets == null)
                {
                    this._PageTargets = new List<DocPageTarget>();
                }

                return this._PageTargets;
            }
        }

        public List<DocSchemaRef> SchemaRefs
        {
            get
            {
                if (this._SchemaRefs == null)
                {
                    this._SchemaRefs = new List<DocSchemaRef>();
                }

                return this._SchemaRefs;
            }
        }

        public List<DocComment> Comments
        {
            get
            {
                if(this._Comments == null)
                {
                    this._Comments = new List<DocComment>();
                }

                return this._Comments;
            }
        }

        public List<DocPrimitive> Primitives
        {
            get
            {
                if(this._Primitives == null)
                {
                    this._Primitives = new List<DocPrimitive>();
                }

                return this._Primitives;
            }
        }

        public List<DocPropertyEnumeration> PropertyEnums
        {
            get
            {
                if (this._PropertyEnums == null)
                {
                    this._PropertyEnums = new List<DocPropertyEnumeration>();
                }

                return this._PropertyEnums;
            }
        }

        /// <summary>
        /// Creates or returns existing entity by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DocEntity RegisterEntity(string name)
        {
            // find existing
            foreach (DocEntity entity in this.Entities)
            {
                if (entity.Name.Equals(name))
                    return entity;
            }

            // create new
            DocEntity docEntity = new DocEntity();
            docEntity.Name = name;
            this.Entities.Add(docEntity);

            // sort alphabetically
            SortedList<string, DocEntity> sortEntity = new SortedList<string, DocEntity>();
            foreach (DocEntity s in this.Entities)
            {
                sortEntity.Add(s.Name, s);
            }
            this.Entities.Clear();

            foreach (DocEntity s in sortEntity.Values)
            {
                this.Entities.Add(s);
            }

            return docEntity;
        }

        public T RegisterType<T>(string name) where T : DocType, new()
        {
            // find existing
            foreach (DocType type in this.Types)
            {
                if (typeof(T).IsInstanceOfType(type) && type.Name.Equals(name))
                    return (T)type;
            }

            // create new
            T docType = new T();
            docType.Name = name;
            this.Types.Add(docType);

            // sort alphabetically
            SortedList<string, DocType> sortType = new SortedList<string, DocType>();
            foreach (DocType s in this.Types)
            {
                sortType.Add(s.Name, s);
            }
            this.Types.Clear();

            // order specifically

            foreach (DocType s in sortType.Values)
            {
                if (s is DocDefined)
                {
                    this.Types.Add(s);
                }
            }
            foreach (DocType s in sortType.Values)
            {
                if (s is DocEnumeration)
                {
                    this.Types.Add(s);
                }
            }
            foreach (DocType s in sortType.Values)
            {
                if (s is DocSelect)
                {
                    this.Types.Add(s);
                }
            }

            return docType;            
        }

        /// <summary>
        /// Creates or returns existing function by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DocFunction RegisterFunction(string name)
        {
            // find existing
            foreach (DocFunction entity in this.Functions)
            {
                if (entity.Name.Equals(name))
                    return entity;
            }

            // create new
            DocFunction docFunction = new DocFunction();
            docFunction.Name = name;
            this.Functions.Add(docFunction);

            // sort alphabetically
            SortedList<string, DocFunction> sort = new SortedList<string, DocFunction>();
            foreach (DocFunction s in this.Functions)
            {
                sort.Add(s.Name, s);
            }
            this.Functions.Clear();

            foreach (DocFunction s in sort.Values)
            {
                this.Functions.Add(s);
            }

            return docFunction;
        }

        /// <summary>
        /// Creates or returns existing rule by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DocGlobalRule RegisterRule(string name)
        {
            // find existing
            foreach (DocGlobalRule entity in this.GlobalRules)
            {
                if (entity.Name.Equals(name))
                    return entity;
            }

            // create new
            DocGlobalRule docFunction = new DocGlobalRule();
            docFunction.Name = name;
            this.GlobalRules.Add(docFunction);

            // sort alphabetically
            SortedList<string, DocGlobalRule> sort = new SortedList<string, DocGlobalRule>();
            foreach (DocGlobalRule s in this.GlobalRules)
            {
                sort.Add(s.Name, s);
            }
            this.GlobalRules.Clear();

            foreach (DocGlobalRule s in sort.Values)
            {
                this.GlobalRules.Add(s);
            }

            return docFunction;
        }

        public DocPropertySet RegisterPset(string name)
        {
            // find existing
            foreach (DocPropertySet entity in this.PropertySets)
            {
                if (entity.Name.Equals(name))
                    return entity;
            }

            // create new
            DocPropertySet docFunction = new DocPropertySet();
            docFunction.Name = name;
            this.PropertySets.Add(docFunction);

            // sort alphabetically
            SortedList<string, DocPropertySet> sort = new SortedList<string, DocPropertySet>();
            foreach (DocPropertySet s in this.PropertySets)
            {
                sort.Add(s.Name, s);
            }
            this.PropertySets.Clear();

            foreach (DocPropertySet s in sort.Values)
            {
                this.PropertySets.Add(s);
            }

            return docFunction;
        }

        public DocQuantitySet RegisterQset(string name)
        {
            // find existing
            foreach (DocQuantitySet entity in this.QuantitySets)
            {
                if (entity.Name.Equals(name))
                    return entity;
            }

            // create new
            DocQuantitySet docFunction = new DocQuantitySet();
            docFunction.Name = name;
            this.QuantitySets.Add(docFunction);

            // sort alphabetically
            SortedList<string, DocQuantitySet> sort = new SortedList<string, DocQuantitySet>();
            foreach (DocQuantitySet s in this.QuantitySets)
            {
                sort.Add(s.Name, s);
            }
            this.QuantitySets.Clear();

            foreach (DocQuantitySet s in sort.Values)
            {
                this.QuantitySets.Add(s);
            }

            return docFunction;
        }

        public int GetDiagramCount()
        {
            int iLastDiagram = 0;

            foreach (DocEntity docEnt in this.Entities)
            {
                if (docEnt.DiagramNumber > iLastDiagram)
                {
                    iLastDiagram = docEnt.DiagramNumber;
                }
            }
            foreach (DocType docType in this.Types)
            {
                if (docType.DiagramNumber > iLastDiagram)
                {
                    iLastDiagram = docType.DiagramNumber;
                }
            }

            if (this.SchemaRefs != null)
            {
                foreach (DocSchemaRef docRef in this.SchemaRefs)
                {
                    foreach (DocDefinitionRef docDef in docRef.Definitions)
                    {
                        if (docDef.DiagramNumber > iLastDiagram)
                        {
                            iLastDiagram = docDef.DiagramNumber;
                        }
                    }
                }
            }

            return iLastDiagram;
        }

        public override void Delete()
        {
            foreach(DocType doctype in this.Types)
            {
                doctype.Delete();
            }

            foreach(DocEntity docent in this.Entities)
            {
                docent.Delete();
            }

            foreach(DocFunction docfunc in this.Functions)
            {
                docfunc.Delete();
            }

            foreach(DocGlobalRule docrule in this.GlobalRules)
            {
                docrule.Delete();
            }

            base.Delete();
        }
    }

    /// <summary>
    /// Abstract type definition (base of Identity and Type)
    /// </summary>
    public abstract class DocDefinition : DocObject
    {
        [DataMember(Order = 0)] private DocRectangle _DiagramRectangle; // replaces template status (Integer) in v3.5
        [DataMember(Order = 1)] private int _DiagramNumber; // used to determine hyperlink to EXPRESS-G diagram [inserted in v1.2]        

        public DocRectangle DiagramRectangle
        {
            get
            {
                return this._DiagramRectangle;
            }
            set
            {
                this._DiagramRectangle = value;
            }
        }

        public int DiagramNumber
        {
            get
            {
                return this._DiagramNumber;
            }
            set
            {
                this._DiagramNumber = value;
            }
        }
    }

    /// <summary>
    /// EXPRESS-G page reference targets (has one or more sources that point to it)
    /// The name identifies the entity or type to be referenced across pages.
    /// </summary>
    public class DocPageTarget : DocDefinition // 4.9
    {
        [DataMember(Order = 0)] private List<DocPoint> _DiagramLine;
        [DataMember(Order = 1)] private List<DocPageSource> _Sources;
        [DataMember(Order = 2)] private DocDefinition _Definition; // 5.8

        public DocPageTarget()
        {
            this._DiagramLine = new List<DocPoint>();
            this._Sources = new List<DocPageSource>();
        }

        public List<DocPoint> DiagramLine
        {
            get
            {
                return this._DiagramLine;
            }
        }

        public List<DocPageSource> Sources
        {
            get
            {
                return this._Sources;
            }
        }

        public DocDefinition Definition
        {
            get
            {
                return this._Definition;
            }
            set
            {
                this._Definition = value;
            }
        }
    }

    /// <summary>
    /// Express-G page reference sources (link to targets)
    /// </summary>
    public class DocPageSource : DocDefinition // 4.9
    {
        [DataMember(Order = 0)] public DocPageTarget Target; // new in 5.8 -- link to associated target
    }

    /// <summary>
    /// Primitive declaration (e.g. BOOLEAN, LOGICAL, INTEGER, REAL, STRING, BINARY)
    /// </summary>
    public class DocPrimitive : DocDefinition // 5.8
    {
    }

    /// <summary>
    /// Represents an Identity
    /// </summary>
    public class DocEntity : DocDefinition,
        IDocTreeHost
    {
        [DataMember(Order = 0)] private string _BaseDefinition; // string base type
        [DataMember(Order = 1)] private int _EntityFlags;
        [DataMember(Order = 2)] private List<DocSubtype> _Subtypes; // flat list of subtypes (regardless of diagram tree)
        [DataMember(Order = 3)] private List<DocAttribute> _Attributes;
        [DataMember(Order = 4)] private List<DocUniqueRule> _UniqueRules;
        [DataMember(Order = 5)] private List<DocWhereRule> _WhereRules;
        [DataMember(Order = 6), Obsolete] private List<DocTemplateUsage> _Templates; // to be deprecated -- use ModelView.ConceptRoots[].Concepts
        [DataMember(Order = 7), Obsolete] private string _Description; // 2.7 -- holds Body description from MVD-XML for which documentation is generated; 5.3 deprecated
        [DataMember(Order = 8), Obsolete] private List<DocPoint> _DiagramLine; // 3.5 -- line to tree of subtypes - removed in V5.8
        [DataMember(Order = 9)] private List<DocLine> _Tree; // 5.8 -- tree of lines and subtypes for diagram rendering
        internal bool _InheritanceDiagramFlag;

        public DocEntity()
        {
            this._Subtypes = new List<DocSubtype>();
            this._Attributes = new List<DocAttribute>();
            this._UniqueRules = new List<DocUniqueRule>();
            this._WhereRules = new List<DocWhereRule>();
        }

        public string BaseDefinition
        {
            get
            {
                return this._BaseDefinition;
            }
            set
            {
                this._BaseDefinition = value;
            }
        }

        public int EntityFlags
        {
            get
            {
                return this._EntityFlags;
            }
            set
            {
                this._EntityFlags = value;
            }
        }


        public List<DocSubtype> Subtypes
        {
            get
            {
                return this._Subtypes;
            }
        }

        public List<DocAttribute> Attributes
        {
            get
            {
                return this._Attributes;
            }
        }

        public List<DocUniqueRule> UniqueRules
        {
            get
            {
                return this._UniqueRules;
            }
        }

        public List<DocWhereRule> WhereRules
        {
            get
            {
                return this._WhereRules;
            }
        }

        public List<DocLine> Tree
        {
            get
            {
                if(this._Tree == null)
                {
                    this._Tree = new List<DocLine>();
                }

                return this._Tree;
            }
        }

        // deprecated in 3.5 -- on view instead
        [Obsolete]
        internal List<DocTemplateUsage> __Templates
        {
            get
            {
                return this._Templates;
            }
        }

        [Category("Template Fields"), DisplayName("TEXT")]
        public string Text
        {
            get
            {                
                return MakeDisplayName(this.Name);
            }
        }

        private string MakeDisplayName(string content)
        {
            if (content == null)
                return null;

            if (content.StartsWith("IfcRelAssociates"))
                return content.Substring(16);

            if (content.StartsWith("IfcRel"))
                return null;

            StringBuilder sb = new StringBuilder();
            for (int i = 3; i < content.Length; i++)
            {
                if (Char.IsUpper(content[i]))
                {
                    // insert space before capital letter
                    if (i > 3)
                    {
                        sb.Append(" ");
                    }
                    sb.Append(Char.ToLower(content[i]));
                }
                else
                {
                    sb.Append(content[i]);
                }
            }

            return sb.ToString();
        }

        public bool IsAbstract()
        {
            return ((this.EntityFlags & 0x20) == 0);
        }

        public DocDefinition ResolveParameterType(DocModelRuleAttribute docRuleAttr, string parmname, Dictionary<string, DocObject> map)
        {
            DocAttribute docAttribute = this.ResolveAttribute(docRuleAttr.Name, map);
            if (docAttribute == null)
                return null;

            if (docRuleAttr.Identification != null && docRuleAttr.Identification.Equals(parmname))
            {
                // resolve type
                DocObject docdef = null;
                if (map.TryGetValue(docAttribute.DefinedType, out docdef) && docdef is DocDefinition)
                    return (DocDefinition)docdef;
            }

            // keep drilling
            foreach (DocModelRuleEntity docRuleEntity in docRuleAttr.Rules)
            {
                DocEntity docEntitySub = map[docRuleEntity.Name] as DocEntity;
                if (docEntitySub != null)
                {
                    foreach (DocModelRule docRuleSub in docRuleEntity.Rules)
                    {
                        if (docRuleSub is DocModelRuleAttribute)
                        {
                            DocDefinition docDefSub = docEntitySub.ResolveParameterType((DocModelRuleAttribute)docRuleSub, parmname, map);
                            if (docDefSub != null)
                            {
                                return docDefSub;
                            }
                        }
                    }
                }
            }

            return null;
        }

        internal DocAttribute ResolveAttribute(string attrname, Dictionary<string, DocObject> map)
        {
            foreach (DocAttribute docAttr in this.Attributes)
            {
                if (docAttr.Name.Equals(attrname))
                    return docAttr;
            }

            // super
            DocObject docObj = null;
            if (!String.IsNullOrEmpty(this.BaseDefinition) && map.TryGetValue(this.BaseDefinition, out docObj))
            {
                DocEntity docSuper = (DocEntity)docObj;
                return docSuper.ResolveAttribute(attrname, map);
            }

            return null;
        }

        public override void Delete()
        {
            foreach(DocAttribute docattr in this.Attributes)
            {
                docattr.Delete();
            }

            foreach(DocWhereRule docrule in this.WhereRules)
            {
                docrule.Delete();
            }

            foreach(DocUniqueRule docrule in this.UniqueRules)
            {
                docrule.Delete();
            }

            base.Delete();
        }

        public DocAttribute RegisterAttribute(string name)
        {
            foreach(DocAttribute docExist in this.Attributes)
            {
                if (docExist.Name.Equals(name))
                {
                    return docExist;
                }
            }

            DocAttribute docAttr = new DocAttribute();
            docAttr.Name = name;
            this.Attributes.Add(docAttr);
            return docAttr;
        }

        public DocWhereRule RegisterWhereRule(string name)
        {
            foreach (DocWhereRule docExist in this.WhereRules)
            {
                if (docExist.Name.Equals(name))
                {
                    return docExist;
                }
            }

            DocWhereRule docAttr = new DocWhereRule();
            docAttr.Name = name;
            this.WhereRules.Add(docAttr);
            return docAttr;
        }
    }

    public class DocSubtype : DocObject
    {
        [DataMember(Order = 0)] public string DefinedType;

        public DocSubtype()
        {
        }
    }

    /// <summary>
    /// Represents an Attribute
    /// </summary>
    public class DocAttribute : DocObject
    {
        [DataMember(Order = 0)] private string _DefinedType; // the EXPRESS type (bypassing any indirection from page references, etc.)
        [DataMember(Order = 1)] private DocDefinition _Definition; // the EXPRESS-G link -- never used until 5.8 -- holds EXPRESS-G target; renamed from "ReferencedType"
        [DataMember(Order = 2)] private int _AttributeFlags;
        [DataMember(Order = 3)] private int _AggregationType;
        [DataMember(Order = 4)] private int _AggregationFlag; // inserted
        [DataMember(Order = 5)] private string _AggregationLower; // was int (changed for VEX in v2.0)
        [DataMember(Order = 6)] private string _AggregationUpper; // was int (changed for VEX in v2.0)
        [DataMember(Order = 7)] private string _Inverse;
        [DataMember(Order = 8)] private string _Derived;
        [DataMember(Order = 9)] private DocAttribute _AggregationAttribute; // nested aggregations
        [DataMember(Order = 10)] private List<DocPoint> _DiagramLine; // line coordinates
        [DataMember(Order = 11)] private DocRectangle _DiagramLabel; // position of label
        [DataMember(Order = 12)] private DocXsdFormatEnum _XsdFormat;  // NEW in IfcDoc 4.9f: tag behavior
        [DataMember(Order = 13)] private bool _XsdTagless; // NEW in IfcDoc 5.0b: tagless

        public string DefinedType
        {
            get
            {
                return this._DefinedType;
            }
            set
            {
                this._DefinedType = value;
            }
        }

        public DocDefinition Definition
        {
            get
            {
                return this._Definition;
            }
            set
            {
                this._Definition = value;
            }
        }

        public int AttributeFlags
        {
            get
            {
                return this._AttributeFlags;
            }
            set
            {
                this._AttributeFlags = value;
            }
        }

        public int AggregationType
        {
            get
            {
                return this._AggregationType;
            }
            set
            {
                this._AggregationType = value;
            }
        }

        public int AggregationFlag
        {
            get
            {
                return this._AggregationFlag;
            }
            set
            {
                this._AggregationFlag = value;
            }
        }

        public string AggregationLower
        {
            get
            {
                return this._AggregationLower;
            }
            set
            {
                this._AggregationLower = value;
            }
        }

        public string AggregationUpper
        {
            get
            {
                return this._AggregationUpper;
            }
            set
            {
                this._AggregationUpper = value;
            }
        }

        public string Inverse
        {
            get
            {
                return this._Inverse;
            }
            set
            {
                this._Inverse = value;
            }
        }

        public string Derived
        {
            get
            {

                return this._Derived;
            }
            set
            {
                this._Derived = value;
            }
        }

        public DocAttribute AggregationAttribute
        {
            get
            {
                return this._AggregationAttribute;
            }
            set
            {
                this._AggregationAttribute = value;
            }
        }

        public List<DocPoint> DiagramLine
        {
            get
            {
                if (this._DiagramLine == null)
                {
                    this._DiagramLine = new List<DocPoint>();
                }
                return this._DiagramLine;
            }
        }

        public DocRectangle DiagramLabel
        {
            get    
            {
                return this._DiagramLabel;
            }
            set
            {
                this._DiagramLabel = value;
            }
        }

        public DocXsdFormatEnum XsdFormat
        {
            get
            {
                return this._XsdFormat;
            }
            set
            {
                this._XsdFormat = value;
            }
        }

        public bool XsdTagless
        {
            get
            {
                return this._XsdTagless;
            }
            set
            {
                this._XsdTagless = value;
            }
        }

        public DocAggregationEnum GetAggregation()
        {
            return (DocAggregationEnum)this.AggregationType;
        }

        public bool IsOptional()
        {
            return ((this.AttributeFlags & 1) != 0);
        }

        /// <summary>
        /// Returns aggregation expression suitable for use in diagram, e.g. "S[1:?]"
        /// </summary>
        /// <returns></returns>
        public string GetAggregationExpression()
        {
            string display = "";
            string lower = "0";
            string upper = "?";
            if (this.AggregationLower != null)
            {
                lower = this.AggregationLower;
            }
            if (this.AggregationUpper != null && this.AggregationUpper != "0")
            {
                upper = this.AggregationUpper;
            }
            DocAggregationEnum docAggr = this.GetAggregation();
            switch (docAggr)
            {
                case DocAggregationEnum.SET:
                    display += "S[" + lower + ":" + upper + "]";
                    break;

                case DocAggregationEnum.LIST:
                    display += "L[" + lower + ":" + upper + "]";
                    break;
            }

            return display;
        }

        public int GetAggregationNestingLower()
        {
            if (String.IsNullOrEmpty(this.AggregationLower))
                return 0; //??? or -1???

            int iLower = Int32.Parse(this.AggregationLower);
            DocAttribute docAggregate = this.AggregationAttribute;
            while (docAggregate != null)
            {
                int iInner = Int32.Parse(docAggregate.AggregationLower);
                iLower = iLower * iInner;
                docAggregate = docAggregate.AggregationAttribute;
            }

            return iLower;
        }

        public int GetAggregationNestingUpper()
        {
            if (String.IsNullOrEmpty(this.AggregationUpper))
                return 0;

            int iUpper = Int32.Parse(this.AggregationUpper);
            DocAttribute docAggregate = this.AggregationAttribute;
            while (docAggregate != null)
            {
                int iInner = Int32.Parse(docAggregate.AggregationUpper);
                iUpper = iUpper * iInner;
                docAggregate = docAggregate.AggregationAttribute;
            }

            return iUpper;
        }

        public override void Delete()
        {
            if(this.AggregationAttribute != null)
            {
                this.AggregationAttribute.Delete();
            }

            base.Delete();
        }
    }

    public enum DocAggregationEnum
    {
        NONE = 0,
        LIST = 1,
        ARRAY = 2,
        SET = 3,
        BAG = 4,
    }

    public class DocUniqueRule : DocConstraint
    {
        [DataMember(Order = 0)] public List<DocUniqueRuleItem> Items;
    }

    public class DocUniqueRuleItem : DocObject
    {        
    }

    public class DocWhereRule : DocConstraint
    {
    }

    /// <summary>
    /// Abstract base class of types (non-entities)
    /// </summary>
    public abstract class DocType : DocDefinition
    {

    }
   
    /// <summary>
    /// A defined type
    /// </summary>
    public class DocDefined : DocType
    {
        [DataMember(Order = 0)] public string DefinedType;
        [DataMember(Order = 1)] public DocDefinition Definition; // never used until V5.8
        [DataMember(Order = 2)] public List<DocWhereRule> WhereRules;
        [DataMember(Order = 3)] public int Length; // e.g. length of string        
        [DataMember(Order = 4)] public DocAttribute Aggregation; // added V1.8, 2011-02-22
        [DataMember(Order = 5)] public List<DocPoint> DiagramLine; // added V5.8
    }

    /// <summary>
    /// A select type
    /// </summary>
    public class DocSelect : DocType,
        IDocTreeHost
    {
        [DataMember(Order = 0)] private List<DocSelectItem> _Selects;
        [DataMember(Order = 1)] private List<DocLine> _Tree; // V5.8, optional tree for EXPRESS-G diagram..... todo: replace this

        public override void Delete()
        {
            foreach (DocSelectItem docItem in this.Selects)
            {
                docItem.Delete();
            }

            foreach(DocLine docLine in this.Tree)
            {
                docLine.Delete();
            }

            base.Delete();
        }

        public List<DocSelectItem> Selects
        {
            get
            {
                if(this._Selects == null)
                {
                    this._Selects = new List<DocSelectItem>();
                }

                return this._Selects;
            }
        }

        public List<DocLine> Tree
        {
            get
            {
                if(this._Tree == null)
                {
                    this._Tree = new List<DocLine>();
                }

                return this._Tree;
            }
        }
    }

    public class DocSelectItem : DocObject
    {
        [DataMember(Order = 0), Obsolete] private List<DocPoint> _DiagramLine; // 3.8  -- deprecated in 5.8 (use DocLine instead to capture tree structure) 
    }

    /// <summary>
    /// An enumeration type
    /// </summary>
    public class DocEnumeration : DocType
    {
        [DataMember(Order = 0)] private List<DocConstant> _Constants;

        public List<DocConstant> Constants
        {
            get
            {
                if(this._Constants == null)
                {
                    this._Constants = new List<DocConstant>();
                }

                return this._Constants;
            }
        }

        public override void Delete()
        {
            foreach (DocConstant docconst in this.Constants)
            {
                docconst.Delete();
            }
            base.Delete();
        }
    }

    /// <summary>
    /// Constant of an enumeration
    /// </summary>
    public class DocConstant : DocObject
    {
    }

    public abstract class DocConstraint : DocObject
    {
        [DataMember(Order = 0)] private string _Expression;

        public string Expression
        {
            get
            {
                return this._Expression;
            }
            set
            {
                this._Expression = value;
            }
        }
    }

    /// <summary>
    /// Global function
    /// </summary>
    public class DocFunction : DocConstraint
    {
        [DataMember(Order = 0)] public List<DocParameter> Parameters;
        [DataMember(Order = 1)] public string ReturnValue;

        public DocFunction()
        {
            this.Parameters = new List<DocParameter>();
        }
    }

    public class DocParameter : DocObject
    {
        [DataMember(Order = 0)] public string DefinedType;
    }

    public class DocGlobalRule : DocConstraint
    {
        [DataMember(Order = 0)] public List<DocWhereRule> WhereRules;
        [DataMember(Order = 1)] public string ApplicableEntity; // really list, but IFC only has single item

        public DocGlobalRule()
        {
            this.WhereRules = new List<DocWhereRule>();
        }
    }

    public abstract class DocVariableSet : DocObject
    {
        [DataMember(Order = 0)] private string _ApplicableType; // e.g. IfcSensor/TEMPERATURESENSOR

        public string ApplicableType
        {
            get
            {
                return this._ApplicableType;
            }
            set
            {
                this._ApplicableType = value;
            }
        }
    }

    /// <summary>
    /// Property set definition
    /// </summary>
    public class DocPropertySet : DocVariableSet
    {
        [DataMember(Order = 0)] private string _PropertySetType; // PSET_OCCURRENCEDRIVEN, PSET_TYPEDRIVENOVERRIDE, PSET_PERFORMANCEDRIVEN
        [DataMember(Order = 1)] private List<DocProperty> _Properties;

        public DocPropertySet()
        {
            this._Properties = new List<DocProperty>();
        }

        public string PropertySetType
        {
            get
            {
                return this._PropertySetType;
            }
            set
            {
                this._PropertySetType = value;
            }
        }

        public List<DocProperty> Properties
        {
            get
            {
                return this._Properties;
            }           
        }

        internal DocProperty RegisterProperty(string p)
        {
            foreach (DocProperty docQuantity in this.Properties)
            {
                if (docQuantity.Name.Equals(p))
                    return docQuantity;
            }

            DocProperty q = new DocProperty();
            q.Name = p;
            this.Properties.Add(q);
            return q;
        }


        internal DocProperty GetProperty(string p)
        {
            foreach (DocProperty docQuantity in this.Properties)
            {
                if (docQuantity.Name.Equals(p))
                    return docQuantity;
            }

            return null;
        }
    }

    /// <summary>
    /// Property definition
    /// </summary>
    public class DocProperty : DocObject
    {
        [DataMember(Order = 0)] private DocPropertyTemplateTypeEnum _PropertyType; // IfcPropertySingleValue, IfcPropertyBoundedValue, ...
        [DataMember(Order = 1)] private string _PrimaryDataType;
        [DataMember(Order = 2)] private string _SecondaryDataType;
        [DataMember(Order = 3)] private List<DocProperty> _Elements; // enumerated or complex properties

        public DocProperty()
        {
            this._Elements = new List<DocProperty>();
        }

        [Category("Property")]
        public DocPropertyTemplateTypeEnum PropertyType
        {
            get
            {
                return this._PropertyType;
            }
            set
            {
                this._PropertyType = value;
            }
        }

        [Category("Property")]
        public string PrimaryDataType
        {
            get
            {
                return this._PrimaryDataType;
            }
            set
            {
                this._PrimaryDataType = value;
            }
        }

        [Category("Property")]
        public string SecondaryDataType
        {
            get
            {
                return this._SecondaryDataType;
            }
            set
            {
                this._SecondaryDataType = value;
            }
        }

        [Category("Property"), Browsable(false)] // not yet browsable (don't support complex properties for now)
        public List<DocProperty> Elements
        {
            get
            {
                return this._Elements;
            }
        }

        internal DocProperty RegisterProperty(string p)
        {
            foreach (DocProperty docQuantity in this.Elements)
            {
                if (docQuantity.Name.Equals(p))
                    return docQuantity;
            }

            DocProperty q = new DocProperty();
            q.Name = p;
            this.Elements.Add(q);
            return q;
        }

    }

    public enum DocPropertyTemplateTypeEnum
    {
        P_SINGLEVALUE = 0,
        P_ENUMERATEDVALUE = 1,
        P_BOUNDEDVALUE = 2,
        P_LISTVALUE = 3,
        P_TABLEVALUE = 4,
        P_REFERENCEVALUE = 5, 

        COMPLEX = 6,
    }

    // new in IFCDOC 5.8
    public class DocPropertyEnumeration : DocObject
    {
        [DataMember(Order = 0)] private List<DocPropertyConstant> _Constants;

        public DocPropertyEnumeration()
        {
            this._Constants = new List<DocPropertyConstant>();
        }

        public List<DocPropertyConstant> Constants
        {
            get
            {
                return this._Constants;
            }
        }
    }

    // new in IFCDOC 5.8
    public class DocPropertyConstant : DocObject
    {
    }
   
    /// <summary>
    /// Quantity set definition
    /// </summary>
    public class DocQuantitySet : DocVariableSet
    {
        [DataMember(Order = 0)] private List<DocQuantity> _Quantities;

        public DocQuantitySet()
        {
            this._Quantities = new List<DocQuantity>();
        }

        public List<DocQuantity> Quantities
        {
            get
            {
                return this._Quantities;
            }
        }

        internal DocQuantity RegisterQuantity(string p)
        {
            foreach (DocQuantity docQuantity in this.Quantities)
            {
                if (docQuantity.Name.Equals(p))
                    return docQuantity;
            }

            DocQuantity q = new DocQuantity();
            this.Quantities.Add(q);
            q.Name = p;
            return q;
        }

        internal DocQuantity GetQuantity(string p)
        {
            foreach (DocQuantity docQuantity in this.Quantities)
            {
                if (docQuantity.Name.Equals(p))
                    return docQuantity;
            }

            return null;
        }
    }

    /// <summary>
    /// Quantity definition
    /// </summary>
    public class DocQuantity : DocObject
    {
        [DataMember(Order = 0)] private DocQuantityTemplateTypeEnum _QuantityType; // IfcQuantityWeight, IfcQuantityLength, etc.

        [Category("Quantity")]
        public DocQuantityTemplateTypeEnum QuantityType
        {
            get
            {
                return this._QuantityType;
            }
            set
            {
                this._QuantityType = value;
            }
        }
    }

    public enum DocQuantityTemplateTypeEnum
    {
        Q_LENGTH = 11,
        Q_AREA = 12,
        Q_VOLUME = 13,
        Q_COUNT = 14,
        Q_WEIGHT = 15,
        Q_TIME = 16
    }
    
    public class DocChangeSet : DocObject
    {
        [DataMember(Order = 0)] private List<DocChangeAction> _ChangesEntities; // nested hierarchy: section / schema / entity / attribute
        [DataMember(Order = 1)] private string _VersionCompared; // null means same version as project
        [DataMember(Order = 2)] private string _VersionBaseline; // identifer of the baseline (takes on file name of compared ifcdoc file)
        [DataMember(Order = 3)] private List<DocChangeAction> _ChangesProperties; // IFCDOC v5.2
        [DataMember(Order = 4)] private List<DocChangeAction> _ChangesQuantities; // IFCDOC v5.2

        public DocChangeSet()
        {
            this._ChangesEntities = new List<DocChangeAction>();
            this._ChangesProperties = new List<DocChangeAction>();
            this._ChangesQuantities = new List<DocChangeAction>();
        }

        public List<DocChangeAction> ChangesEntities
        {
            get
            {
                return this._ChangesEntities;
            }
        }

        public string VersionCompared
        {
            get
            {
                return this._VersionCompared;
            }
            set
            {
                this._VersionCompared = value;
            }
        }

        public string VersionBaseline
        {
            get
            {
                return this._VersionBaseline;
            }
            set
            {
                this._VersionBaseline = value;
            }
        }

        public List<DocChangeAction> ChangesProperties
        {
            get
            {
                return this._ChangesProperties;
            }
        }

        public List<DocChangeAction> ChangesQuantities
        {
            get
            {
                return this._ChangesQuantities;
            }
        }

    }

    // Name identifies item
    public class DocChangeAction : DocObject
    {
        [DataMember(Order = 0)] private DocChangeActionEnum _Action;
        [DataMember(Order = 1)] private List<DocChangeAspect> _Aspects; // modifications
        [DataMember(Order = 2)] private List<DocChangeAction> _Changes; // nested changes
        [DataMember(Order = 3)] private bool _ImpactSPF; // not upward compatible with SPF        
        [DataMember(Order = 4)] private bool _ImpactXML; // not upward compatible with XML

        public DocChangeAction()
        {
            this._Aspects = new List<DocChangeAspect>();
            this._Changes = new List<DocChangeAction>();
        }

        public DocChangeActionEnum Action
        {
            get
            {
                return this._Action;
            }
            set
            {
                this._Action = value;
            }
        }

        public List<DocChangeAspect> Aspects
        {
            get
            {
                return this._Aspects;
            }
        }

        public List<DocChangeAction> Changes
        {
            get
            {
                return this._Changes;
            }
        }

        public bool ImpactSPF
        {
            get
            {
                return this._ImpactSPF;
            }
            set
            {
                this._ImpactSPF = value;
            }
        }

        public bool ImpactXML
        {
            get
            {
                return this._ImpactXML;
            }
            set
            {
                this._ImpactXML = value;
            }
        }

        /// <summary>
        /// Indicates if this action or any subactions have changes.
        /// Used to hide records that don't contain any changes
        /// </summary>
        /// <returns></returns>
        public bool HasChanges()
        {
            if (this.Action != DocChangeActionEnum.NOCHANGE)
                return true;

            foreach (DocChangeAction sub in this.Changes)
            {
                if (sub.HasChanges())
                {
                    return true;
                }
            }

            return false;
        }
    }

    public enum DocChangeActionEnum
    {
        NOCHANGE = 0, // no direct change, however subitems may have changes
        ADDED = 1,
        DELETED = 2,
        MODIFIED = 4,
        MOVED = 5, // moved from another schema
    }

    public class DocChangeAspect : SEntity
    {
        [DataMember(Order = 0)] private DocChangeAspectEnum _Aspect;
        [DataMember(Order = 1)] private string _OldValue;
        [DataMember(Order = 2)] private string _NewValue;

        public DocChangeAspect(DocChangeAspectEnum aspect, string oldval, string newval)
        {
            this.Aspect = aspect;
            this.OldValue = oldval;
            this.NewValue = newval;            
        }

        public DocChangeAspectEnum Aspect
        {
            get
            {
                return this._Aspect;
            }
            set
            {
                this._Aspect = value;
            }
        }

        public string OldValue
        {
            get
            {
                return this._OldValue;
            }
            set
            {
                this._OldValue = value;
            }
        }

        public string NewValue
        {
            get
            {
                return this._NewValue;
            }
            set
            {
                this._NewValue = value;
            }
        }

        public override string ToString()
        {
            string display = this.Aspect.ToString().Substring(0, 1) + this.Aspect.ToString().ToLower().Substring(1);
            
            if (!String.IsNullOrEmpty(NewValue) && !String.IsNullOrEmpty(OldValue))
            {
                return display + " changed from <i>" + OldValue + "</i> to <i>" + NewValue + "</i>. ";
            }
            else if (NewValue != null)
            {
                return display + " changed to <i>" + NewValue + "</i>. ";
            }
            else if (OldValue != null)
            {
                return display + " changed from <i>" + OldValue + "</i>. ";
            }

            return this.Aspect.ToString();
        }
    }

    public enum DocChangeAspectEnum
    {
        NAME = 1,
        TYPE = 2,
        INSTANTIATION = 3,
        AGGREGATION = 4,
        SCHEMA = 5,
    }

    public class DocExample : DocVariableSet // inherited in 4.2 to contain ApplicableType (was DocObject)
    {
        [DataMember(Order = 0)] private List<DocExample> _Examples; // added in 4.3
        [DataMember(Order = 1)] private List<DocTemplateDefinition> _ApplicableTemplates; // added in 4.9
        [DataMember(Order = 2)] private DocModelView _ModelView;// added in 5.3
        [DataMember(Order = 3)] private byte[] _File; // added in 7.2 - encoded data of file in IFC format

        public DocExample()
        {
            this._Examples = new List<DocExample>();
        }

        public List<DocExample> Examples
        {
            get
            {
                return this._Examples;
            }
            set
            {
                // setter is present because files produced from older IfcDoc versions have it null.
                this._Examples = value;
            }
        }

        public List<DocTemplateDefinition> ApplicableTemplates
        {
            get
            {
                return this._ApplicableTemplates;
            }
            set
            {
                // setter is present because files produced from older IfcDoc versions have it null.
                this._ApplicableTemplates = value;
            }
        }

        public DocModelView ModelView
        {
            get
            {
                return this._ModelView;
            }
            set
            {
                this._ModelView = value;
            }
        }

        public byte[] File
        {
            get
            {
                return this._File;
            }
            set
            {
                this._File = value;
            }
        }
    }

    /// <summary>
    /// A definition that can be formatted as a tree
    /// </summary>
    public interface IDocTreeHost
    {
        List<DocLine> Tree { get; } 
    }
}
