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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcClassificationReference : IfcExternalReference,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcClassificationSelect
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("The classification system or source that is referenced.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Data type changed to <em>IfcClassificationReferenceSelect</em>.</blockquote>")]
		public IfcClassificationReferenceSelect ReferencedSource { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Description of the classification reference for informational purposes.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optional identifier to sort the set of classification references within the referenced source (either a classification facet of higher level, or the classification system itself).  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute added at the end of the attribute list.</blockquote>")]
		public IfcIdentifier? Sort { get; set; }
	
		[InverseProperty("RelatingClassification")] 
		[Description("The classification reference with which objects are associated.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcRelAssociatesClassification> ClassificationRefForObjects { get; protected set; }
	
		[InverseProperty("ReferencedSource")] 
		[XmlElement("IfcClassificationReference")]
		[Description("The parent classification references to which this child classification reference applies. It can either be the final classification item leaf node, or an intermediate classification item.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  New inverse attribute.</blockquote>")]
		public ISet<IfcClassificationReference> HasReferences { get; protected set; }
	
	
		public IfcClassificationReference(IfcURIReference? __Location, IfcIdentifier? __Identification, IfcLabel? __Name, IfcClassificationReferenceSelect __ReferencedSource, IfcText? __Description, IfcIdentifier? __Sort)
			: base(__Location, __Identification, __Name)
		{
			this.ReferencedSource = __ReferencedSource;
			this.Description = __Description;
			this.Sort = __Sort;
			this.ClassificationRefForObjects = new HashSet<IfcRelAssociatesClassification>();
			this.HasReferences = new HashSet<IfcClassificationReference>();
		}
	
	
	}
	
}
