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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("cfdbc669-8a34-4570-ad57-0939f779948e")]
	public partial class IfcLibraryReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[InverseProperty("LibraryReference")] 
		ISet<IfcLibraryInformation> _ReferenceIntoLibrary = new HashSet<IfcLibraryInformation>();
	
	
		[Description("The library information that is being referenced.")]
		public ISet<IfcLibraryInformation> ReferenceIntoLibrary { get { return this._ReferenceIntoLibrary; } }
	
	
	}
	
}
