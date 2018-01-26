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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("6ff23b49-a35e-4a04-83fd-dec58e1caa68")]
	public abstract partial class IfcNamedUnit :
		BuildingSmart.IFC.IfcMeasureResource.IfcUnit
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDimensionalExponents _Dimensions;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcUnitEnum _UnitType;
	
	
		public IfcNamedUnit()
		{
		}
	
		public IfcNamedUnit(IfcDimensionalExponents __Dimensions, IfcUnitEnum __UnitType)
		{
			this._Dimensions = __Dimensions;
			this._UnitType = __UnitType;
		}
	
		[Description("The dimensional exponents of the SI base units by which the named unit is defined" +
	    ".")]
		public IfcDimensionalExponents Dimensions { get { return this._Dimensions; } set { this._Dimensions = value;} }
	
		[Description("The type of the unit.")]
		public IfcUnitEnum UnitType { get { return this._UnitType; } set { this._UnitType = value;} }
	
	
	}
	
}
