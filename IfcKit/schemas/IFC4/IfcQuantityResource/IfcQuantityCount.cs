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
	[Guid("ee55f63f-35e6-4be8-a374-c3e1d4aa9d1c")]
	public partial class IfcQuantityCount : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCountMeasure _CountValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Formula;
	
	
		[Description("Count measure value of this quantity.")]
		public IfcCountMeasure CountValue { get { return this._CountValue; } set { this._CountValue = value;} }
	
		[Description(@"A formula by which the quantity has been calculated. It can be assigned in addition to the actual value of the quantity. Formulas could be mathematic calculations (like width x height), database links, or a combination. The formula is for informational purposes only.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute added to the end of the attribute list.</blockquote>")]
		public IfcLabel? Formula { get { return this._Formula; } set { this._Formula = value;} }
	
	
	}
	
}
