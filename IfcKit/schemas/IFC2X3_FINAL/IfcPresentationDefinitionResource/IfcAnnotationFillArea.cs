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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("2f781e34-dcc4-479d-88c0-9754f62695f4")]
	public partial class IfcAnnotationFillArea : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _OuterBoundary;
	
		[DataMember(Order=1)] 
		ISet<IfcCurve> _InnerBoundaries = new HashSet<IfcCurve>();
	
	
		[Description(@"<EPM-HTML>
	A closed curve that defines the outer boundary of the fill area. The areas defined by the outer boundary (minus potentially defined inner boundaries) is filled by the fill area style.
	<blockquote><small><font color=""#ff0000"">
	  IFC2x Edition 3 CHANGE&nbsp; The two new attributes <i>OuterBoundary</i> and <i>InnerBoundaries</i> replace the old single attribute Boundaries.
	</font></small></blockquote>
	</EPM-HTML>")]
		public IfcCurve OuterBoundary { get { return this._OuterBoundary; } set { this._OuterBoundary = value;} }
	
		[Description(@"<EPM-HTML>
	A set of inner curves that define the inner boundaries of the fill area. The areas defined by the inner boundaries are excluded from applying the fill area style.
	<blockquote><small><font color=""#ff0000"">
	  IFC2x Edition 3 CHANGE&nbsp; The two new attributes <i>OuterBoundary</i> and <i>InnerBoundaries</i> replace the old single attribute Boundaries.
	</font></small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcCurve> InnerBoundaries { get { return this._InnerBoundaries; } }
	
	
	}
	
}
