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
	[Guid("bae52a64-1034-464e-8c4d-a00aa45bafa0")]
	public partial class IfcRelSpaceBoundary1stLevel : IfcRelSpaceBoundary
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcRelSpaceBoundary1stLevel _ParentBoundary;
	
		[InverseProperty("ParentBoundary")] 
		ISet<IfcRelSpaceBoundary1stLevel> _InnerBoundaries = new HashSet<IfcRelSpaceBoundary1stLevel>();
	
	
		[Description("Reference to the host, or parent, space boundary within which this inner boundary" +
	    " is defined.")]
		public IfcRelSpaceBoundary1stLevel ParentBoundary { get { return this._ParentBoundary; } set { this._ParentBoundary = value;} }
	
		[Description("Reference to the inner boundaries of the space boundary. Inner boundaries are def" +
	    "ined by the space boundaries of openings, doors and windows.")]
		public ISet<IfcRelSpaceBoundary1stLevel> InnerBoundaries { get { return this._InnerBoundaries; } }
	
	
	}
	
}
