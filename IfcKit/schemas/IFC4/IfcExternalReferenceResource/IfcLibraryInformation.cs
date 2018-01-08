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
using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("614b2347-4e01-42a4-a914-c29116ce216a")]
	public partial class IfcLibraryInformation : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Version;
	
		[DataMember(Order=2)] 
		IfcActorSelect _Publisher;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDateTime? _VersionDate;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcURIReference? _Location;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[InverseProperty("RelatingLibrary")] 
		ISet<IfcRelAssociatesLibrary> _LibraryInfoForObjects = new HashSet<IfcRelAssociatesLibrary>();
	
		[InverseProperty("ReferencedLibrary")] 
		ISet<IfcLibraryReference> _HasLibraryReferences = new HashSet<IfcLibraryReference>();
	
	
		[Description("<EPM-HTML>The name which is used to identify the library.</EPM-HTML>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>Identifier for the library version used for reference.</EPM-HTML>")]
		public IfcLabel? Version { get { return this._Version; } set { this._Version = value;} }
	
		[Description("<EPM-HTML>\r\nInformation of the organization that acts as the library publisher.\r\n" +
	    "<blockquote class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; The data type has been c" +
	    "hanged to <em>IfcActorSelect</em>.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcActorSelect Publisher { get { return this._Publisher; } set { this._Publisher = value;} }
	
		[Description("<EPM-HTML>\r\nDate of the referenced version of the library.\r\n<blockquote class=\"ch" +
	    "ange-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; The data type has been changed to <em>IfcDate" +
	    "Time</em>, the date and time string according to ISO8601.\r\n</blockquote>\r\n</EPM-" +
	    "HTML>")]
		public IfcDateTime? VersionDate { get { return this._VersionDate; } set { this._VersionDate = value;} }
	
		[Description(@"<EPM-HTML>
	Resource identifier or locator, provided as URI, URN or URL, of the library information for online references.
	<blockquote class=""change-ifc2x4"">
	  IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.
	</blockquote>
	</EPM-HTML>")]
		public IfcURIReference? Location { get { return this._Location; } set { this._Location = value;} }
	
		[Description("<EPM-HTML>\r\nAdditional description provided for the library revision information." +
	    "\r\n<blockquote class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New attribute added at" +
	    " the end of the attribute list.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>\r\nThe library information with which objects are associated.\r\n<blockquo" +
	    "te class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New inverse attribute.\r\n</blockqu" +
	    "ote>\r\n</EPM-HTML>")]
		public ISet<IfcRelAssociatesLibrary> LibraryInfoForObjects { get { return this._LibraryInfoForObjects; } }
	
		[Description("<EPM-HTML>The library references to which the library information applies.</EPM-H" +
	    "TML>")]
		public ISet<IfcLibraryReference> HasLibraryReferences { get { return this._HasLibraryReferences; } }
	
	
	}
	
}
