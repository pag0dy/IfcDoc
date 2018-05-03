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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcDerivedUnit :
		BuildingSmart.IFC.IfcMeasureResource.IfcUnit
	{
		[DataMember(Order = 0)] 
		[Description("The group of units and their exponents that define the derived unit.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcDerivedUnitElement> Elements { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Name of the derived unit chosen from an enumeration of derived unit types for use in IFC models.")]
		[Required()]
		public IfcDerivedUnitEnum UnitType { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		public IfcLabel? UserDefinedType { get; set; }
	
	
		public IfcDerivedUnit(IfcDerivedUnitElement[] __Elements, IfcDerivedUnitEnum __UnitType, IfcLabel? __UserDefinedType)
		{
			this.Elements = new HashSet<IfcDerivedUnitElement>(__Elements);
			this.UnitType = __UnitType;
			this.UserDefinedType = __UserDefinedType;
		}
	
		public new IfcDimensionalExponents Dimensions { get { return null; } }
	
	
	}
	
}
