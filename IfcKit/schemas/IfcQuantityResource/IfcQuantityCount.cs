// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcQuantityCount : IfcPhysicalSimpleQuantity
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Count measure value of this quantity.")]
		[Required()]
		public IfcCountMeasure CountValue { get; set; }
	
	
		public IfcQuantityCount(IfcLabel __Name, IfcText? __Description, IfcNamedUnit __Unit, IfcCountMeasure __CountValue)
			: base(__Name, __Description, __Unit)
		{
			this.CountValue = __CountValue;
		}
	
	
	}
	
}
