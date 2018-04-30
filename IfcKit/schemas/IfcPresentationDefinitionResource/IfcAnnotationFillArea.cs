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

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	public partial class IfcAnnotationFillArea : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  A closed curve that defines the outer boundary of the fill area. The areas defined by the outer boundary (minus potentially defined inner boundaries) is filled by the fill area style.  <blockquote><small><font color=\"#ff0000\">    IFC2x Edition 3 CHANGE&nbsp; The two new attributes <i>OuterBoundary</i> and <i>InnerBoundaries</i> replace the old single attribute Boundaries.  </font></small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcCurve OuterBoundary { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  A set of inner curves that define the inner boundaries of the fill area. The areas defined by the inner boundaries are excluded from applying the fill area style.  <blockquote><small><font color=\"#ff0000\">    IFC2x Edition 3 CHANGE&nbsp; The two new attributes <i>OuterBoundary</i> and <i>InnerBoundaries</i> replace the old single attribute Boundaries.  </font></small></blockquote>  </EPM-HTML>")]
		[MinLength(1)]
		public ISet<IfcCurve> InnerBoundaries { get; protected set; }
	
	
		public IfcAnnotationFillArea(IfcCurve __OuterBoundary, IfcCurve[] __InnerBoundaries)
		{
			this.OuterBoundary = __OuterBoundary;
			this.InnerBoundaries = new HashSet<IfcCurve>(__InnerBoundaries);
		}
	
	
	}
	
}
