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
	[Guid("3e7d104e-f42b-479a-a851-1137fe09d6e8")]
	public partial class IfcConversionBasedUnit : IfcNamedUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcMeasureWithUnit _ConversionFactor;
	
	
		[Description("The word, or group of words, by which the conversion based unit is referred to.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The physical quantity from which the converted unit is derived.")]
		public IfcMeasureWithUnit ConversionFactor { get { return this._ConversionFactor; } set { this._ConversionFactor = value;} }
	
	
	}
	
}
