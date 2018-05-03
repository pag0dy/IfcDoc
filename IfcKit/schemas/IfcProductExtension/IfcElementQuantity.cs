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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcElementQuantity : IfcQuantitySet
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of the method of measurement used to calculate the element quantity. The method of measurement attribute has to be made recognizable by further agreements.    <blockquote class=\"change-ifc2x2\">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </blockquote>")]
		public IfcLabel? MethodOfMeasurement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The individual quantities for the element, can be a set of length, area, volume, weight or count based quantities.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPhysicalQuantity> Quantities { get; protected set; }
	
	
		public IfcElementQuantity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __MethodOfMeasurement, IfcPhysicalQuantity[] __Quantities)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.MethodOfMeasurement = __MethodOfMeasurement;
			this.Quantities = new HashSet<IfcPhysicalQuantity>(__Quantities);
		}
	
	
	}
	
}
