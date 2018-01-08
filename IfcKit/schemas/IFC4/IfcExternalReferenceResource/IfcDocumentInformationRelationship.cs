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
	[Guid("79f322fe-2390-4be9-ac5e-2c79ccbfc1d5")]
	public partial class IfcDocumentInformationRelationship : IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcDocumentInformation")]
		[Required()]
		IfcDocumentInformation _RelatingDocument;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcDocumentInformation> _RelatedDocuments = new HashSet<IfcDocumentInformation>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _RelationshipType;
	
	
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
