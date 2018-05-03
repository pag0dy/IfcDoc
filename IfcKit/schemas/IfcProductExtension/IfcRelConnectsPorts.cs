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
	public partial class IfcRelConnectsPorts : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to the first port that is connected by the objectified relationship.")]
		[Required()]
		public IfcPort RelatingPort { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to the second port that is connected by the objectified relationship.")]
		[Required()]
		public IfcPort RelatedPort { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Defines the element that realizes a port connection relationship.")]
		public IfcElement RealizingElement { get; set; }
	
	
		public IfcRelConnectsPorts(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPort __RelatingPort, IfcPort __RelatedPort, IfcElement __RealizingElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingPort = __RelatingPort;
			this.RelatedPort = __RelatedPort;
			this.RealizingElement = __RealizingElement;
		}
	
	
	}
	
}
