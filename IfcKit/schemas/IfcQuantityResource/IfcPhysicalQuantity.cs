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
	public abstract partial class IfcPhysicalQuantity
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of the element quantity or measure. The name attribute has to be made recognizable by further agreements.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Further explanation that might be given to the quantity.")]
		public IfcText? Description { get; set; }
	
		[InverseProperty("HasQuantities")] 
		[Description("Reference to a physical complex quantity in which the physical quantity may be contained.")]
		[MaxLength(1)]
		public ISet<IfcPhysicalComplexQuantity> PartOfComplex { get; protected set; }
	
	
		protected IfcPhysicalQuantity(IfcLabel __Name, IfcText? __Description)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.PartOfComplex = new HashSet<IfcPhysicalComplexQuantity>();
		}
	
	
	}
	
}
