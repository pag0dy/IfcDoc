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
	[Guid("2f5eefcc-2d23-4bbf-89e3-b10ffc7e8889")]
	public partial class IfcShapeRepresentation : IfcShapeModel
	{
	
		public IfcShapeRepresentation()
		{
		}
	
		public IfcShapeRepresentation(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
			: base(__ContextOfItems, __RepresentationIdentifier, __RepresentationType, __Items)
		{
		}
	
	
	}
	
}
