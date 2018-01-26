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
	[Guid("9111d989-dc8b-4024-8445-6c07f4d319e2")]
	public partial class IfcAnnotationCurveOccurrence : IfcAnnotationOccurrence,
		BuildingSmart.IFC.IfcPresentationDimensioningResource.IfcDraughtingCalloutElement
	{
	
		public IfcAnnotationCurveOccurrence()
		{
		}
	
		public IfcAnnotationCurveOccurrence(IfcRepresentationItem __Item, IfcPresentationStyleAssignment[] __Styles, IfcLabel? __Name)
			: base(__Item, __Styles, __Name)
		{
		}
	
	
	}
	
}
