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

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcRelConnectsPortToElement : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("Reference to an Port that is connected by the objectified relationship.")]
		[Required()]
		public IfcPort RelatingPort { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to an Element that is connected by the objectified relationship.")]
		[Required()]
		public IfcElement RelatedElement { get; set; }
	
	
		public IfcRelConnectsPortToElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPort __RelatingPort, IfcElement __RelatedElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingPort = __RelatingPort;
			this.RelatedElement = __RelatedElement;
		}
	
	
	}
	
}
