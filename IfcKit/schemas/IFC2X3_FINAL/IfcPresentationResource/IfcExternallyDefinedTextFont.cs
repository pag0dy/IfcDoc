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

namespace BuildingSmart.IFC.IfcPresentationResource
{
	[Guid("bf1f0d7a-aef4-4e90-911a-099227f8ffd2")]
	public partial class IfcExternallyDefinedTextFont : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationResource.IfcTextFontSelect
	{
	
		public IfcExternallyDefinedTextFont()
		{
		}
	
		public IfcExternallyDefinedTextFont(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
	
	}
	
}
