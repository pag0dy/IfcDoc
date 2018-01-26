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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("e2cb0b42-4bee-4e18-9873-866d91f4e4fd")]
	public partial class IfcExternallyDefinedSurfaceStyle : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
	
		public IfcExternallyDefinedSurfaceStyle()
		{
		}
	
		public IfcExternallyDefinedSurfaceStyle(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name)
			: base(__Location, __Identification, __Name)
		{
		}
	
	
	}
	
}
