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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public partial class IfcProductDefinitionShape : IfcProductRepresentation,
		BuildingSmart.IFC.IfcRepresentationResource.IfcProductRepresentationSelect
	{
		[InverseProperty("Representation")] 
		[Description("The <em>IfcProductDefinitionShape</em> shall be used to provide a representation for a single instance of <em>IfcProduct</em>.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE New inverse attribute.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE Inverse relationship cardinality relaxed to be 1:N.</blockquote>")]
		[MinLength(1)]
		public ISet<IfcProduct> ShapeOfProduct { get; protected set; }
	
		[InverseProperty("PartOfProductDefinitionShape")] 
		[XmlElement("IfcShapeAspect")]
		[Description("Reference to the shape aspect that represents part of the shape or its feature distinctively.")]
		public ISet<IfcShapeAspect> HasShapeAspects { get; protected set; }
	
	
		public IfcProductDefinitionShape(IfcLabel? __Name, IfcText? __Description, IfcRepresentation[] __Representations)
			: base(__Name, __Description, __Representations)
		{
			this.ShapeOfProduct = new HashSet<IfcProduct>();
			this.HasShapeAspects = new HashSet<IfcShapeAspect>();
		}
	
	
	}
	
}
