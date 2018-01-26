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
	[Guid("b95f48a3-6b56-4eb3-90bf-c76eea036d6f")]
	public partial class IfcSeamCurve : IfcSurfaceCurve
	{
	
		public IfcSeamCurve()
		{
		}
	
		public IfcSeamCurve(IfcCurve __Curve3D, IfcPcurve[] __AssociatedGeometry, IfcPreferredSurfaceCurveRepresentation __MasterRepresentation)
			: base(__Curve3D, __AssociatedGeometry, __MasterRepresentation)
		{
		}
	
	
	}
	
}
