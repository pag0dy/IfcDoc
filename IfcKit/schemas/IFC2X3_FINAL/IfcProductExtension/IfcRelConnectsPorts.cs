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
	[Guid("d24083e6-d4be-4177-a59e-169e391fd1ee")]
	public partial class IfcRelConnectsPorts : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPort _RelatingPort;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcPort _RelatedPort;
	
		[DataMember(Order=2)] 
		IfcElement _RealizingElement;
	
	
		public IfcRelConnectsPorts()
		{
		}
	
		public IfcRelConnectsPorts(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPort __RelatingPort, IfcPort __RelatedPort, IfcElement __RealizingElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingPort = __RelatingPort;
			this._RelatedPort = __RelatedPort;
			this._RealizingElement = __RealizingElement;
		}
	
		[Description("Reference to the first port that is connected by the objectified relationship.")]
		public IfcPort RelatingPort { get { return this._RelatingPort; } set { this._RelatingPort = value;} }
	
		[Description("Reference to the second port that is connected by the objectified relationship.")]
		public IfcPort RelatedPort { get { return this._RelatedPort; } set { this._RelatedPort = value;} }
	
		[Description("Defines the element that realizes a port connection relationship.")]
		public IfcElement RealizingElement { get { return this._RealizingElement; } set { this._RealizingElement = value;} }
	
	
	}
	
}
