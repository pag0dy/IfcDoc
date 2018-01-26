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
	[Guid("c61fb4db-0cf8-48c7-8d8f-aa7dc803cb0c")]
	public partial class IfcRelContainedInSpatialStructure : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcProduct> _RelatedElements = new HashSet<IfcProduct>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcSpatialStructureElement _RelatingStructure;
	
	
		public IfcRelContainedInSpatialStructure()
		{
		}
	
		public IfcRelContainedInSpatialStructure(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProduct[] __RelatedElements, IfcSpatialStructureElement __RelatingStructure)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedElements = new HashSet<IfcProduct>(__RelatedElements);
			this._RelatingStructure = __RelatingStructure;
		}
	
		[Description(@"<EPM-HTML>
	Set of <strike>elements</strike> products, which are contained within this level of the spatial structure hierarchy.
	<blockquote><font color=""#ff0000""><small>
	IFC2x PLATFORM CHANGE&nbsp; The data type has been changed from <i>IfcElement</i> to <i>IfcProduct</i> with upward compatibility
	<small></font></blockquote>
	</EPM-HTML>
	")]
		public ISet<IfcProduct> RelatedElements { get { return this._RelatedElements; } }
	
		[Description("<EPM-HTML>\r\nSpatial structure element, within which the element is contained. Any" +
	    " element can only be contained within one element of the project spatial structu" +
	    "re.\r\n</EPM-HTML>")]
		public IfcSpatialStructureElement RelatingStructure { get { return this._RelatingStructure; } set { this._RelatingStructure = value;} }
	
	
	}
	
}
