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
	[Guid("5cf374d3-9550-4d89-8870-9e50d9d4d7f6")]
	public partial class IfcBSplineCurveWithKnots : IfcBSplineCurve
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		IList<IfcInteger> _KnotMultiplicities = new List<IfcInteger>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		IList<IfcParameterValue> _Knots = new List<IfcParameterValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcKnotType _KnotSpec;
	
	
		public IfcBSplineCurveWithKnots()
		{
		}
	
		public IfcBSplineCurveWithKnots(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect, IfcInteger[] __KnotMultiplicities, IfcParameterValue[] __Knots, IfcKnotType __KnotSpec)
			: base(__Degree, __ControlPointsList, __CurveForm, __ClosedCurve, __SelfIntersect)
		{
			this._KnotMultiplicities = new List<IfcInteger>(__KnotMultiplicities);
			this._Knots = new List<IfcParameterValue>(__Knots);
			this._KnotSpec = __KnotSpec;
		}
	
		[Description("The multiplicities of the knots. This list defines the number of times each knot " +
	    "in the knots list is to be repeated in constructing the knot array.")]
		public IList<IfcInteger> KnotMultiplicities { get { return this._KnotMultiplicities; } }
	
		[Description("The list of distinct knots used to define the B-spline basis functions.")]
		public IList<IfcParameterValue> Knots { get { return this._Knots; } }
	
		[Description("The description of the knot type. This is for information only.")]
		public IfcKnotType KnotSpec { get { return this._KnotSpec; } set { this._KnotSpec = value;} }
	
		public new IfcInteger UpperIndexOnKnots { get { return new IfcInteger(); } }
	
	
	}
	
}
