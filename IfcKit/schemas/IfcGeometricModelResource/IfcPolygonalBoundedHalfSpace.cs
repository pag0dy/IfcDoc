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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcPolygonalBoundedHalfSpace : IfcHalfSpaceSolid
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  <P>Definition of the position coordinate system for the bounding polyline <STRIKE>and the base surface</STRIKE>.</P>  </EPM-HTML>")]
		[Required()]
		public IfcAxis2Placement3D Position { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  Two-dimensional <strike>polyline</strike> bounded curve, defined in the xy plane of the position coordinate system.  <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute type has been changed from <i>IfcPolyline</i> to its supertype <i>IfcBoundedCurve</i> with upward compatibility for file based exchange.  </font></small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcBoundedCurve PolygonalBoundary { get; set; }
	
	
		public IfcPolygonalBoundedHalfSpace(IfcSurface __BaseSurface, Boolean __AgreementFlag, IfcAxis2Placement3D __Position, IfcBoundedCurve __PolygonalBoundary)
			: base(__BaseSurface, __AgreementFlag)
		{
			this.Position = __Position;
			this.PolygonalBoundary = __PolygonalBoundary;
		}
	
	
	}
	
}
