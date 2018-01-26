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
	[Guid("cfdbc669-8a34-4570-ad57-0939f779948e")]
	public partial class IfcLibraryReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[InverseProperty("LibraryReference")] 
		[MaxLength(1)]
		ISet<IfcLibraryInformation> _ReferenceIntoLibrary = new HashSet<IfcLibraryInformation>();
	
	
		public IfcLibraryReference()
		{
		}
	
		public IfcLibraryReference(IfcLabel? __Location, IfcIdentifier? __ItemReference, IfcLabel? __Name)
			: base(__Location, __ItemReference, __Name)
		{
		}
	
		[Description("The library information that is being referenced.")]
		public ISet<IfcLibraryInformation> ReferenceIntoLibrary { get { return this._ReferenceIntoLibrary; } }
	
	
	}
	
}
