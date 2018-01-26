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

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("6e195765-d312-41d5-acc2-8b8f850419dd")]
	public partial class IfcExternallyDefinedSymbol : IfcExternalReference,
		BuildingSmart.IFC.IfcPresentationDefinitionResource.IfcDefinedSymbolSelect
	{
	
		public IfcExternallyDefinedSymbol()
		{
		}
	
		public IfcExternallyDefinedSymbol(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
	
	}
	
}
