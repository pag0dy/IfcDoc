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
	public abstract partial class IfcBSplineCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The algebraic degree of the basis functions.")]
		[Required()]
		public IfcInteger Degree { get; set; }
	
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
		[XmlAttribute]
		[Description("Indication of whether the curve is closed; it is for information only.")]
		[Required()]
		public IfcLogical ClosedCurve { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Indication whether the curve self-intersects or not; it is for information only.")]
		[Required()]
		public IfcLogical SelfIntersect { get; set; }
	
	
		protected IfcBSplineCurve(IfcInteger __Degree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineCurveForm __CurveForm, IfcLogical __ClosedCurve, IfcLogical __SelfIntersect)
		{
			this.Degree = __Degree;
			this.ControlPointsList = new List<IfcCartesianPoint>(__ControlPointsList);
			this.CurveForm = __CurveForm;
			this.ClosedCurve = __ClosedCurve;
			this.SelfIntersect = __SelfIntersect;
		}
	
		public new IfcInteger UpperIndexOnControlPoints { get { return new IfcInteger(); } }
	
		public new IfcCartesianPoint ControlPoints { get { return null; } }
	
	
	}
	
}
