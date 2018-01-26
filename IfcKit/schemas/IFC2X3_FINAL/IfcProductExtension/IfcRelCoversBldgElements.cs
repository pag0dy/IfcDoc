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
	[Guid("f6517b91-706e-4d91-bdf5-da5f0c130195")]
	public partial class IfcRelCoversBldgElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcElement _RelatingBuildingElement;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcCovering> _RelatedCoverings = new HashSet<IfcCovering>();
	
	
		public IfcRelCoversBldgElements()
		{
		}
	
		public IfcRelCoversBldgElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingBuildingElement, IfcCovering[] __RelatedCoverings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingBuildingElement = __RelatingBuildingElement;
			this._RelatedCoverings = new HashSet<IfcCovering>(__RelatedCoverings);
		}
	
		[Description("<EPM-HTML>\r\nRelationship to the element that is covered.\r\n</EPM-HTML>\r\n")]
		public IfcElement RelatingBuildingElement { get { return this._RelatingBuildingElement; } set { this._RelatingBuildingElement = value;} }
	
		[Description("Relationship to the set of coverings at this element.\r\n")]
		public ISet<IfcCovering> RelatedCoverings { get { return this._RelatedCoverings; } }
	
	
	}
	
}
