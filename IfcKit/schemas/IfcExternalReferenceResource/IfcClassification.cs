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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcClassification : IfcExternalInformation,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Source (or publisher) for this classification.  <blockquote class=\"note\">NOTE&nbsp; that the source of the classification means the person or organization that was the original author or the person or organization currently acting as the publisher.</blockquote>")]
		public IfcLabel? Source { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The edition or version of the classification system from which the classification notation is derived.  <blockquote class=\"note\">NOTE&nbsp; the version labeling system is specific to the classification system.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The attribute has been changed to be optional.</blockquote>")]
		public IfcLabel? Edition { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The date on which the edition of the classification used became valid.  <blockquote class=\"note\">NOTE&nbsp; The indication of edition may be sufficient to identify the classification source uniquely but the edition date is provided as an optional attribute to enable more precise identification where required.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE The data type has been changed to <em>IfcDate</em>, the date string according to ISO8601.</blockquote>")]
		public IfcDate? EditionDate { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The name or label by which the classification used is normally known.  <blockquote class=\"note\">NOTE&nbsp; Examples of names include CI/SfB, Masterformat, BSAB, Uniclass, STABU, DIN276, DIN277 etc.</blockquote>")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Additional description provided for the classification.  <blockquote class=\"change-ifc2x4\">    IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.  </blockquote>")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Resource identifier or locator, provided as URI, URN or URL, of the classification.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>  ")]
		public IfcURIReference? Location { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("The delimiter tokens that are used to mark the boundaries of individual facets (substrings) in a classification reference.  <br><br>  This typically applies then the <em>IfcClassification</em> is used in  conjuction with <em>IfcClassificationReference</em>'s. If only one <em>ReferenceToken</em> is provided, it applies to all boundaries of individual facets, if more than one <em>ReferenceToken</em> are provided, the first token applies to the first boundary, the second token to the second boundary, and the n<super>th</super> token to the n<super>th</super> and any additional boundary.     <blockquote class=\"note\">NOTE&nbsp; Tokens are typically recommended within the classification itself and each token will have a particular role.</blockquote>  <blockquote class=\"example\">  EXAMPLE&nbsp;1 To indicate that the facet delimiter used for DIN277-2 reference key \"2.1\" (\"Office rooms\") is \".\", a single <em>ReferenceToken</em> ['.'] is provided. To indicate that the facet delimiter used for Omniclass Table 13 (space by function) reference key \"13-15 11 34 11\" (\"Office\") are \"-\" and \" \", two <em>ReferenceToken</em>'s ['-', ' '] are provided.   </blockquote>  <blockquote class=\"example\">  EXAMPLE&nbsp;2 The use of <em>ReferenceTokens</em> can also be extended to include masks. The use need to be agreed in view definitions or implementer agreements that stipulates a \"mask syntax\" that should be used.    </blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		[MinLength(1)]
		public IList<IfcIdentifier> ReferenceTokens { get; protected set; }
	
		[InverseProperty("RelatingClassification")] 
		[Description("The classification with which objects are associated.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesClassification> ClassificationForObjects { get; protected set; }
	
		[InverseProperty("ReferencedSource")] 
		[XmlElement("IfcClassificationReference")]
		[Description("The classification references to which the classification applies. It can either be the final classification notation, or an intermediate classification item.")]
		public ISet<IfcClassificationReference> HasReferences { get; protected set; }
	
	
		public IfcClassification(IfcLabel? __Source, IfcLabel? __Edition, IfcDate? __EditionDate, IfcLabel __Name, IfcText? __Description, IfcURIReference? __Location, IfcIdentifier[] __ReferenceTokens)
		{
			this.Source = __Source;
			this.Edition = __Edition;
			this.EditionDate = __EditionDate;
			this.Name = __Name;
			this.Description = __Description;
			this.Location = __Location;
			this.ReferenceTokens = new List<IfcIdentifier>(__ReferenceTokens);
			this.ClassificationForObjects = new HashSet<IfcRelAssociatesClassification>();
			this.HasReferences = new HashSet<IfcClassificationReference>();
		}
	
	
	}
	
}
