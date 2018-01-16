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
	[Guid("8fb0f854-b0cd-4aef-8628-2c6cb459a979")]
	public partial class IfcSIUnit : IfcNamedUnit
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSIPrefix? _Prefix;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcSIUnitName _Name;
	
	
		[Description("The SI Prefix for defining decimal multiples and submultiples of the unit.")]
		public IfcSIPrefix? Prefix { get { return this._Prefix; } set { this._Prefix = value;} }
	
		[Description("The word, or group of words, by which the SI unit is referred to.")]
		public IfcSIUnitName Name { get { return this._Name; } set { this._Name = value;} }
	
		public new IfcDimensionalExponents Dimensions { get { return null; } }
	
	
	}
	
}
