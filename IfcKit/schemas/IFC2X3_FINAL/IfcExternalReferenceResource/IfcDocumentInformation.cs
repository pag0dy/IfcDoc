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
	[Guid("de7717e4-cebe-4cc9-a834-d97678327b73")]
	public partial class IfcDocumentInformation :
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _DocumentId;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=3)] 
		[MinLength(1)]
		ISet<IfcDocumentReference> _DocumentReferences = new HashSet<IfcDocumentReference>();
	
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
		IfcDateAndTime _CreationTime;
	
		[DataMember(Order=11)] 
		IfcDateAndTime _LastRevisionTime;
	
		[DataMember(Order=12)] 
		IfcDocumentElectronicFormat _ElectronicFormat;
	
		[DataMember(Order=13)] 
		IfcCalendarDate _ValidFrom;
	
		[DataMember(Order=14)] 
		IfcCalendarDate _ValidUntil;
	
		[DataMember(Order=15)] 
		[XmlAttribute]
		IfcDocumentConfidentialityEnum? _Confidentiality;
	
		[DataMember(Order=16)] 
		[XmlAttribute]
		IfcDocumentStatusEnum? _Status;
	
		[InverseProperty("RelatedDocuments")] 
		ISet<IfcDocumentInformationRelationship> _IsPointedTo = new HashSet<IfcDocumentInformationRelationship>();
	
		[InverseProperty("RelatingDocument")] 
		[MaxLength(1)]
		ISet<IfcDocumentInformationRelationship> _IsPointer = new HashSet<IfcDocumentInformationRelationship>();
	
	
		public IfcDocumentInformation()
		{
		}
	
		public IfcDocumentInformation(IfcIdentifier __DocumentId, IfcLabel __Name, IfcText? __Description, IfcDocumentReference[] __DocumentReferences, IfcText? __Purpose, IfcText? __IntendedUse, IfcText? __Scope, IfcLabel? __Revision, IfcActorSelect __DocumentOwner, IfcActorSelect[] __Editors, IfcDateAndTime __CreationTime, IfcDateAndTime __LastRevisionTime, IfcDocumentElectronicFormat __ElectronicFormat, IfcCalendarDate __ValidFrom, IfcCalendarDate __ValidUntil, IfcDocumentConfidentialityEnum? __Confidentiality, IfcDocumentStatusEnum? __Status)
		{
			this._DocumentId = __DocumentId;
			this._Name = __Name;
			this._Description = __Description;
			this._DocumentReferences = new HashSet<IfcDocumentReference>(__DocumentReferences);
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
	
		[Description("Identifier that uniquely identifies a document.")]
		public IfcIdentifier DocumentId { get { return this._DocumentId; } set { this._DocumentId = value;} }
	
		[Description("File name or document name assigned by owner.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Description of document and its content.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Information on the referenced document.")]
		public ISet<IfcDocumentReference> DocumentReferences { get { return this._DocumentReferences; } }
	
		[Description("Purpose for this document.")]
		public IfcText? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("Intended use for this document.")]
		public IfcText? IntendedUse { get { return this._IntendedUse; } set { this._IntendedUse = value;} }
	
		[Description("Scope for this document.")]
		public IfcText? Scope { get { return this._Scope; } set { this._Scope = value;} }
	
		[Description("Document revision designation")]
		public IfcLabel? Revision { get { return this._Revision; } set { this._Revision = value;} }
	
		[Description("Information about the person and/or organization acknowledged as the \'owner\' of t" +
	    "his document. In some contexts, the document owner determines who has access to " +
	    "or editing right to the document.")]
		public IfcActorSelect DocumentOwner { get { return this._DocumentOwner; } set { this._DocumentOwner = value;} }
	
		[Description("The persons and/or organizations who have created this document or contributed to" +
	    " it.")]
		public ISet<IfcActorSelect> Editors { get { return this._Editors; } }
	
		[Description("Date and time stamp when the document was originally created.")]
		public IfcDateAndTime CreationTime { get { return this._CreationTime; } set { this._CreationTime = value;} }
	
		[Description("Date and time stamp when this document version was created.")]
		public IfcDateAndTime LastRevisionTime { get { return this._LastRevisionTime; } set { this._LastRevisionTime = value;} }
	
		[Description("Describes the electronic format of the document being referenced, providing the f" +
	    "ile extension and the manner in which the content is provided.")]
		public IfcDocumentElectronicFormat ElectronicFormat { get { return this._ElectronicFormat; } set { this._ElectronicFormat = value;} }
	
		[Description("Date, when the document becomes valid.")]
		public IfcCalendarDate ValidFrom { get { return this._ValidFrom; } set { this._ValidFrom = value;} }
	
		[Description("Date until which the document remains valid.")]
		public IfcCalendarDate ValidUntil { get { return this._ValidUntil; } set { this._ValidUntil = value;} }
	
		[Description("The level of confidentiality of the document.")]
		public IfcDocumentConfidentialityEnum? Confidentiality { get { return this._Confidentiality; } set { this._Confidentiality = value;} }
	
		[Description("The current status of the document. Examples of status values that might be used " +
	    "for a document information status include:\r\n- DRAFT\r\n- FINAL DRAFT\r\n- FINAL\r\n- R" +
	    "EVISION")]
		public IfcDocumentStatusEnum? Status { get { return this._Status; } set { this._Status = value;} }
	
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relate" +
	    "d documents.")]
		public ISet<IfcDocumentInformationRelationship> IsPointedTo { get { return this._IsPointedTo; } }
	
		[Description("An inverse relationship from the IfcDocumentInformationRelationship to the relati" +
	    "ng document.")]
		public ISet<IfcDocumentInformationRelationship> IsPointer { get { return this._IsPointer; } }
	
	
	}
	
}
