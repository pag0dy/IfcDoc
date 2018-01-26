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
	[Guid("643ec1cf-e582-48d2-93ed-f5463a3a7f58")]
	public partial class IfcRelConnectsPortToElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcPort _RelatingPort;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcElement _RelatedElement;
	
	
		public IfcRelConnectsPortToElement()
		{
		}
	
		public IfcRelConnectsPortToElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPort __RelatingPort, IfcElement __RelatedElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingPort = __RelatingPort;
			this._RelatedElement = __RelatedElement;
		}
	
		[Description("Reference to an Port that is connected by the objectified relationship.")]
		public IfcPort RelatingPort { get { return this._RelatingPort; } set { this._RelatingPort = value;} }
	
		[Description("Reference to an Element that is connected by the objectified relationship.")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
	
	}
	
}
