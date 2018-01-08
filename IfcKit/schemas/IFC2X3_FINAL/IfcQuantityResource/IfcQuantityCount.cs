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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("f83ba5c9-2e9e-45c0-b512-867a448a5a2b")]
	public partial class IfcQuantityCount : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCountMeasure _CountValue;
	
	
		[Description("Count measure value of this quantity.")]
		public IfcCountMeasure CountValue { get { return this._CountValue; } set { this._CountValue = value;} }
	
	
	}
	
}
