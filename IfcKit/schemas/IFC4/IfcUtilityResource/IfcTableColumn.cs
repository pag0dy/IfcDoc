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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
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
		[XmlElement("IfcReference")]
		IfcReference _ReferencePath;
	
	
		[Description("Table column identifier.")]
		public IfcIdentifier? Identifier { get { return this._Identifier; } set { this._Identifier = value;} }
	
		[Description("The table column display name.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Descriptive text for the table column.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The unit of measure to be used for this column\'s data.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		[Description("Optional path to the object and attribute for which this column applies.")]
		public IfcReference ReferencePath { get { return this._ReferencePath; } set { this._ReferencePath = value;} }
	
	
	}
	
}
