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
		ISet<IfcDocumentInformationRelationship> _IsPointer = new HashSet<IfcDocumentInformationRelationship>();
	
	
		[Description("<EPM-HTML>\r\nIdentifier that uniquely identifies a document.\r\n<blockquote class=\"c" +
	    "hange-ifc2x4\">IFC4 CHANGE&nbsp; Attribute renamed from <em>DocumentId</em>.\r\n</b" +
	    "lockquote>\r\n</EPM-HTML>")]
		public IfcIdentifier Identification { get { return this._Identification; } set { this._Identification = value;} }
	
		[Description("<EPM-HTML>File name or document name assigned by owner.</EPM-HTML>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>Description of document and its content.</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"<EPM-HTML>Resource identifier or locator, provided as URI, URN or URL, of the document information for online references.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the place of the removed attribute <em>DocumentReferences</em>.
	</blockquote>
	</EPM-HTML>")]
		public IfcURIReference? Location { get { return this._Location; } set { this._Location = value;} }
	
		[Description("<EPM-HTML>Purpose for this document.</EPM-HTML>")]
		public IfcText? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("<EPM-HTML>Intended use for this document.</EPM-HTML>")]
		public IfcText? IntendedUse { get { return this._IntendedUse; } set { this._IntendedUse = value;} }
	
		[Description("<EPM-HTML>Scope for this document.</EPM-HTML>")]
		public IfcText? Scope { get { return this._Scope; } set { this._Scope = value;} }
	
		[Description("<EPM-HTML>Document revision designation.</EPM-HTML>")]
		public IfcLabel? Revision { get { return this._Revision; } set { this._Revision = value;} }
	
		[Description("<EPM-HTML>Information about the person and/or organization acknowledged as the \'o" +
	    "wner\' of this document. In some contexts, the document owner determines who has " +
	    "access to or editing right to the document.</EPM-HTML>")]
		public IfcActorSelect DocumentOwner { get { return this._DocumentOwner; } set { this._DocumentOwner = value;} }
	
		[Description("<EPM-HTML>The persons and/or organizations who have created this document or cont" +
	    "ributed to it.</EPM-HTML>")]
		public ISet<IfcActorSelect> Editors { get { return this._Editors; } }
	
		[Description("<EPM-HTML>\r\nDate and time stamp when the document was originally created.\r\n<block" +
	    "quote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>If" +
	    "cDateTime</em>, the date time string according to ISO8601.</blockquote>\r\n</EPM-H" +
	    "TML>")]
		public IfcDateTime? CreationTime { get { return this._CreationTime; } set { this._CreationTime = value;} }
	
		[Description("<EPM-HTML>\r\nDate and time stamp when this document version was created.\r\n<blockqu" +
	    "ote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcD" +
	    "ateTime</em>, the date time string according to ISO8601.</blockquote>\r\n</EPM-HTM" +
	    "L>")]
		public IfcDateTime? LastRevisionTime { get { return this._LastRevisionTime; } set { this._LastRevisionTime = value;} }
	
		[Description(@"<EPM-HTML>
	Describes the media type used in various internet protocols, also referred to as ""Content-type"", or ""MIME-type (Multipurpose Internet Mail Extension), of the document being referenced. It is composed of (at least) two parts, a type and a subtype.
	<blockquote class=""note"">NOTE&nbsp; The iana (Internet Assigned Numbers Authority) published the media types. </blockquote>
	<blockquote class=""example"">EXAMPLE&nbsp;
	'image/png' denotes an image type of png (Portable Network Graphics) subtype, 
	'application/pdf' denotes an application specific type of pdf (Portable Document Format) subtype 
	</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The data type has been changed from entity data type to <em>IfcIdentifier</em>.
	</blockquote>
	</EPM-HTML>")]
		public IfcIdentifier? ElectronicFormat { get { return this._ElectronicFormat; } set { this._ElectronicFormat = value;} }
	
		[Description("<EPM-HTML>\r\nDate when the document becomes valid.\r\n<blockquote class=\"change-ifc2" +
	    "x4\">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date str" +
	    "ing according to ISO8601.</blockquote>\r\n</EPM-HTML>")]
		public IfcDate? ValidFrom { get { return this._ValidFrom; } set { this._ValidFrom = value;} }
	
		[Description("<EPM-HTML>\r\nDate until which the document remains valid.\r\n<blockquote class=\"chan" +
	    "ge-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the d" +
	    "ate string according to ISO8601.</blockquote>\r\n</EPM-HTML>")]
		public IfcDate? ValidUntil { get { return this._ValidUntil; } set { this._ValidUntil = value;} }
	
		[Description("<EPM-HTML>The level of confidentiality of the document.</EPM-HTML>")]
		public IfcDocumentConfidentialityEnum? Confidentiality { get { return this._Confidentiality; } set { this._Confidentiality = value;} }
	
		[Description("<EPM-HTML>The current status of the document. Examples of status values that migh" +
	    "t be used for a document information status include:<BR>\r\n- DRAFT<BR>\r\n- FINAL D" +
	    "RAFT<BR>\r\n- FINAL<BR>\r\n- REVISION</EPM-HTML>")]
		public IfcDocumentStatusEnum? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("<EPM-HTML>\r\nThe document information with which objects are associated.\r\n<blockqu" +
	    "ote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>\r" +
	    "\n</EPM-HTML>")]
		public ISet<IfcRelAssociatesDocument> DocumentInfoForObjects { get { return this._DocumentInfoForObjects; } }
	
		[Description("<EPM-HTML>The document references to which the document applies</EPM-HTML>")]
		public ISet<IfcDocumentReference> HasDocumentReferences { get { return this._HasDocumentReferences; } }
	
		[Description("<EPM-HTML>An inverse relationship from the IfcDocumentInformationRelationship to " +
	    "the related documents./EPM-HTML>")]
		public ISet<IfcDocumentInformationRelationship> IsPointedTo { get { return this._IsPointedTo; } }
	
		[Description("<EPM-HTML>An inverse relationship from the IfcDocumentInformationRelationship to " +
	    "the relating document.</EPM-HTML>")]
		public ISet<IfcDocumentInformationRelationship> IsPointer { get { return this._IsPointer; } }
	
	
	}
	
}
