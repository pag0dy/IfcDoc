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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("6cc49723-24d6-446e-b2cc-fef52a6229c4")]
	public abstract partial class IfcBSplineSurface : IfcBoundedSurface
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _UDegree;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcInteger _VDegree;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcCartesianPoint")]
		[Required()]
		IList<IfcCartesianPoint> _ControlPointsList = new List<IfcCartesianPoint>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcBSplineSurfaceForm _SurfaceForm;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _UClosed;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _VClosed;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcLogical _SelfIntersect;
	
	
		[Description("Algebraic degree of basis functions in <em>u</em>.")]
		public IfcInteger UDegree { get { return this._UDegree; } set { this._UDegree = value;} }
	
		[Description("Algebraic degree of basis functions in <em>v</em>.")]
		public IfcInteger VDegree { get { return this._VDegree; } set { this._VDegree = value;} }
	
		[Description("This is a list of lists of control points.")]
		public IList<IfcCartesianPoint> ControlPointsList { get { return this._ControlPointsList; } }
	
		[Description("Indicator of special surface types.")]
		public IfcBSplineSurfaceForm SurfaceForm { get { return this._SurfaceForm; } set { this._SurfaceForm = value;} }
	
		[Description("Indication of whether the surface is closed in the <em>u</em> direction; this is " +
	    "for information only.")]
		public IfcLogical UClosed { get { return this._UClosed; } set { this._UClosed = value;} }
	
		[Description("Indication of whether the surface is closed in the <em>v</em> direction; this is " +
	    "for information only.")]
		public IfcLogical VClosed { get { return this._VClosed; } set { this._VClosed = value;} }
	
		[Description("Flag to indicate whether, or not, surface is self-intersecting; this is for infor" +
	    "mation only.")]
		public IfcLogical SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
		public new IfcInteger UUpper { get { return new IfcInteger(); } }
	
		public new IfcInteger VUpper { get { return new IfcInteger(); } }
	
		public new IfcCartesianPoint ControlPoints { get { return null; } }
	
	
	}
	
}
