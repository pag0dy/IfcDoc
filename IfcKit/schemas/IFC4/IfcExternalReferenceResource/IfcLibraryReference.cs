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
	[Guid("739c22f8-9791-4f05-b25d-70ddc3ed443f")]
	public partial class IfcLibraryReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcLibrarySelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLanguageId? _Language;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcLibraryInformation")]
		IfcLibraryInformation _ReferencedLibrary;
	
		[InverseProperty("RelatingLibrary")] 
		ISet<IfcRelAssociatesLibrary> _LibraryRefForObjects = new HashSet<IfcRelAssociatesLibrary>();
	
	
		[Description("<EPM-HTML>\r\nAdditional description provided for the library reference.\r\n<blockquo" +
	    "te class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New attribute added at the end of" +
	    " the attribute list.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>The language in which a library reference is expressed.\r\n<blockquote cl" +
	    "ass=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New attribute added at the end of the " +
	    "attribute list.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcLanguageId? Language { get { return this._Language; } set { this._Language = value;} }
	
		[Description("<EPM-HTML>The library information that is being referenced.</EPM-HTML>")]
		public IfcLibraryInformation ReferencedLibrary { get { return this._ReferencedLibrary; } set { this._ReferencedLibrary = value;} }
	
		[Description("<EPM-HTML>\r\nThe library reference with which objects are associated.\r\n<blockquote" +
	    " class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New inverse attribute.\r\n</blockquot" +
	    "e>\r\n</EPM-HTML>")]
		public ISet<IfcRelAssociatesLibrary> LibraryRefForObjects { get { return this._LibraryRefForObjects; } }
	
	
	}
	
}
