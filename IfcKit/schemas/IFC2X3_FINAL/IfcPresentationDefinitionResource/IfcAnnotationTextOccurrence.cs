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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationDimensioningResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("09b5e426-e43b-4a86-8459-3aa8e5589a53")]
	public partial class IfcAnnotationTextOccurrence : IfcAnnotationOccurrence,
		BuildingSmart.IFC.IfcPresentationDimensioningResource.IfcDraughtingCalloutElement
	{
	
		public IfcAnnotationTextOccurrence()
		{
		}
	
		public IfcAnnotationTextOccurrence(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name)
			: base(__Item, __Styles, __Name)
		{
		}
	
	
	}
	
}
