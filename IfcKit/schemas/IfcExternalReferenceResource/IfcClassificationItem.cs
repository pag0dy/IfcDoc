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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	public partial class IfcClassificationItem
	{
		[DataMember(Order = 0)] 
		[Description("The notations from within a classification item that are used within the project.  NOTE: In Uniclass this label is called the Code, in UDC it is called the Class Number.")]
		[Required()]
		public IfcClassificationNotationFacet Notation { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The classification that is the source for the uppermost level of the classification item hierarchy used.  NOTE: Where a classification item hierarchy is developed within the IFC model, only the uppermost level needs to refer to the classification system or source from which it is derived since all other levels of the hierachy will refer to the source by virtue of their containment by the uppermost level. However, the uppermost level MUST point back to the classification source by virtue of the fact that it is not contained by a higher level classification item.")]
		public IfcClassification ItemOf { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The name of the classification item.  NOTE: Examples of the above attributes from Uniclass:   A classification item in Uniclass has a notation \"L6814\" which has the title \"Tanking\".  It has a parent notation \"L681\" which has the title \"Proofings, insulation\".  ")]
		[Required()]
		public IfcLabel Title { get; set; }
	
		[InverseProperty("RelatedItems")] 
		[Description("Identifies the relationship in which the role of ClassifiedItem is taken.")]
		[MaxLength(1)]
		public ISet<IfcClassificationItemRelationship> IsClassifiedItemIn { get; protected set; }
	
		[InverseProperty("RelatingItem")] 
		[Description("Identifies the relationship in which the role of ClassifyingItem is taken.")]
		[MaxLength(1)]
		public ISet<IfcClassificationItemRelationship> IsClassifyingItemIn { get; protected set; }
	
	
		public IfcClassificationItem(IfcClassificationNotationFacet __Notation, IfcClassification __ItemOf, IfcLabel __Title)
		{
			this.Notation = __Notation;
			this.ItemOf = __ItemOf;
			this.Title = __Title;
			this.IsClassifiedItemIn = new HashSet<IfcClassificationItemRelationship>();
			this.IsClassifyingItemIn = new HashSet<IfcClassificationItemRelationship>();
		}
	
	
	}
	
}
