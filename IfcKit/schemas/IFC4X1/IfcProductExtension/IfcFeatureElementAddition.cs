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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("818c820c-139e-4825-96bc-6c16e6f606d4")]
	public abstract partial class IfcFeatureElementAddition : IfcFeatureElement
	{
		[InverseProperty("RelatedFeatureElement")] 
		IfcRelProjectsElement _ProjectsElements;
	
	
		public IfcFeatureElementAddition()
		{
		}
	
		public IfcFeatureElementAddition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
		}
	
		[Description(@"Reference to the <em>IfcRelProjectsElement</em> relationship that uses this <em>IfcFeatureElementAddition</em> to create a volume addition at an element. The <em>IfcFeatureElementAddition</em> can only be used to create a single addition at a single element using Boolean addition operation.")]
		public IfcRelProjectsElement ProjectsElements { get { return this._ProjectsElements; } set { this._ProjectsElements = value;} }
	
	
	}
	
}
