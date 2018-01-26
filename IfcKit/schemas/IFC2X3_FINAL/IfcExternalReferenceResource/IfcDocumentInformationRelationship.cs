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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("5eefb261-6d1c-424f-9b49-7f0129a9954c")]
	public partial class IfcDocumentInformationRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDocumentInformation _RelatingDocument;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcDocumentInformation> _RelatedDocuments = new HashSet<IfcDocumentInformation>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _RelationshipType;
	
	
		public IfcDocumentInformationRelationship()
		{
		}
	
		public IfcDocumentInformationRelationship(IfcDocumentInformation __RelatingDocument, IfcDocumentInformation[] __RelatedDocuments, IfcLabel? __RelationshipType)
		{
			this._RelatingDocument = __RelatingDocument;
			this._RelatedDocuments = new HashSet<IfcDocumentInformation>(__RelatedDocuments);
			this._RelationshipType = __RelationshipType;
		}
	
		[Description("The document that acts as the parent, referencing or original document in a relat" +
	    "ionship.")]
		public IfcDocumentInformation RelatingDocument { get { return this._RelatingDocument; } set { this._RelatingDocument = value;} }
	
		[Description("The document that acts as the child, referenced or replacing document in a relati" +
	    "onship.")]
		public ISet<IfcDocumentInformation> RelatedDocuments { get { return this._RelatedDocuments; } }
	
		[Description("Describes the type of relationship between documents. This could be sub-document," +
	    " replacement etc. The interpretation has to be established in an application con" +
	    "text.")]
		public IfcLabel? RelationshipType { get { return this._RelationshipType; } set { this._RelationshipType = value;} }
	
	
	}
	
}
