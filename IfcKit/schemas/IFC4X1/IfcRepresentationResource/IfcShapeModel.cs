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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcRepresentationResource
{
	[Guid("96fc3c5f-dd42-4a80-aea3-295fbe743fa9")]
	public abstract partial class IfcShapeModel : IfcRepresentation
	{
		[InverseProperty("ShapeRepresentations")] 
		[MaxLength(1)]
		ISet<IfcShapeAspect> _OfShapeAspect = new HashSet<IfcShapeAspect>();
	
	
		public IfcShapeModel()
		{
		}
	
		public IfcShapeModel(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
			: base(__ContextOfItems, __RepresentationIdentifier, __RepresentationType, __Items)
		{
		}
	
		[Description("Reference to the shape aspect, for which it is the shape representation.")]
		public ISet<IfcShapeAspect> OfShapeAspect { get { return this._OfShapeAspect; } }
	
	
	}
	
}
