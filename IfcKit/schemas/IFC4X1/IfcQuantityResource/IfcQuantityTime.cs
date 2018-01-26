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
	[Guid("f137f056-3756-4b10-8243-deee1ffa7d9d")]
	public partial class IfcQuantityTime : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTimeMeasure _TimeValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Formula;
	
	
		public IfcQuantityTime()
		{
		}
	
		public IfcQuantityTime(IfcLabel __Name, IfcText? __Description, IfcNamedUnit __Unit, IfcTimeMeasure __TimeValue, IfcLabel? __Formula)
			: base(__Name, __Description, __Unit)
		{
			this._TimeValue = __TimeValue;
			this._Formula = __Formula;
		}
	
		[Description("Time measure value of this quantity.")]
		public IfcTimeMeasure TimeValue { get { return this._TimeValue; } set { this._TimeValue = value;} }
	
		[Description(@"A formula by which the quantity has been calculated. It can be assigned in addition to the actual value of the quantity. Formulas could be mathematic calculations (like width x height), database links, or a combination. The formula is for informational purposes only.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute added to the end of the attribute list.</blockquote>")]
		public IfcLabel? Formula { get { return this._Formula; } set { this._Formula = value;} }
	
	
	}
	
}
