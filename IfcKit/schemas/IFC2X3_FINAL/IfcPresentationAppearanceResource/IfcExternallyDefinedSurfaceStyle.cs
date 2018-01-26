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
	[Guid("3dee73c6-4c41-4994-b640-74a1623d53bd")]
	public partial class IfcExternallyDefinedSurfaceStyle : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSurfaceStyleElementSelect
	{
	
		public IfcExternallyDefinedSurfaceStyle()
		{
		}
	
		public IfcExternallyDefinedSurfaceStyle(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
	
	}
	
}
