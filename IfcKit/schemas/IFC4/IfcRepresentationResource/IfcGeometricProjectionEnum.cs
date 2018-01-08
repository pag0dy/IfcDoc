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
	[Guid("32a77a31-87a4-4a61-8043-df1ff5a038e2")]
	public enum IfcGeometricProjectionEnum
	{
		GRAPH_VIEW = 1,
	
		SKETCH_VIEW = 2,
	
		MODEL_VIEW = 3,
	
		PLAN_VIEW = 4,
	
		REFLECTED_PLAN_VIEW = 5,
	
		SECTION_VIEW = 6,
	
		ELEVATION_VIEW = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
