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
	[Guid("c2cc1d04-121f-49bb-9e9e-2578ff7811ef")]
	public partial class IfcTopologyRepresentation : IfcShapeModel
	{
	
		public IfcTopologyRepresentation()
		{
		}
	
		public IfcTopologyRepresentation(IfcRepresentationContext __ContextOfItems, IfcLabel? __RepresentationIdentifier, IfcLabel? __RepresentationType, IfcRepresentationItem[] __Items)
			: base(__ContextOfItems, __RepresentationIdentifier, __RepresentationType, __Items)
		{
		}
	
	
	}
	
}
