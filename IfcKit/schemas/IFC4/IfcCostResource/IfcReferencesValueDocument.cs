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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("40a470f7-a897-4241-8b52-574730c6954d")]
	public partial class IfcReferencesValueDocument
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDocumentSelect _ReferencedDocument;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcAppliedValue> _ReferencingValues = new HashSet<IfcAppliedValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		[Description("A document such as a price list or quotation from which costs are obtained.")]
		public IfcDocumentSelect ReferencedDocument { get { return this._ReferencedDocument; } set { this._ReferencedDocument = value;} }
	
		[Description("Costs obtained from a single document such as a price list or quotation.")]
		public ISet<IfcAppliedValue> ReferencingValues { get { return this._ReferencingValues; } }
	
		[Description("A name used to identify or qualify the relationship to the document from which va" +
	    "lues may be referenced..")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description of the relationship to the document from which values may be refere" +
	    "nced.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
