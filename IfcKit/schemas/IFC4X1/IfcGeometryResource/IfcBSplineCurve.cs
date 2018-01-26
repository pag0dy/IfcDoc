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
	[Guid("b9435164-1687-4e0f-8afc-85feadf601cd")]
	public abstract partial class IfcBSplineCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _Degree;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(2)]
		IList<IfcCartesianPoint> _ControlPointsList = new List<IfcCartesianPoint>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBSplineCurveForm _CurveForm;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _ClosedCurve;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _SelfIntersect;
	
	
		public IfcBSplineCurve()
		{
		}
	
		public IfcBSplineCurve(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect)
		{
			this._Degree = __Degree;
			this._ControlPointsList = new List<IfcCartesianPoint>(__ControlPointsList);
			this._CurveForm = __CurveForm;
			this._ClosedCurve = __ClosedCurve;
			this._SelfIntersect = __SelfIntersect;
		}
	
		[Description("The algebraic degree of the basis functions.")]
		public IfcInteger Degree { get { return this._Degree; } set { this._Degree = value;} }
	
		[Description("The list of control points for the curve.")]
		public IList<IfcCartesianPoint> ControlPointsList { get { return this._ControlPointsList; } }
	
		[Description("Used to identify particular types of curve; it is for information only.")]
		public IfcBSplineCurveForm CurveForm { get { return this._CurveForm; } set { this._CurveForm = value;} }
	
		[Description("Indication of whether the curve is closed; it is for information only.")]
		public IfcLogical ClosedCurve { get { return this._ClosedCurve; } set { this._ClosedCurve = value;} }
	
		[Description("Indication whether the curve self-intersects or not; it is for information only.")]
		public IfcLogical SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
		public new IfcInteger UpperIndexOnControlPoints { get { return new IfcInteger(); } }
	
		public new IfcCartesianPoint ControlPoints { get { return null; } }
	
	
	}
	
}
