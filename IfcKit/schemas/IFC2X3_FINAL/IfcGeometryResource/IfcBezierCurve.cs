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
	[Guid("7a38518c-4644-4c92-a76d-62b537919702")]
	public partial class IfcBezierCurve : IfcBSplineCurve
	{
	
		public IfcBezierCurve()
		{
		}
	
		public IfcBezierCurve(Int64 __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, Boolean? __ClosedCurve, Boolean? __SelfIntersect)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect)
		{
		}
	
	
	}
	
}
