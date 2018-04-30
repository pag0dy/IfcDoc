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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcDocumentInformation :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identifier that uniquely identifies a document.")]
		[Required()]
		public IfcIdentifier DocumentId { get; set; }
	
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
		[Description("Information on the referenced document.")]
		[MinLength(1)]
		public ISet<IfcDocumentReference> DocumentReferences { get; protected set; }
	
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
		[Description("Document revision designation")]
		public IfcLabel? Revision { get; set; }
	
		[DataMember(Order = 8)] 
		[Description("Information about the person and/or organization acknowledged as the 'owner' of this document. In some contexts, the document owner determines who has access to or editing right to the document.")]
		public IfcActorSelect DocumentOwner { get; set; }
	
		[DataMember(Order = 9)] 
		[Description("The persons and/or organizations who have created this document or contributed to it.")]
		[MinLength(1)]
		public ISet<IfcActorSelect> Editors { get; protected set; }
	
		[DataMember(Order = 10)] 
		[Description("Date and time stamp when the document was originally created.")]
		public IfcDateAndTime CreationTime { get; set; }
	
		[DataMember(Order = 11)] 
		[Description("Date and time stamp when this document version was created.")]
		public IfcDateAndTime LastRevisionTime { get; set; }
	
		[DataMember(Order = 12)] 
		[Description("Describes the electronic format of the document being referenced, providing the file extension and the manner in which the content is provided.")]
		public IfcDocumentElectronicFormat ElectronicFormat { get; set; }
	
		[DataMember(Order = 13)] 
		[Description("Date, when the document becomes valid.")]
		public IfcCalendarDate ValidFrom { get; set; }
	
		[DataMember(Order = 14)] 
		[Description("Date until which the document remains valid.")]
		public IfcCalendarDate ValidUntil { get; set; }
	
		[DataMember(Order = 15)] 
		[XmlAttribute]
		[Description("The level of confidentiality of the document.")]
		public IfcDocumentConfidentialityEnum? Confidentiality { get; set; }
	
		[DataMember(Order = 16)] 
		[XmlAttribute]
		[Description("The current status of the document. Examples of status values that might be used for a document information status include:  - DRAFT  - FINAL DRAFT  - FINAL  - REVISION")]
		public IfcDocumentStatusEnum? Status { get; set; }
	
		[InverseProperty("RelatedDocuments")] 
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the related documents.")]
		public ISet<IfcDocumentInformationRelationship> IsPointedTo { get; protected set; }
	
		[InverseProperty("RelatingDocument")] 
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relating document.")]
		[MaxLength(1)]
		public ISet<IfcDocumentInformationRelationship> IsPointer { get; protected set; }
	
	
		public IfcDocumentInformation(IfcIdentifier __DocumentId, IfcLabel __Name, IfcText? __Description, IfcDocumentReference[] __DocumentReferences, IfcText? __Purpose, IfcText? __IntendedUse, IfcText? __Scope, IfcLabel? __Revision, IfcActorSelect __DocumentOwner, IfcActorSelect[] __Editors, IfcDateAndTime __CreationTime, IfcDateAndTime __LastRevisionTime, IfcDocumentElectronicFormat __ElectronicFormat, IfcCalendarDate __ValidFrom, IfcCalendarDate __ValidUntil, IfcDocumentConfidentialityEnum? __Confidentiality, IfcDocumentStatusEnum? __Status)
		{
			this.DocumentId = __DocumentId;
			this.Name = __Name;
			this.Description = __Description;
			this.DocumentReferences = new HashSet<IfcDocumentReference>(__DocumentReferences);
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
			this.IsPointedTo = new HashSet<IfcDocumentInformationRelationship>();
			this.IsPointer = new HashSet<IfcDocumentInformationRelationship>();
		}
	
	
	}
	
}
