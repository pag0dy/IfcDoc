// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcTableColumn
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The <i>Identifier</i> identifies the column within the table. If provided, it must be unique within the table. Columns may be cross-referenced across multiple tables by sharing the same column identifier.")]
		public IfcIdentifier? Identifier { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The <i>Name</i> is a human-readable caption for the table column. It is not necessarilly unique.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The <i>Description</i> provides human-readable text describing the table column.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The <i>Unit</i> indicates the unit of measure to be used for this column's data. If not provided, then project default units are assumed. If <i>ReferencePath</i> is provided, the the unit must be of the same measure as the referenced attribute.")]
		public IfcUnit Unit { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlElement]
		[Description("The <i>ReferencePath</i> indicates a relative path to the object and attribute for which data within this column is to be applied.     For constraints, such path is relative to the <i>IfcObjectDefinition</i> associated by <i>IfcRelAssociatesConstraint</i>.RelatedObjects. For a constraint to be satisified, exactly one row of the table must match the referenced object for all columns where the <i>ReferencePath</i> attribute is set.")]
		public IfcReference ReferencePath { get; set; }
	
	
		public IfcTableColumn(IfcIdentifier? __Identifier, IfcLabel? __Name, IfcText? __Description, IfcUnit __Unit, IfcReference __ReferencePath)
		{
			this.Identifier = __Identifier;
			this.Name = __Name;
			this.Description = __Description;
			this.Unit = __Unit;
			this.ReferencePath = __ReferencePath;
		}
	
	
	}
	
}
