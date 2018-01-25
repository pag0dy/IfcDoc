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
	[Guid("002bda71-0a52-40b9-8ef9-82bc20f96bf3")]
	public partial class IfcRelSpaceBoundary2ndLevel : IfcRelSpaceBoundary1stLevel
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcRelSpaceBoundary2ndLevel _CorrespondingBoundary;
	
		[InverseProperty("CorrespondingBoundary")] 
		ISet<IfcRelSpaceBoundary2ndLevel> _Corresponds = new HashSet<IfcRelSpaceBoundary2ndLevel>();
	
	
		[Description("Reference to the other space boundary of the pair of two space boundaries on eith" +
	    "er side of a space separating thermal boundary element.")]
		public IfcRelSpaceBoundary2ndLevel CorrespondingBoundary { get { return this._CorrespondingBoundary; } set { this._CorrespondingBoundary = value;} }
	
		[Description("Reference to the other space boundary of the pair of two space boundaries on eith" +
	    "er side of a space separating thermal boundary element.")]
		public ISet<IfcRelSpaceBoundary2ndLevel> Corresponds { get { return this._Corresponds; } }
	
	
	}
	
}
