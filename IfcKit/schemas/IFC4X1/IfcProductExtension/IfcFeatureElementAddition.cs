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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("6fc15ef2-60b4-4c45-a80f-88e9e7f1c2fe")]
	public abstract partial class IfcFeatureElementAddition : IfcFeatureElement
	{
		[InverseProperty("RelatedFeatureElement")] 
		IfcRelProjectsElement _ProjectsElements;
	
	
		[Description(@"<EPM-HTML>
	Reference to the <I>IfcRelProjectsElement</I> relationship that uses this <I>IfcFeatureElementAddition</I> to create a volume addition at an element. The <I>IfcFeatureElementAddition</I> can only be used to create a single addition at a single element using Boolean addition operation.
	</EPM-HTML>")]
		public IfcRelProjectsElement ProjectsElements { get { return this._ProjectsElements; } set { this._ProjectsElements = value;} }
	
	
	}
	
}
