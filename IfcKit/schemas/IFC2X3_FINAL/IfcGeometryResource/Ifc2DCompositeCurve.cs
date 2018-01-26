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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("baa4bcb8-c619-4d13-afd6-b461e7c0267a")]
	public partial class Ifc2DCompositeCurve : IfcCompositeCurve
	{
	
		public Ifc2DCompositeCurve()
		{
		}
	
		public Ifc2DCompositeCurve(IfcCompositeCurveSegment[] __Segments, Boolean? __SelfIntersect)
			: base(__Segments, __SelfIntersect)
		{
		}
	
	
	}
	
}
