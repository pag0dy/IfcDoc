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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("cfe5f36c-5489-4523-98cb-705240b9ba86")]
	public partial class IfcBoundaryCurve : IfcCompositeCurveOnSurface
	{
	
		public IfcBoundaryCurve()
		{
		}
	
		public IfcBoundaryCurve(IfcCompositeCurveSegment[] __Segments, IfcLogical __SelfIntersect)
			: base(__Segments, __SelfIntersect)
		{
		}
	
	
	}
	
}
