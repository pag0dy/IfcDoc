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

using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("cadb7794-f1ab-4438-a35f-0ba4b280d962")]
	public partial class IfcConversionBasedUnitWithOffset : IfcConversionBasedUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcReal _ConversionOffset;
	
	
		public IfcConversionBasedUnitWithOffset()
		{
		}
	
		public IfcConversionBasedUnitWithOffset(IfcDimensionalExponents __Dimensions, IfcUnitEnum __UnitType, IfcLabel __Name, IfcMeasureWithUnit __ConversionFactor, IfcReal __ConversionOffset)
			: base(__Dimensions, __UnitType, __Name, __ConversionFactor)
		{
			this._ConversionOffset = __ConversionOffset;
		}
	
		[Description("A positive or negative offset to add after the inherited <em>ConversionFactor</em" +
	    "> was applied.\r\n")]
		public IfcReal ConversionOffset { get { return this._ConversionOffset; } set { this._ConversionOffset = value;} }
	
	
	}
	
}
