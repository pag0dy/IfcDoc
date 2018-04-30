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

using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcConversionBasedUnitWithOffset : IfcConversionBasedUnit
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("A positive or negative offset to add after the inherited <em>ConversionFactor</em> was applied.  ")]
		[Required()]
		public IfcReal ConversionOffset { get; set; }
	
	
		public IfcConversionBasedUnitWithOffset(IfcDimensionalExponents __Dimensions, IfcUnitEnum __UnitType, IfcLabel __Name, IfcMeasureWithUnit __ConversionFactor, IfcReal __ConversionOffset)
			: base(__Dimensions, __UnitType, __Name, __ConversionFactor)
		{
			this.ConversionOffset = __ConversionOffset;
		}
	
	
	}
	
}
