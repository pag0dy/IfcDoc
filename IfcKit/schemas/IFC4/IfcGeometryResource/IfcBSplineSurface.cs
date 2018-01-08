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
		[Required()]
		Int64 _UDegree;
	
		[DataMember(Order=1)] 
		[Required()]
		Int64 _VDegree;
	
		[DataMember(Order=2)] 
		[XmlElement]
		[Required()]
		IList<IfcCartesianPoint> _ControlPointsList = new List<IfcCartesianPoint>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcBSplineSurfaceForm _SurfaceForm;
	
		[DataMember(Order=4)] 
		[Required()]
		Boolean? _UClosed;
	
		[DataMember(Order=5)] 
		[Required()]
		Boolean? _VClosed;
	
		[DataMember(Order=6)] 
		[Required()]
		Boolean? _SelfIntersect;
	
	
		[Description("<EPM-HTML>\r\nAlgebraic degree of basis functions in <em>u</em>.\r\n</EPM-HTML>")]
		public Int64 UDegree { get { return this._UDegree; } set { this._UDegree = value;} }
	
		[Description("<EPM-HTML>\r\nAlgebraic degree of basis functions in <em>v</em>.\r\n</EPM-HTML>")]
		public Int64 VDegree { get { return this._VDegree; } set { this._VDegree = value;} }
	
		[Description("<EPM-HTML>\r\nThis is a list of lists of control points.\r\n</EPM-HTML>")]
		public IList<IfcCartesianPoint> ControlPointsList { get { return this._ControlPointsList; } }
	
		[Description("<EPM-HTML>\r\nIndicator of special surface types.\r\n</EPM-HTML>")]
		public IfcBSplineSurfaceForm SurfaceForm { get { return this._SurfaceForm; } set { this._SurfaceForm = value;} }
	
		[Description("<EPM-HTML>\r\nIndication of whether the surface is closed in the <em>u</em> directi" +
	    "on; this is for information only.\r\n</EPM-HTML>")]
		public Boolean? UClosed { get { return this._UClosed; } set { this._UClosed = value;} }
	
		[Description("<EPM-HTML>\r\nIndication of whether the surface is closed in the <em>v</em> directi" +
	    "on; this is for information only.\r\n</EPM-HTML>")]
		public Boolean? VClosed { get { return this._VClosed; } set { this._VClosed = value;} }
	
		[Description("<EPM-HTML>\r\nFlag to indicate whether, or not, surface is self-intersecting; this " +
	    "is for information only.\r\n</EPM-HTML>")]
		public Boolean? SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
	
	}
	
}
