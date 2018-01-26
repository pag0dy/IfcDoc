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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("d6845f56-93c2-41ea-bd7e-edbfea1e9068")]
	public partial class IfcClassificationReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationSelect
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
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
		[XmlElement("IfcClassificationReference")]
		ISet<IfcClassificationReference> _HasReferences = new HashSet<IfcClassificationReference>();
	
	
		public IfcClassificationReference()
		{
		}
	
		public IfcClassificationReference(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name, IfcClassificationReferenceSelect __ReferencedSource, IfcText? __Description, IfcIdentifier? __Sort)
			: base(__Location, __Identification, __Name)
		{
			this._ReferencedSource = __ReferencedSource;
			this._Description = __Description;
			this._Sort = __Sort;
		}
	
		[Description("The classification system or source that is referenced.\r\n<blockquote class=\"chang" +
	    "e-ifc2x4\">IFC4 CHANGE&nbsp; Data type changed to <em>IfcClassificationReferenceS" +
	    "elect</em>.</blockquote>")]
		public IfcClassificationReferenceSelect ReferencedSource { get { return this._ReferencedSource; } set { this._ReferencedSource = value;} }
	
		[Description("Description of the classification reference for informational purposes.\r\n<blockqu" +
	    "ote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of th" +
	    "e attribute list.</blockquote>")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description(@"Optional identifier to sort the set of classification references within the referenced source (either a classification facet of higher level, or the classification system itself).
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		public IfcIdentifier? Sort { get { return this._Sort; } set { this._Sort = value;} }
	
		[Description("The classification reference with which objects are associated.\r\n<blockquote clas" +
	    "s=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesClassification> ClassificationRefForObjects { get { return this._ClassificationRefForObjects; } }
	
		[Description(@"The parent classification references to which this child classification reference applies. It can either be the final classification item leaf node, or an intermediate classification item.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  New inverse attribute.</blockquote>")]
		public ISet<IfcClassificationReference> HasReferences { get { return this._HasReferences; } }
	
	
	}
	
}
