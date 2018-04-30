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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcRationalBSplineCurveWithKnots : IfcBSplineCurveWithKnots
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The supplied values of the weights.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcReal> WeightsData { get; protected set; }
	
	
		public IfcRationalBSplineCurveWithKnots(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect, IfcInteger[] __KnotMultiplicities, IfcParameterValue[] __Knots, IfcKnotType __KnotSpec, IfcReal[] __WeightsData)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect, __KnotMultiplicities, __Knots, __KnotSpec)
		{
			this.WeightsData = new List<IfcReal>(__WeightsData);
		}
	
		public new IfcReal Weights { get { return new IfcReal(); } }
	
	
	}
	
}
