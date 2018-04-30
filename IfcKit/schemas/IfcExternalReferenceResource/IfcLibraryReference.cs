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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcLibraryReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Additional description provided for the library reference.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.  </blockquote>")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The language in which a library reference is expressed.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.  </blockquote>")]
		public IfcLanguageId? Language { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("The library information that is being referenced.")]
		public IfcLibraryInformation ReferencedLibrary { get; set; }
	
		[InverseProperty("RelatingLibrary")] 
		[Description("The library reference with which objects are associated.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New inverse attribute.  </blockquote>")]
		public ISet<IfcRelAssociatesLibrary> LibraryRefForObjects { get; protected set; }
	
	
		public IfcLibraryReference(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name, IfcText? __Description, IfcLanguageId? __Language, IfcLibraryInformation __ReferencedLibrary)
			: base(__Location, __Identification, __Name)
		{
			this.Description = __Description;
			this.Language = __Language;
			this.ReferencedLibrary = __ReferencedLibrary;
			this.LibraryRefForObjects = new HashSet<IfcRelAssociatesLibrary>();
		}
	
	
	}
	
}
