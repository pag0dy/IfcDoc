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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("63704ce8-f787-4e3a-9bf7-71c7b61b60ac")]
	public partial class IfcClassificationItemRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcClassificationItem _RelatingItem;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcClassificationItem> _RelatedItems = new HashSet<IfcClassificationItem>();
	
	
		[Description("The parent level item in a classification structure that is used for relating the" +
	    " child level items.")]
		public IfcClassificationItem RelatingItem { get { return this._RelatingItem; } set { this._RelatingItem = value;} }
	
		[Description("The child level items in a classification structure that are related to the paren" +
	    "t level item.")]
		public ISet<IfcClassificationItem> RelatedItems { get { return this._RelatedItems; } }
	
	
	}
	
}
