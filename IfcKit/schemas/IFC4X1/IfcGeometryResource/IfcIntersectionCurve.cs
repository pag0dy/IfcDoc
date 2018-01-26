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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("2cdcc9f4-9e12-4da4-958c-a14cecfae81e")]
	public partial class IfcIntersectionCurve : IfcSurfaceCurve
	{
	
		public IfcIntersectionCurve()
		{
		}
	
		public IfcIntersectionCurve(IfcCurve __Curve3D, IfcPcurve[] __AssociatedGeometry, IfcPreferredSurfaceCurveRepresentation __MasterRepresentation)
			: base(__Curve3D, __AssociatedGeometry, __MasterRepresentation)
		{
		}
	
	
	}
	
}
