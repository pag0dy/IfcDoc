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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("6efcded0-4fa6-4c52-82e9-d250dbb9bcb0")]
	public partial class IfcRelReferencedInSpatialStructure : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcProduct> _RelatedElements = new HashSet<IfcProduct>();
	
		[DataMember(Order=1)] 
		[XmlIgnore]
		[Required()]
		IfcSpatialElement _RelatingStructure;
	
	
		public IfcRelReferencedInSpatialStructure()
		{
		}
	
		public IfcRelReferencedInSpatialStructure(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProduct[] __RelatedElements, IfcSpatialElement __RelatingStructure)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedElements = new HashSet<IfcProduct>(__RelatedElements);
			this._RelatingStructure = __RelatingStructure;
		}
	
		[Description(@"Set of products, which are referenced within this level of the spatial structure hierarchy.
	<blockquote class=""note"">NOTE&nbsp; Referenced elements are contained elsewhere within the spatial structure, they are referenced additionally by this spatial structure element, e.g., because they span several stories.</blockquote>")]
		public ISet<IfcProduct> RelatedElements { get { return this._RelatedElements; } }
	
		[Description(@"Spatial structure element, within which the element is referenced. Any element can be contained within zero, one or many elements of the project spatial and zoning structure.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute <em>RelatingStructure</em> as been promoted to the new supertype <em>IfcSpatialElement</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcSpatialElement RelatingStructure { get { return this._RelatingStructure; } set { this._RelatingStructure = value;} }
	
	
	}
	
}
