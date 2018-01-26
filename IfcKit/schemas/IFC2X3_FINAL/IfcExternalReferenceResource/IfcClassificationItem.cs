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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("5d2e6844-fce4-41b9-941e-0f7525c12528")]
	public partial class IfcClassificationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcClassificationNotationFacet _Notation;
	
		[DataMember(Order=1)] 
		IfcClassification _ItemOf;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Title;
	
		[InverseProperty("RelatedItems")] 
		[MaxLength(1)]
		ISet<IfcClassificationItemRelationship> _IsClassifiedItemIn = new HashSet<IfcClassificationItemRelationship>();
	
		[InverseProperty("RelatingItem")] 
		[MaxLength(1)]
		ISet<IfcClassificationItemRelationship> _IsClassifyingItemIn = new HashSet<IfcClassificationItemRelationship>();
	
	
		public IfcClassificationItem()
		{
		}
	
		public IfcClassificationItem(IfcClassificationNotationFacet __Notation, IfcClassification __ItemOf, IfcLabel __Title)
		{
			this._Notation = __Notation;
			this._ItemOf = __ItemOf;
			this._Title = __Title;
		}
	
		[Description("The notations from within a classification item that are used within the project." +
	    "\r\nNOTE: In Uniclass this label is called the Code, in UDC it is called the Class" +
	    " Number.")]
		public IfcClassificationNotationFacet Notation { get { return this._Notation; } set { this._Notation = value;} }
	
		[Description(@"The classification that is the source for the uppermost level of the classification item hierarchy used.
	NOTE: Where a classification item hierarchy is developed within the IFC model, only the uppermost level needs to refer to the classification system or source from which it is derived since all other levels of the hierachy will refer to the source by virtue of their containment by the uppermost level. However, the uppermost level MUST point back to the classification source by virtue of the fact that it is not contained by a higher level classification item.")]
		public IfcClassification ItemOf { get { return this._ItemOf; } set { this._ItemOf = value;} }
	
		[Description(@"The name of the classification item.
	NOTE: Examples of the above attributes from Uniclass: 
	A classification item in Uniclass has a notation ""L6814"" which has the title ""Tanking"".
	It has a parent notation ""L681"" which has the title ""Proofings, insulation"".
	")]
		public IfcLabel Title { get { return this._Title; } set { this._Title = value;} }
	
		[Description("Identifies the relationship in which the role of ClassifiedItem is taken.")]
		public ISet<IfcClassificationItemRelationship> IsClassifiedItemIn { get { return this._IsClassifiedItemIn; } }
	
		[Description("Identifies the relationship in which the role of ClassifyingItem is taken.")]
		public ISet<IfcClassificationItemRelationship> IsClassifyingItemIn { get { return this._IsClassifyingItemIn; } }
	
	
	}
	
}
