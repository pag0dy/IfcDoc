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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("81a4cca3-7170-44c2-95ec-7a697d45e647")]
	public partial class IfcMaterialDefinitionRepresentation : IfcProductRepresentation
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcMaterial _RepresentedMaterial;
	
	
		[Description("Reference to the material to which the representation applies.")]
		public IfcMaterial RepresentedMaterial { get { return this._RepresentedMaterial; } set { this._RepresentedMaterial = value;} }
	
	
	}
	
}
