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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("265c053c-a8de-43da-8a2e-ae2adf80fad6")]
	public partial class IfcPolygonalBoundedHalfSpace : IfcHalfSpaceSolid
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement3D _Position;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcBoundedCurve _PolygonalBoundary;
	
	
		public IfcPolygonalBoundedHalfSpace()
		{
		}
	
		public IfcPolygonalBoundedHalfSpace(IfcSurface __BaseSurface, Boolean __AgreementFlag, IfcAxis2Placement3D __Position, IfcBoundedCurve __PolygonalBoundary)
			: base(__BaseSurface, __AgreementFlag)
		{
			this._Position = __Position;
			this._PolygonalBoundary = __PolygonalBoundary;
		}
	
		[Description("<EPM-HTML>\r\n<P>Definition of the position coordinate system for the bounding poly" +
	    "line <STRIKE>and the base surface</STRIKE>.</P>\r\n</EPM-HTML>")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
		[Description(@"<EPM-HTML>
	Two-dimensional <strike>polyline</strike> bounded curve, defined in the xy plane of the position coordinate system.
	<blockquote><small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute type has been changed from <i>IfcPolyline</i> to its supertype <i>IfcBoundedCurve</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>")]
		public IfcBoundedCurve PolygonalBoundary { get { return this._PolygonalBoundary; } set { this._PolygonalBoundary = value;} }
	
	
	}
	
}
