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
	[Guid("818c820c-139e-4825-96bc-6c16e6f606d4")]
	public abstract partial class IfcFeatureElementAddition : IfcFeatureElement
	{
		[InverseProperty("RelatedFeatureElement")] 
		IfcRelProjectsElement _ProjectsElements;
	
	
		[Description(@"Reference to the <em>IfcRelProjectsElement</em> relationship that uses this <em>IfcFeatureElementAddition</em> to create a volume addition at an element. The <em>IfcFeatureElementAddition</em> can only be used to create a single addition at a single element using Boolean addition operation.")]
		public IfcRelProjectsElement ProjectsElements { get { return this._ProjectsElements; } set { this._ProjectsElements = value;} }
	
	
	}
	
}
