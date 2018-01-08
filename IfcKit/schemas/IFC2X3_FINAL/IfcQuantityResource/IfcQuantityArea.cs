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
	[Guid("920900b8-14ac-46d6-be66-5fb04844b48f")]
	public partial class IfcQuantityArea : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _AreaValue;
	
	
		[Description("Area measure value of this quantity.")]
		public IfcAreaMeasure AreaValue { get { return this._AreaValue; } set { this._AreaValue = value;} }
	
	
	}
	
}
