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
	[Guid("73ae901c-5bb5-4d7f-b59d-a681116104cf")]
	public partial class IfcExternallyDefinedHatchStyle : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcFillStyleSelect
	{
	
		public IfcExternallyDefinedHatchStyle()
		{
		}
	
		public IfcExternallyDefinedHatchStyle(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
	
	}
	
}
