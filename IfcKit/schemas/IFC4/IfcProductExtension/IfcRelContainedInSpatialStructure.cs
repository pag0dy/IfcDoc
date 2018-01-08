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
	[Guid("d85e2968-6220-4d4b-9e5d-3fcf794fea60")]
	public partial class IfcRelContainedInSpatialStructure : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcProduct> _RelatedElements = new HashSet<IfcProduct>();
	
		[DataMember(Order=1)] 
		[XmlIgnore]
		[Required()]
		IfcSpatialElement _RelatingStructure;
	
	
		[Description(@"Set of products, which are contained within this level of the spatial structure hierarchy.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcElement</em> to <em>IfcProduct</em> with upward compatibility</blockquote>
	")]
		public ISet<IfcProduct> RelatedElements { get { return this._RelatedElements; } }
	
		[Description(@"Spatial structure element, within which the element is contained. Any element can only be contained within one element of the project spatial structure.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute <em>RelatingStructure</em> as been promoted to the new supertype <em>IfcSpatialElement</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcSpatialElement RelatingStructure { get { return this._RelatingStructure; } set { this._RelatingStructure = value;} }
	
	
	}
	
}
