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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("ba246ca4-84c8-436f-8964-9d288e492ad4")]
	public partial class IfcProductDefinitionShape : IfcProductRepresentation,
		BuildingSmart.IFC.IfcRepresentationResource.IfcProductRepresentationSelect
	{
		[InverseProperty("Representation")] 
		ISet<IfcProduct> _ShapeOfProduct = new HashSet<IfcProduct>();
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		[XmlElement]
		ISet<IfcShapeAspect> _HasShapeAspects = new HashSet<IfcShapeAspect>();
	
	
		[Description(@"The <em>IfcProductDefinitionShape</em> shall be used to provide a representation for a single instance of <em>IfcProduct</em>.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE New inverse attribute.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE Inverse relationship cardinality relaxed to be 1:N.</blockquote>")]
		public ISet<IfcProduct> ShapeOfProduct { get { return this._ShapeOfProduct; } }
	
		[Description("Reference to the shape aspect that represents part of the shape or its feature di" +
	    "stinctively.")]
		public ISet<IfcShapeAspect> HasShapeAspects { get { return this._HasShapeAspects; } }
	
	
	}
	
}
