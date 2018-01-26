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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

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
		[MinLength(1)]
		IList<IfcIdentifier> _ReferenceTokens = new List<IfcIdentifier>();
	
		[InverseProperty("RelatingClassification")] 
		ISet<IfcRelAssociatesClassification> _ClassificationForObjects = new HashSet<IfcRelAssociatesClassification>();
	
		[InverseProperty("ReferencedSource")] 
		[XmlElement("IfcClassificationReference")]
		ISet<IfcClassificationReference> _HasReferences = new HashSet<IfcClassificationReference>();
	
	
		public IfcClassification()
		{
		}
	
		public IfcClassification(IfcLabel? __Source, IfcLabel? __Edition, IfcDate? __EditionDate, IfcLabel __Name, IfcText? __Description, IfcURIReference? __Location, IfcIdentifier[] __ReferenceTokens)
		{
			this._Source = __Source;
			this._Edition = __Edition;
			this._EditionDate = __EditionDate;
			this._Name = __Name;
			this._Description = __Description;
			this._Location = __Location;
			this._ReferenceTokens = new List<IfcIdentifier>(__ReferenceTokens);
		}
	
		[Description(@"Source (or publisher) for this classification.
	<blockquote class=""note"">NOTE&nbsp; that the source of the classification means the person or organization that was the original author or the person or organization currently acting as the publisher.</blockquote>")]
		public IfcLabel? Source { get { return this._Source; } set { this._Source = value;} }
	
		[Description(@"The edition or version of the classification system from which the classification notation is derived.
	<blockquote class=""note"">NOTE&nbsp; the version labeling system is specific to the classification system.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE The attribute has been changed to be optional.</blockquote>")]
		public IfcLabel? Edition { get { return this._Edition; } set { this._Edition = value;} }
	
		[Description(@"The date on which the edition of the classification used became valid.
	<blockquote class=""note"">NOTE&nbsp; The indication of edition may be sufficient to identify the classification source uniquely but the edition date is provided as an optional attribute to enable more precise identification where required.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string according to ISO8601.</blockquote>")]
		public IfcDate? EditionDate { get { return this._EditionDate; } set { this._EditionDate = value;} }
	
		[Description("The name or label by which the classification used is normally known.\r\n<blockquot" +
	    "e class=\"note\">NOTE&nbsp; Examples of names include CI/SfB, Masterformat, BSAB, " +
	    "Uniclass, STABU, DIN276, DIN277 etc.</blockquote>")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("Additional description provided for the classification.\r\n<blockquote class=\"chang" +
	    "e-ifc2x4\">\r\n  IFC4 CHANGE&nbsp; New attribute added at the end of the attribute " +
	    "list.\r\n</blockquote>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("Resource identifier or locator, provided as URI, URN or URL, of the classificatio" +
	    "n.  \r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at" +
	    " the end of the attribute list.</blockquote>\r\n")]
		public IfcURIReference? Location { get { return this._Location; } set { this._Location = value;} }
	
		[Description("The delimiter tokens that are used to mark the boundaries of individual facets (s" +
	    "ubstrings) in a classification reference.\r\n<br><br>\r\nThis typically applies then" +
	    " the <em>IfcClassification</em> is used in\r\nconjuction with <em>IfcClassificatio" +
	    "nReference</em>\'s. If only one <em>ReferenceToken</em> is provided, it applies t" +
	    "o all boundaries of individual facets, if more than one <em>ReferenceToken</em> " +
	    "are provided, the first token applies to the first boundary, the second token to" +
	    " the second boundary, and the n<super>th</super> token to the n<super>th</super>" +
	    " and any additional boundary. \r\n\r\n<blockquote class=\"note\">NOTE&nbsp; Tokens are" +
	    " typically recommended within the classification itself and each token will have" +
	    " a particular role.</blockquote>\r\n<blockquote class=\"example\">\r\nEXAMPLE&nbsp;1 T" +
	    "o indicate that the facet delimiter used for DIN277-2 reference key \"2.1\" (\"Offi" +
	    "ce rooms\") is \".\", a single <em>ReferenceToken</em> [\'.\'] is provided. To indica" +
	    "te that the facet delimiter used for Omniclass Table 13 (space by function) refe" +
	    "rence key \"13-15 11 34 11\" (\"Office\") are \"-\" and \" \", two <em>ReferenceToken</e" +
	    "m>\'s [\'-\', \' \'] are provided. \r\n</blockquote>\r\n<blockquote class=\"example\">\r\nEXA" +
	    "MPLE&nbsp;2 The use of <em>ReferenceTokens</em> can also be extended to include " +
	    "masks. The use need to be agreed in view definitions or implementer agreements t" +
	    "hat stipulates a \"mask syntax\" that should be used.  \r\n</blockquote>\r\n<blockquot" +
	    "e class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the " +
	    "attribute list.</blockquote>")]
		public IList<IfcIdentifier> ReferenceTokens { get { return this._ReferenceTokens; } }
	
		[Description("The classification with which objects are associated.\r\n<blockquote class=\"change-" +
	    "ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesClassification> ClassificationForObjects { get { return this._ClassificationForObjects; } }
	
		[Description("The classification references to which the classification applies. It can either " +
	    "be the final classification notation, or an intermediate classification item.")]
		public ISet<IfcClassificationReference> HasReferences { get { return this._HasReferences; } }
	
	
	}
	
}
