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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	public partial class IfcRelFlowControlElements : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("References control elements which may be used to impart control on the Distribution Element.  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcDistributionControlElement> RelatedControlElements { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Relationship to a distribution flow element  ")]
		[Required()]
		public IfcDistributionFlowElement RelatingFlowElement { get; set; }
	
	
		public IfcRelFlowControlElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcDistributionControlElement[] __RelatedControlElements, IfcDistributionFlowElement __RelatingFlowElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatedControlElements = new HashSet<IfcDistributionControlElement>(__RelatedControlElements);
			this.RelatingFlowElement = __RelatingFlowElement;
		}
	
	
	}
	
}
