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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcQuantityResource
{
	[Guid("b2c313f2-5299-4b30-b6d0-a7ea6fbf1b83")]
	public partial class IfcQuantityWeight : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcMassMeasure _WeightValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Formula;
	
	
		[Description("Mass measure value of this quantity.")]
		public IfcMassMeasure WeightValue { get { return this._WeightValue; } set { this._WeightValue = value;} }
	
		[Description(@"A formula by which the quantity has been calculated. It can be assigned in addition to the actual value of the quantity. Formulas could be mathematic calculations (like width x height), database links, or a combination. The formula is for informational purposes only.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute added to the end of the attribute list.</blockquote>")]
		public IfcLabel? Formula { get { return this._Formula; } set { this._Formula = value;} }
	
	
	}
	
}
