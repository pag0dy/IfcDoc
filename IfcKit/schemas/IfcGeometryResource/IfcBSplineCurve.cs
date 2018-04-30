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
	public abstract partial class IfcBSplineCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[Description("The algebraic degree of the basis functions.")]
		[Required()]
		public Int64 Degree { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The list of control points for the curve.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcCartesianPoint> ControlPointsList { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Used to identify particular types of curve; it is for information only.")]
		[Required()]
		public IfcBSplineCurveForm CurveForm { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Indication of whether the curve is closed; it is for information only.")]
		[Required()]
		public Boolean? ClosedCurve { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Indication whether the curve self-intersects or not; it is for information only.")]
		[Required()]
		public Boolean? SelfIntersect { get; set; }
	
	
		protected IfcBSplineCurve(Int64 __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, Boolean? __ClosedCurve, Boolean? __SelfIntersect)
		{
			this.Degree = __Degree;
			this.ControlPointsList = new List<IfcCartesianPoint>(__ControlPointsList);
			this.CurveForm = __CurveForm;
			this.ClosedCurve = __ClosedCurve;
			this.SelfIntersect = __SelfIntersect;
		}
	
		public new IfcCartesianPoint ControlPoints { get { return null; } }
	
		public new Int64 UpperIndexOnControlPoints { get { return null; } }
	
	
	}
	
}
