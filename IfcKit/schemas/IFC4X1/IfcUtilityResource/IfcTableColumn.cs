// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcUtilityResource
{
	[Guid("8ddc55ed-5fdd-4eec-bbba-86270d59039c")]
	public partial class IfcTableColumn
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _Identifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		IfcUnit _Unit;
	
		[DataMember(Order=4)] 
		[XmlElement]
		IfcReference _ReferencePath;
	
	
		public IfcTableColumn()
		{
		}
	
		public IfcTableColumn(IfcIdentifier? __Identifier, IfcLabel? __Name, IfcText? __Description, IfcUnit __Unit, IfcReference __ReferencePath)
		{
			this._Identifier = __Identifier;
			this._Name = __Name;
			this._Description = __Description;
			this._Unit = __Unit;
			this._ReferencePath = __ReferencePath;
		}
	
		[Description("The <i>Identifier</i> identifies the column within the table. If provided, it mus" +
	    "t be unique within the table. Columns may be cross-referenced across multiple ta" +
	    "bles by sharing the same column identifier.")]
		public IfcIdentifier? Identifier { get { return this._Identifier; } set { this._Identifier = value;} }
	
		[Description("The <i>Name</i> is a human-readable caption for the table column. It is not neces" +
	    "sarilly unique.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The <i>Description</i> provides human-readable text describing the table column.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The <i>Unit</i> indicates the unit of measure to be used for this column\'s data. " +
	    "If not provided, then project default units are assumed. If <i>ReferencePath</i>" +
	    " is provided, the the unit must be of the same measure as the referenced attribu" +
	    "te.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		[Description(@"The <i>ReferencePath</i> indicates a relative path to the object and attribute for which data within this column is to be applied. 
	
	For constraints, such path is relative to the <i>IfcObjectDefinition</i> associated by <i>IfcRelAssociatesConstraint</i>.RelatedObjects. For a constraint to be satisified, exactly one row of the table must match the referenced object for all columns where the <i>ReferencePath</i> attribute is set.")]
		public IfcReference ReferencePath { get { return this._ReferencePath; } set { this._ReferencePath = value;} }
	
	
	}
	
}
