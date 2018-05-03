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
	public partial class IfcDocumentInformation : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identifier that uniquely identifies a document.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute renamed from <em>DocumentId</em>.  </blockquote>")]
		[Required()]
		public IfcIdentifier Identification { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("File name or document name assigned by owner.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Description of document and its content.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Resource identifier or locator, provided as URI, URN or URL, of the document information for online references.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the place of the removed attribute <em>DocumentReferences</em>.  </blockquote>")]
		public IfcURIReference? Location { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Purpose for this document.")]
		public IfcText? Purpose { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Intended use for this document.")]
		public IfcText? IntendedUse { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Scope for this document.")]
		public IfcText? Scope { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Document revision designation.")]
		public IfcLabel? Revision { get; set; }
	
		[DataMember(Order = 8)] 
		[Description("Information about the person and/or organization acknowledged as the 'owner' of this document. In some contexts, the document owner determines who has access to or editing right to the document.")]
		public IfcActorSelect DocumentOwner { get; set; }
	
		[DataMember(Order = 9)] 
		[Description("The persons and/or organizations who have created this document or contributed to it.")]
		[MinLength(1)]
		public ISet<IfcActorSelect> Editors { get; protected set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("Date and time stamp when the document was originally created.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDateTime</em>, the date time string according to ISO8601.</blockquote>")]
		public IfcDateTime? CreationTime { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("Date and time stamp when this document version was created.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDateTime</em>, the date time string according to ISO8601.</blockquote>")]
		public IfcDateTime? LastRevisionTime { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("Describes the media type used in various internet protocols, also referred to as \"Content-type\", or \"MIME-type (Multipurpose Internet Mail Extension), of the document being referenced. It is composed of (at least) two parts, a type and a subtype.  <blockquote class=\"note\">NOTE&nbsp; The iana (Internet Assigned Numbers Authority) published the media types. </blockquote>  <blockquote class=\"example\">EXAMPLE&nbsp;  'image/png' denotes an image type of png (Portable Network Graphics) subtype,   'application/pdf' denotes an application specific type of pdf (Portable Document Format) subtype   </blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The data type has been changed from entity data type to <em>IfcIdentifier</em>.  </blockquote>")]
		public IfcIdentifier? ElectronicFormat { get; set; }
	
		[DataMember(Order = 13)] 
		[XmlAttribute]
		[Description("Date when the document becomes valid.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string according to ISO8601.</blockquote>")]
		public IfcDate? ValidFrom { get; set; }
	
		[DataMember(Order = 14)] 
		[XmlAttribute]
		[Description("Date until which the document remains valid.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string according to ISO8601.</blockquote>")]
		public IfcDate? ValidUntil { get; set; }
	
		[DataMember(Order = 15)] 
		[XmlAttribute]
		[Description("The level of confidentiality of the document.")]
		public IfcDocumentConfidentialityEnum? Confidentiality { get; set; }
	
		[DataMember(Order = 16)] 
		[XmlAttribute]
		[Description("The current status of the document. Examples of status values that might be used for a document information status include:<BR>  - DRAFT<BR>  - FINAL DRAFT<BR>  - FINAL<BR>  - REVISION")]
		public IfcDocumentStatusEnum? Status { get; set; }
	
		[InverseProperty("RelatingDocument")] 
		[Description("The document information with which objects are associated.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesDocument> DocumentInfoForObjects { get; protected set; }
	
		[InverseProperty("ReferencedDocument")] 
		[Description("The document references to which the document applies")]
		public ISet<IfcDocumentReference> HasDocumentReferences { get; protected set; }
	
		[InverseProperty("RelatedDocuments")] 
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the related documents./EPM-HTML>")]
		public ISet<IfcDocumentInformationRelationship> IsPointedTo { get; protected set; }
	
		[InverseProperty("RelatingDocument")] 
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relating document.")]
		[MaxLength(1)]
		public ISet<IfcDocumentInformationRelationship> IsPointer { get; protected set; }
	
	
		public IfcDocumentInformation(IfcIdentifier __Identification, IfcLabel __Name, IfcText? __Description, IfcURIReference? __Location, IfcText? __Purpose, IfcText? __IntendedUse, IfcText? __Scope, IfcLabel? __Revision, IfcActorSelect __DocumentOwner, IfcActorSelect[] __Editors, IfcDateTime? __CreationTime, IfcDateTime? __LastRevisionTime, IfcIdentifier? __ElectronicFormat, IfcDate? __ValidFrom, IfcDate? __ValidUntil, IfcDocumentConfidentialityEnum? __Confidentiality, IfcDocumentStatusEnum? __Status)
		{
			this.Identification = __Identification;
			this.Name = __Name;
			this.Description = __Description;
			this.Location = __Location;
			this.Purpose = __Purpose;
			this.IntendedUse = __IntendedUse;
			this.Scope = __Scope;
			this.Revision = __Revision;
			this.DocumentOwner = __DocumentOwner;
			this.Editors = new HashSet<IfcActorSelect>(__Editors);
			this.CreationTime = __CreationTime;
			this.LastRevisionTime = __LastRevisionTime;
			this.ElectronicFormat = __ElectronicFormat;
			this.ValidFrom = __ValidFrom;
			this.ValidUntil = __ValidUntil;
			this.Confidentiality = __Confidentiality;
			this.Status = __Status;
			this.DocumentInfoForObjects = new HashSet<IfcRelAssociatesDocument>();
			this.HasDocumentReferences = new HashSet<IfcDocumentReference>();
			this.IsPointedTo = new HashSet<IfcDocumentInformationRelationship>();
			this.IsPointer = new HashSet<IfcDocumentInformationRelationship>();
		}
	
	
	}
	
}
