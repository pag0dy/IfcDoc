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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

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
		ISet<IfcPhysicalQuantity> _Quantities = new HashSet<IfcPhysicalQuantity>();
	
	
		[Description(@"<EPM-HTML>Name of the method of measurement used to calculate the element quantity. The method of measurement attribute has to be made recognizable by further agreements.
	
	<blockquote class=""change-ifc2x2"">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </blockquote>
	</EPM-HTML>")]
		public IfcLabel? MethodOfMeasurement { get { return this._MethodOfMeasurement; } set { this._MethodOfMeasurement = value;} }
	
		[Description("The individual quantities for the element, can be a set of length, area, volume, " +
	    "weight or count based quantities.")]
		public ISet<IfcPhysicalQuantity> Quantities { get { return this._Quantities; } }
	
	
	}
	
}
