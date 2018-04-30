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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcRationalBezierCurve : IfcBezierCurve
	{
		[DataMember(Order = 0)] 
		[Description("The supplied values of the weights.")]
		[Required()]
		[MinLength(2)]
		public IList<Double> WeightsData { get; protected set; }
	
	
		public IfcRationalBezierCurve(Int64 __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, Boolean? __ClosedCurve, Boolean? __SelfIntersect, Double[] __WeightsData)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect)
		{
			this.WeightsData = new List<Double>(__WeightsData);
		}
	
		public new Double Weights { get { return null; } }
	
	
	}
	
}
