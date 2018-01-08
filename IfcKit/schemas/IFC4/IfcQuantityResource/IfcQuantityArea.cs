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
	[Guid("bb60eefd-5d19-4646-9795-6bda10980402")]
	public partial class IfcQuantityArea : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _AreaValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Formula;
	
	
		[Description("Area measure value of this quantity.")]
		public IfcAreaMeasure AreaValue { get { return this._AreaValue; } set { this._AreaValue = value;} }
	
		[Description(@"<EPM-HTML>
	A formula by which the quantity has been calculated. It can be assigned in addition to the actual value of the quantity. Formulas could be mathematic calculations (like width x height), database links, or a combination. The formula is for informational purposes only.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute added to the end of the attribute list.</blockquote>
	</EPM-HTML>")]
		public IfcLabel? Formula { get { return this._Formula; } set { this._Formula = value;} }
	
	
	}
	
}
