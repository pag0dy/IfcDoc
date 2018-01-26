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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("6c23b448-71b0-4236-9351-383aca8d452c")]
	public partial class IfcAdvancedFace : IfcFaceSurface
	{
	
		public IfcAdvancedFace()
		{
		}
	
		public IfcAdvancedFace(IfcFaceBound[] __Bounds, IfcSurface __FaceSurface, IfcBoolean __SameSense)
			: base(__Bounds, __FaceSurface, __SameSense)
		{
		}
	
	
	}
	
}
