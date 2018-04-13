IFC schemas
===========

This folder contains the IFC schema, organized by major release.

Within each schema release, sub-folders are provided to organize data definitions into subsets, which correspond to C# namespaces.

The files within may be edited directly to make changes to the schema and/or documentation. The IfcDoc tool may also be used to read/write the entire C# folder structure and/or generated .NET dll, however this tool is not required.

For documentation, HTML files are used to capture documentation at the definition level, while the [Description] attribute is used for properties and enumeration constants inline. Localized descriptions are provided in .resx files, such that they may be easily edited from Visual Studio or other .NET localization tools.

Conventions for defining classes follow .NET conventions established for serialization and data annotations, where .NET custom attributes capture metadata for serialization, validation, and documentation. All definitions use the "partial" keyword, such that they may be extended with additional functionality from other modules. Schema definitions edited within shall _only_ be used to define the data structures, and use only the conventions established below. Extensions for additional functionality should be made in separate modules that extend the schema, as automated tools may also be used to edit the files within where such additional information could be lost. 

**class**: an entity, which may derive from a base class, must be public, may be abstract, and contain a constructor for populating all fields on the class and any inherited classes.
* [Guid]: unique id, use for tracking scenarios if class is renamed between schema versions.
* [DefaultMember]: designates a property that may be used as an identifier in queries.
* [Obsolete]: class is deprecated

**property**: an attribute within an entity, defined by type, must be public, may be nullable if optional (using "?" operator), with collections supported for typed arrays, ISet<> and IList<>.
* [DataMember]: designates a property for serialization with particular order.
* [InverseProperty]: designates a property as inverse, linking to corresponding direct property, which will not be directly serialized by default.
* [XmlElement]: marks item for serialization as an XML element - if name is provided, then tags are used for property and class of instance(s); if not provided, then tag is only used for property.
* [XmlAttribute]: marks item for serialization as an XML attribute
* [Required]: indicates property is required (cannot be null).
* [MinLength]: for collections, indicates minimum size
* [MaxLength]: for collections, indicates maximum size; for strings, indicates maximum string length.
* [Description]: description of property published in documentation and visible in .NET property viewers.
* [Obsolete]: property is deprecated

**interface**: implemented by multiple classes; corresponds to "SELECT" in EXPRESS language
* [Guid]: unique id, use for tracking scenarios if interface is renamed between schema versions.

**struct**: a defined type, which must contain a constructor and a single public field named "Value" that refers to another defined type or a primitive: bool, long, double, string, byte[].
* [Guid]: unique id, use for tracking scenarios if struct is renamed between schema versions.

**enum**: an enumeration indicating a set of defined values, for which one must be used (flags are not supported for interoperability considerations).
* [Guid]: unique id, use for tracking scenarios if enum is renamed between schema versions.

**constant**: constants within enumerations indicate identifier and value, where 0 indicates the default "not defined" state, and -1 indicates "user-defined" state by convention.
* [Description]: description of enum constant published in documentation and visible in .NET property viewers.

---

Within each IFC release folder, there are several additional files as follows:
* AssemblyInfo.cs: provides version release information for identifying particular schema
* BuildingSmart.IFC.csproj: C# project file that contains all files within -- if adding/removing/renaming a definition, this should be updated.

Within each IFC sub-schema folder, there are several additional files as follows:
* schema.htm: documentation for the overall sub-schema
* schema.svg: UML diagram for the overall sub-schema, using specific conventions which may be graphically edited from IfcDoc

For validation, currently EXPRESS rules are captured in separate files underneath "validation" sub-folders. At some point, these may be migrated to C#, however for now they are captured as separate files.
