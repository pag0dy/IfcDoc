// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcSeamCurve : IfcSurfaceCurve
	{
	
		public IfcSeamCurve(IfcCurve __Curve3D, IfcPcurve[] __AssociatedGeometry, IfcPreferredSurfaceCurveRepresentation __MasterRepresentation)
			: base(__Curve3D, __AssociatedGeometry, __MasterRepresentation)
		{
		}
	
	
	}
	
}
