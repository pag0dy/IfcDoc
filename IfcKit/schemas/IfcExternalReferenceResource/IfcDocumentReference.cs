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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcDocumentReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[InverseProperty("DocumentReferences")] 
		[Description("The document information that is being referenced.")]
		[MaxLength(1)]
		public ISet<IfcDocumentInformation> ReferenceToDocument { get; protected set; }
	
	
		public IfcDocumentReference(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
			this.ReferenceToDocument = new HashSet<IfcDocumentInformation>();
		}
	
	
	}
	
}
