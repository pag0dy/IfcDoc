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
	[Guid("d5b0d04f-2b00-489b-a200-4b5b96eaec68")]
	public partial class IfcDocumentReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcDocumentSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcDocumentInformation")]
		IfcDocumentInformation _ReferencedDocument;
	
		[InverseProperty("RelatingDocument")] 
		ISet<IfcRelAssociatesDocument> _DocumentRefForObjects = new HashSet<IfcRelAssociatesDocument>();
	
	
		[Description("<EPM-HTML>\r\nDescription of the document reference for informational purposes.\r\n<b" +
	    "lockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end" +
	    " of the attribute list.</blockquote>\r\n</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>The document that is referenced.</EPM-HTML>")]
		public IfcDocumentInformation ReferencedDocument { get { return this._ReferencedDocument; } set { this._ReferencedDocument = value;} }
	
		[Description("<EPM-HTML>\r\nThe document reference with which objects are associated.\r\n<blockquot" +
	    "e class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>\r\n<" +
	    "/EPM-HTML>")]
		public ISet<IfcRelAssociatesDocument> DocumentRefForObjects { get { return this._DocumentRefForObjects; } }
	
	
	}
	
}
