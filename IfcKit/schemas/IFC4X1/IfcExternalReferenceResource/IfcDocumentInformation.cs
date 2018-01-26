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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("ece4dd99-11bc-4dbb-b170-998764abc239")]
	public partial class IfcDocumentInformation : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _Identification;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcURIReference? _Location;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _Purpose;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcText? _IntendedUse;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcText? _Scope;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcLabel? _Revision;
	
		[DataMember(Order=8)] 
		IfcActorSelect _DocumentOwner;
	
		[DataMember(Order=9)] 
		[MinLength(1)]
		ISet<IfcActorSelect> _Editors = new HashSet<IfcActorSelect>();
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcDateTime? _CreationTime;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcDateTime? _LastRevisionTime;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcIdentifier? _ElectronicFormat;
	
		[DataMember(Order=13)] 
		[XmlAttribute]
		IfcDate? _ValidFrom;
	
		[DataMember(Order=14)] 
		[XmlAttribute]
		IfcDate? _ValidUntil;
	
		[DataMember(Order=15)] 
		[XmlAttribute]
		IfcDocumentConfidentialityEnum? _Confidentiality;
	
		[DataMember(Order=16)] 
		[XmlAttribute]
		IfcDocumentStatusEnum? _Status;
	
		[InverseProperty("RelatingDocument")] 
		ISet<IfcRelAssociatesDocument> _DocumentInfoForObjects = new HashSet<IfcRelAssociatesDocument>();
	
		[InverseProperty("ReferencedDocument")] 
		ISet<IfcDocumentReference> _HasDocumentReferences = new HashSet<IfcDocumentReference>();
	
		[InverseProperty("RelatedDocuments")] 
		ISet<IfcDocumentInformationRelationship> _IsPointedTo = new HashSet<IfcDocumentInformationRelationship>();
	
		[InverseProperty("RelatingDocument")] 
		[MaxLength(1)]
		ISet<IfcDocumentInformationRelationship> _IsPointer = new HashSet<IfcDocumentInformationRelationship>();
	
	
		public IfcDocumentInformation()
		{
		}
	
		public IfcDocumentInformation(IfcIdentifier __Identification, IfcLabel __Name, IfcText? __Description, IfcURIReference? __Location, IfcText? __Purpose, IfcText? __IntendedUse, IfcText? __Scope, IfcLabel? __Revision, IfcActorSelect __DocumentOwner, IfcActorSelect[] __Editors, IfcDateTime? __CreationTime, IfcDateTime? __LastRevisionTime, IfcIdentifier? __ElectronicFormat, IfcDate? __ValidFrom, IfcDate? __ValidUntil, IfcDocumentConfidentialityEnum? __Confidentiality, IfcDocumentStatusEnum? __Status)
		{
			this._Identification = __Identification;
			this._Name = __Name;
			this._Description = __Description;
			this._Location = __Location;
			this._Purpose = __Purpose;
			this._IntendedUse = __IntendedUse;
			this._Scope = __Scope;
			this._Revision = __Revision;
			this._DocumentOwner = __DocumentOwner;
			this._Editors = new HashSet<IfcActorSelect>(__Editors);
			this._CreationTime = __CreationTime;
			this._LastRevisionTime = __LastRevisionTime;
			this._ElectronicFormat = __ElectronicFormat;
			this._ValidFrom = __ValidFrom;
			this._ValidUntil = __ValidUntil;
			this._Confidentiality = __Confidentiality;
			this._Status = __Status;
		}
	
		[Description("Identifier that uniquely identifies a document.\r\n<blockquote class=\"change-ifc2x4" +
	    "\">IFC4 CHANGE&nbsp; Attribute renamed from <em>DocumentId</em>.\r\n</blockquote>")]
		public IfcIdentifier Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("File name or document name assigned by owner.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Description of document and its content.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Resource identifier or locator, provided as URI, URN or URL, of the document information for online references.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the place of the removed attribute <em>DocumentReferences</em>.
	</blockquote>")]
		public IfcURIReference? Location { get { return this._Location; } set { this._Location = value;} }
	
		[Description("Purpose for this document.")]
		public IfcText? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("Intended use for this document.")]
		public IfcText? IntendedUse { get { return this._IntendedUse; } set { this._IntendedUse = value;} }
	
		[Description("Scope for this document.")]
		public IfcText? Scope { get { return this._Scope; } set { this._Scope = value;} }
	
		[Description("Document revision designation.")]
		public IfcLabel? Revision { get { return this._Revision; } set { this._Revision = value;} }
	
		[Description("Information about the person and/or organization acknowledged as the \'owner\' of t" +
	    "his document. In some contexts, the document owner determines who has access to " +
	    "or editing right to the document.")]
		public IfcActorSelect DocumentOwner { get { return this._DocumentOwner; } set { this._DocumentOwner = value;} }
	
		[Description("The persons and/or organizations who have created this document or contributed to" +
	    " it.")]
		public ISet<IfcActorSelect> Editors { get { return this._Editors; } }
	
		[Description("Date and time stamp when the document was originally created.\r\n<blockquote class=" +
	    "\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDateTime</e" +
	    "m>, the date time string according to ISO8601.</blockquote>")]
		public IfcDateTime? CreationTime { get { return this._CreationTime; } set { this._CreationTime = value;} }
	
		[Description("Date and time stamp when this document version was created.\r\n<blockquote class=\"c" +
	    "hange-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDateTime</em>" +
	    ", the date time string according to ISO8601.</blockquote>")]
		public IfcDateTime? LastRevisionTime { get { return this._LastRevisionTime; } set { this._LastRevisionTime = value;} }
	
		[Description(@"Describes the media type used in various internet protocols, also referred to as ""Content-type"", or ""MIME-type (Multipurpose Internet Mail Extension), of the document being referenced. It is composed of (at least) two parts, a type and a subtype.
	<blockquote class=""note"">NOTE&nbsp; The iana (Internet Assigned Numbers Authority) published the media types. </blockquote>
	<blockquote class=""example"">EXAMPLE&nbsp;
	'image/png' denotes an image type of png (Portable Network Graphics) subtype, 
	'application/pdf' denotes an application specific type of pdf (Portable Document Format) subtype 
	</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The data type has been changed from entity data type to <em>IfcIdentifier</em>.
	</blockquote>")]
		public IfcIdentifier? ElectronicFormat { get { return this._ElectronicFormat; } set { this._ElectronicFormat = value;} }
	
		[Description("Date when the document becomes valid.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHA" +
	    "NGE The data type has been changed to <em>IfcDate</em>, the date string accordin" +
	    "g to ISO8601.</blockquote>")]
		public IfcDate? ValidFrom { get { return this._ValidFrom; } set { this._ValidFrom = value;} }
	
		[Description("Date until which the document remains valid.\r\n<blockquote class=\"change-ifc2x4\">I" +
	    "FC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string a" +
	    "ccording to ISO8601.</blockquote>")]
		public IfcDate? ValidUntil { get { return this._ValidUntil; } set { this._ValidUntil = value;} }
	
		[Description("The level of confidentiality of the document.")]
		public IfcDocumentConfidentialityEnum? Confidentiality { get { return this._Confidentiality; } set { this._Confidentiality = value;} }
	
		[Description("The current status of the document. Examples of status values that might be used " +
	    "for a document information status include:<BR>\r\n- DRAFT<BR>\r\n- FINAL DRAFT<BR>\r\n" +
	    "- FINAL<BR>\r\n- REVISION")]
		public IfcDocumentStatusEnum? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("The document information with which objects are associated.\r\n<blockquote class=\"c" +
	    "hange-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesDocument> DocumentInfoForObjects { get { return this._DocumentInfoForObjects; } }
	
		[Description("The document references to which the document applies")]
		public ISet<IfcDocumentReference> HasDocumentReferences { get { return this._HasDocumentReferences; } }
	
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relate" +
	    "d documents./EPM-HTML>")]
		public ISet<IfcDocumentInformationRelationship> IsPointedTo { get { return this._IsPointedTo; } }
	
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relati" +
	    "ng document.")]
		public ISet<IfcDocumentInformationRelationship> IsPointer { get { return this._IsPointer; } }
	
	
	}
	
}
