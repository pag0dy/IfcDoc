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
	[Guid("86dd2655-910b-4394-9cd1-3478de9e1798")]
	public partial class IfcClassification : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Source;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _Edition;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcDate? _EditionDate;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcURIReference? _Location;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IList<IfcIdentifier> _ReferenceTokens = new List<IfcIdentifier>();
	
		[InverseProperty("RelatingClassification")] 
		ISet<IfcRelAssociatesClassification> _ClassificationForObjects = new HashSet<IfcRelAssociatesClassification>();
	
		[InverseProperty("ReferencedSource")] 
		ISet<IfcClassificationReference> _HasReferences = new HashSet<IfcClassificationReference>();
	
	
		[Description(@"<EPM-HTML>
	Source (or publisher) for this classification.
	<blockquote class=""note"">NOTE&nbsp; that the source of the classification means the person or organization that was the original author or the person or organization currently acting as the publisher.</blockquote>
	</EPM-HTML>")]
		public IfcLabel? Source { get { return this._Source; } set { this._Source = value;} }
	
		[Description(@"<EPM-HTML>
	The edition or version of the classification system from which the classification notation is derived.
	<blockquote class=""note"">NOTE&nbsp; the version labeling system is specific to the classification system.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE The attribute has been changed to be optional.</blockquote>
	</EPM-HTML>")]
		public IfcLabel? Edition { get { return this._Edition; } set { this._Edition = value;} }
	
		[Description(@"<EPM-HTML>The date on which the edition of the classification used became valid.
	<blockquote class=""note"">NOTE&nbsp; The indication of edition may be sufficient to identify the classification source uniquely but the edition date is provided as an optional attribute to enable more precise identification where required.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string according to ISO8601.</blockquote>
	</EPM-HTML>")]
		public IfcDate? EditionDate { get { return this._EditionDate; } set { this._EditionDate = value;} }
	
		[Description("<EPM-HTML>\r\nThe name or label by which the classification used is normally known." +
	    "\r\n<blockquote class=\"note\">NOTE&nbsp; Examples of names include CI/SfB, Masterfo" +
	    "rmat, BSAB, Uniclass, STABU, DIN276, DIN277 etc.</blockquote>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>\r\nAdditional description provided for the classification.\r\n<blockquote " +
	    "class=\"change-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New attribute added at the end of th" +
	    "e attribute list.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("<EPM-HTML>Resource identifier or locator, provided as URI, URN or URL, of the cla" +
	    "ssification.  \r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribut" +
	    "e added at the end of the attribute list.</blockquote>\r\n<EPM-HTML>")]
		public IfcURIReference? Location { get { return this._Location; } set { this._Location = value;} }
	
		[Description("<EPM-HTML>\r\nThe delimiter tokens that are used to mark the boundaries of individu" +
	    "al facets (substrings) in a classification reference.\r\n<br><br>\r\nThis typically " +
	    "applies then the <em>IfcClassification</em> is used in\r\nconjuction with <em>IfcC" +
	    "lassificationReference</em>\'s. If only one <em>ReferenceToken</em> is provided, " +
	    "it applies to all boundaries of individual facets, if more than one <em>Referenc" +
	    "eToken</em> are provided, the first token applies to the first boundary, the sec" +
	    "ond token to the second boundary, and the n<super>th</super> token to the n<supe" +
	    "r>th</super> and any additional boundary. \r\n\r\n<blockquote class=\"note\">NOTE&nbsp" +
	    "; Tokens are typically recommended within the classification itself and each tok" +
	    "en will have a particular role.</blockquote>\r\n<blockquote class=\"example\">\r\nEXAM" +
	    "PLE&nbsp;1 To indicate that the facet delimiter used for DIN277-2 reference key " +
	    "\"2.1\" (\"Office rooms\") is \".\", a single <em>ReferenceToken</em> [\'.\'] is provide" +
	    "d. To indicate that the facet delimiter used for Omniclass Table 13 (space by fu" +
	    "nction) reference key \"13-15 11 34 11\" (\"Office\") are \"-\" and \" \", two <em>Refer" +
	    "enceToken</em>\'s [\'-\', \' \'] are provided. \r\n</blockquote>\r\n<blockquote class=\"ex" +
	    "ample\">\r\nEXAMPLE&nbsp;2 The use of <em>ReferenceTokens</em> can also be extended" +
	    " to include masks. The use need to be agreed in view definitions or implementer " +
	    "agreements that stipulates a \"mask syntax\" that should be used.  \r\n</blockquote>" +
	    "\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the" +
	    " end of the attribute list.</blockquote>\r\n</EPM-HTML>")]
		public IList<IfcIdentifier> ReferenceTokens { get { return this._ReferenceTokens; } }
	
		[Description("<EPM-HTML>\r\nThe classification with which objects are associated.\r\n<blockquote cl" +
	    "ass=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>\r\n</EPM" +
	    "-HTML>")]
		public ISet<IfcRelAssociatesClassification> ClassificationForObjects { get { return this._ClassificationForObjects; } }
	
		[Description("<EPM-HTML>\r\nThe classification references to which the classification applies. It" +
	    " can either be the final classification notation, or an intermediate classificat" +
	    "ion item.\r\n</EPM-HTML>")]
		public ISet<IfcClassificationReference> HasReferences { get { return this._HasReferences; } }
	
	
	}
	
}
