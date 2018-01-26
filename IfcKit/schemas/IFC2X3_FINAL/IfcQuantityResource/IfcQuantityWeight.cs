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
	[Guid("3112a0f9-e07b-4712-abad-9576ad39a1e2")]
	public partial class IfcQuantityWeight : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcMassMeasure _WeightValue;
	
	
		public IfcQuantityWeight()
		{
		}
	
		public IfcQuantityWeight(IfcLabel __Name, IfcText? __Description, IfcNamedUnit __Unit, IfcMassMeasure __WeightValue)
			: base(__Name, __Description, __Unit)
		{
			this._WeightValue = __WeightValue;
		}
	
		[Description("Mass measure value of this quantity.")]
		public IfcMassMeasure WeightValue { get { return this._WeightValue; } set { this._WeightValue = value;} }
	
	
	}
	
}
