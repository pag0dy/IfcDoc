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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcRelCoversBldgElements : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Relationship to the element that is covered. It includes building elements for coverings such as flooring or cladding, or distribution elements for coverings such as sleeving or wrapping.")]
		[Required()]
		public IfcElement RelatingBuildingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Relationship to the set of coverings that are assigned to this element.  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcCovering> RelatedCoverings { get; protected set; }
	
	
		public IfcRelCoversBldgElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingBuildingElement, IfcCovering[] __RelatedCoverings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingBuildingElement = __RelatingBuildingElement;
			this.RelatedCoverings = new HashSet<IfcCovering>(__RelatedCoverings);
		}
	
	
	}
	
}
