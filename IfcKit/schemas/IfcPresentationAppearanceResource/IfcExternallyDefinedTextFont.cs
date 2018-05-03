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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcExternallyDefinedTextFont : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcTextFontSelect
	{
	
		public IfcExternallyDefinedTextFont(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name)
			: base(__Location, __Identification, __Name)
		{
		}
	
	
	}
	
}
