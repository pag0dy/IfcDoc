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
	[Guid("693040e6-1419-4534-8da8-c9b5f860d52b")]
	public abstract partial class IfcBSplineCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		Int64 _Degree;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(2)]
		IList<IfcCartesianPoint> _ControlPointsList = new List<IfcCartesianPoint>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBSplineCurveForm _CurveForm;
	
		[DataMember(Order=3)] 
		[Required()]
		Boolean? _ClosedCurve;
	
		[DataMember(Order=4)] 
		[Required()]
		Boolean? _SelfIntersect;
	
	
		public IfcBSplineCurve()
		{
		}
	
		public IfcBSplineCurve(Int64 __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, Boolean? __ClosedCurve, Boolean? __SelfIntersect)
		{
			this._Degree = __Degree;
			this._ControlPointsList = new List<IfcCartesianPoint>(__ControlPointsList);
			this._CurveForm = __CurveForm;
			this._ClosedCurve = __ClosedCurve;
			this._SelfIntersect = __SelfIntersect;
		}
	
		[Description("The algebraic degree of the basis functions.")]
		public Int64 Degree { get { return this._Degree; } set { this._Degree = value;} }
	
		[Description("The list of control points for the curve.")]
		public IList<IfcCartesianPoint> ControlPointsList { get { return this._ControlPointsList; } }
	
		[Description("Used to identify particular types of curve; it is for information only.")]
		public IfcBSplineCurveForm CurveForm { get { return this._CurveForm; } set { this._CurveForm = value;} }
	
		[Description("Indication of whether the curve is closed; it is for information only.")]
		public Boolean? ClosedCurve { get { return this._ClosedCurve; } set { this._ClosedCurve = value;} }
	
		[Description("Indication whether the curve self-intersects or not; it is for information only.")]
		public Boolean? SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
		public new IfcCartesianPoint ControlPoints { get { return null; } }
	
		public new Int64 UpperIndexOnControlPoints { get { return 0; } }
	
	
	}
	
}
