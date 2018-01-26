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
	[Guid("33d227e6-5f5f-4564-83b9-c46f7a472385")]
	public partial class IfcRationalBezierCurve : IfcBezierCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(2)]
		IList<Double> _WeightsData = new List<Double>();
	
	
		public IfcRationalBezierCurve()
		{
		}
	
		public IfcRationalBezierCurve(Int64 __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, Boolean? __ClosedCurve, Boolean? __SelfIntersect, Double[] __WeightsData)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect)
		{
			this._WeightsData = new List<Double>(__WeightsData);
		}
	
		[Description("The supplied values of the weights.")]
		public IList<Double> WeightsData { get { return this._WeightsData; } }
	
		public new Double Weights { get { return null; } }
	
	
	}
	
}
