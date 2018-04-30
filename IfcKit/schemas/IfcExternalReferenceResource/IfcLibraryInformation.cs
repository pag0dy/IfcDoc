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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcLibraryInformation : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The name which is used to identify the library.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Identifier for the library version used for reference.")]
		public IfcLabel? Version { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Information of the organization that acts as the library publisher.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; The data type has been changed to <em>IfcActorSelect</em>.  </blockquote>")]
		public IfcActorSelect Publisher { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Date of the referenced version of the library.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; The data type has been changed to <em>IfcDateTime</em>, the date and time string according to ISO8601.  </blockquote>")]
		public IfcDateTime? VersionDate { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Resource identifier or locator, provided as URI, URN or URL, of the library information for online references.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.  </blockquote>")]
		public IfcURIReference? Location { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Additional description provided for the library revision information.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.  </blockquote>")]
		public IfcText? Description { get; set; }
	
		[InverseProperty("RelatingLibrary")] 
		[Description("The library information with which objects are associated.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New inverse attribute.  </blockquote>")]
		public ISet<IfcRelAssociatesLibrary> LibraryInfoForObjects { get; protected set; }
	
		[InverseProperty("ReferencedLibrary")] 
		[Description("The library references to which the library information applies.")]
		public ISet<IfcLibraryReference> HasLibraryReferences { get; protected set; }
	
	
		public IfcLibraryInformation(IfcLabel __Name, IfcLabel? __Version, IfcActorSelect __Publisher, IfcDateTime? __VersionDate, IfcURIReference? __Location, IfcText? __Description)
		{
			this.Name = __Name;
			this.Version = __Version;
			this.Publisher = __Publisher;
			this.VersionDate = __VersionDate;
			this.Location = __Location;
			this.Description = __Description;
			this.LibraryInfoForObjects = new HashSet<IfcRelAssociatesLibrary>();
			this.HasLibraryReferences = new HashSet<IfcLibraryReference>();
		}
	
	
	}
	
}
