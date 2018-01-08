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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("7acedf96-0cb4-4829-86d1-d848d4577671")]
	public partial class IfcAnnotationFillArea : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCurve")]
		[Required()]
		IfcCurve _OuterBoundary;
	
		[DataMember(Order=1)] 
		ISet<IfcCurve> _InnerBoundaries = new HashSet<IfcCurve>();
	
	
		[Description(@"A closed curve that defines the outer boundary of the fill area. The areas defined by the outer boundary (minus potentially defined inner boundaries) is filled by the fill area style.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The two new attributes <em>OuterBoundary</em> and <em>InnerBoundaries</em> replace the old single attribute Boundaries.</blockquote>")]
		public IfcCurve OuterBoundary { get { return this._OuterBoundary; } set { this._OuterBoundary = value;} }
	
		[Description(@"A set of inner curves that define the inner boundaries of the fill area. The areas defined by the inner boundaries are excluded from applying the fill area style.
	<blockquote class=""note"">IFC2x3 CHANGE&nbsp; The two new attributes <em>OuterBoundary</em> and <em>InnerBoundaries</em> replace the old single attribute Boundaries.</blockquote>")]
		public ISet<IfcCurve> InnerBoundaries { get { return this._InnerBoundaries; } }
	
	
	}
	
}
