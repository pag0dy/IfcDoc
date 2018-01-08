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
	[Guid("d6845f56-93c2-41ea-bd7e-edbfea1e9068")]
	public partial class IfcClassificationReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationSelect
	{
		[DataMember(Order=0)] 
		IfcClassificationReferenceSelect _ReferencedSource;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcIdentifier? _Sort;
	
		[InverseProperty("RelatingClassification")] 
		ISet<IfcRelAssociatesClassification> _ClassificationRefForObjects = new HashSet<IfcRelAssociatesClassification>();
	
		[InverseProperty("ReferencedSource")] 
		ISet<IfcClassificationReference> _HasReferences = new HashSet<IfcClassificationReference>();
	
	
		[Description("<EPM-HTML>\r\nThe classification system or source that is referenced.\r\n<blockquote " +
	    "class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Data type changed to <em>IfcClassificati" +
	    "onReferenceSelect</em>.</blockquote>\r\n</EPM-HTML>\r\n</EPM-HTML>")]
		public IfcClassificationReferenceSelect ReferencedSource { get { return this._ReferencedSource; } set { this._ReferencedSource = value;} }
	
		[Description("<EPM-HTML>\r\nDescription of the classification reference for informational purpose" +
	    "s.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at t" +
	    "he end of the attribute list.</blockquote>\r\n</EPM-HTML>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"<EPM-HTML>
	Optional identifier to sort the set of classification references within the referenced source (either a classification facet of higher level, or the classification system itself).
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>
	</EPM-HTML>")]
		public IfcIdentifier? Sort { get { return this._Sort; } set { this._Sort = value;} }
	
		[Description("<EPM-HTML>\r\nThe classification reference with which objects are associated.\r\n<blo" +
	    "ckquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquo" +
	    "te>\r\n</EPM-HTML>")]
		public ISet<IfcRelAssociatesClassification> ClassificationRefForObjects { get { return this._ClassificationRefForObjects; } }
	
		[Description(@"<EPM-HTML>
	The parent classification references to which this child classification reference applies. It can either be the final classification item leaf node, or an intermediate classification item.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse attribute.</blockquote>
	</EPM-HTML>")]
		public ISet<IfcClassificationReference> HasReferences { get { return this._HasReferences; } }
	
	
	}
	
}
