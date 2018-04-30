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
		[XmlElement]
		[Description("A closed curve that defines the outer boundary of the fill area. The areas defined by the outer boundary (minus potentially defined inner boundaries) is filled by the fill area style.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The two new attributes <em>OuterBoundary</em> and <em>InnerBoundaries</em> replace the old single attribute Boundaries.</blockquote>")]
		[Required()]
		public IfcCurve OuterBoundary { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A set of inner curves that define the inner boundaries of the fill area. The areas defined by the inner boundaries are excluded from applying the fill area style.  <blockquote class=\"note\">IFC2x3 CHANGE&nbsp; The two new attributes <em>OuterBoundary</em> and <em>InnerBoundaries</em> replace the old single attribute Boundaries.</blockquote>")]
		[MinLength(1)]
		public ISet<IfcCurve> InnerBoundaries { get; protected set; }
	
	
		public IfcAnnotationFillArea(IfcCurve __OuterBoundary, IfcCurve[] __InnerBoundaries)
		{
			this.OuterBoundary = __OuterBoundary;
			this.InnerBoundaries = new HashSet<IfcCurve>(__InnerBoundaries);
		}
	
	
	}
	
}
