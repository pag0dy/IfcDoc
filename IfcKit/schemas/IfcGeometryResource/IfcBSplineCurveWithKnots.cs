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
	public partial class IfcBSplineCurveWithKnots : IfcBSplineCurve
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The multiplicities of the knots. This list defines the number of times each knot in the knots list is to be repeated in constructing the knot array.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcInteger> KnotMultiplicities { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The list of distinct knots used to define the B-spline basis functions.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcParameterValue> Knots { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The description of the knot type. This is for information only.")]
		[Required()]
		public IfcKnotType KnotSpec { get; set; }
	
	
		public IfcBSplineCurveWithKnots(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect, IfcInteger[] __KnotMultiplicities, IfcParameterValue[] __Knots, IfcKnotType __KnotSpec)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect)
		{
			this.KnotMultiplicities = new List<IfcInteger>(__KnotMultiplicities);
			this.Knots = new List<IfcParameterValue>(__Knots);
			this.KnotSpec = __KnotSpec;
		}
	
		public new IfcInteger UpperIndexOnKnots { get { return new IfcInteger(); } }
	
	
	}
	
}
