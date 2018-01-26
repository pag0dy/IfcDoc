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
	[Guid("3f24b989-aa9e-461e-b6d2-1dd3dabb466b")]
	public partial class IfcRationalBSplineCurveWithKnots : IfcBSplineCurveWithKnots
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		IList<IfcReal> _WeightsData = new List<IfcReal>();
	
	
		public IfcRationalBSplineCurveWithKnots()
		{
		}
	
		public IfcRationalBSplineCurveWithKnots(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect, IfcInteger[] __KnotMultiplicities, IfcParameterValue[] __Knots, IfcKnotType __KnotSpec, IfcReal[] __WeightsData)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect, __KnotMultiplicities, __Knots, __KnotSpec)
		{
			this._WeightsData = new List<IfcReal>(__WeightsData);
		}
	
		[Description("The supplied values of the weights.")]
		public IList<IfcReal> WeightsData { get { return this._WeightsData; } }
	
		public new IfcReal Weights { get { return new IfcReal(); } }
	
	
	}
	
}
