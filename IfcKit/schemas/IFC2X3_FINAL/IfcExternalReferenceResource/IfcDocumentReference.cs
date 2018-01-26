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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("87a907a8-1351-4dd9-8a18-58f13ee5a2e0")]
	public partial class IfcDocumentReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[InverseProperty("DocumentReferences")] 
		[MaxLength(1)]
		ISet<IfcDocumentInformation> _ReferenceToDocument = new HashSet<IfcDocumentInformation>();
	
	
		public IfcDocumentReference()
		{
		}
	
		public IfcDocumentReference(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
		[Description("The document information that is being referenced.")]
		public ISet<IfcDocumentInformation> ReferenceToDocument { get { return this._ReferenceToDocument; } }
	
	
	}
	
}
