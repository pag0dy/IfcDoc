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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("f1e9cf21-4f13-485c-a608-e1f0beac34f7")]
	public partial class IfcElementQuantity : IfcQuantitySet
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _MethodOfMeasurement;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcPhysicalQuantity> _Quantities = new HashSet<IfcPhysicalQuantity>();
	
	
		public IfcElementQuantity()
		{
		}
	
		public IfcElementQuantity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __MethodOfMeasurement, IfcPhysicalQuantity[] __Quantities)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._MethodOfMeasurement = __MethodOfMeasurement;
			this._Quantities = new HashSet<IfcPhysicalQuantity>(__Quantities);
		}
	
		[Description(@"Name of the method of measurement used to calculate the element quantity. The method of measurement attribute has to be made recognizable by further agreements.
	
	<blockquote class=""change-ifc2x2"">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </blockquote>")]
		public IfcLabel? MethodOfMeasurement { get { return this._MethodOfMeasurement; } set { this._MethodOfMeasurement = value;} }
	
		[Description("The individual quantities for the element, can be a set of length, area, volume, " +
	    "weight or count based quantities.")]
		public ISet<IfcPhysicalQuantity> Quantities { get { return this._Quantities; } }
	
	
	}
	
}
