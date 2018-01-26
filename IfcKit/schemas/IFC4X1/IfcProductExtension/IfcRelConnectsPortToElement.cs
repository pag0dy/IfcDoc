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
	[Guid("ade898d9-502a-402f-b2b5-25e8a097c9e9")]
	public partial class IfcRelConnectsPortToElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcPort _RelatingPort;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcDistributionElement _RelatedElement;
	
	
		public IfcRelConnectsPortToElement()
		{
		}
	
		public IfcRelConnectsPortToElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPort __RelatingPort, IfcDistributionElement __RelatedElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingPort = __RelatingPort;
			this._RelatedElement = __RelatedElement;
		}
	
		[Description("Reference to an Port that is connected by the objectified relationship.")]
		public IfcPort RelatingPort { get { return this._RelatingPort; } set { this._RelatingPort = value;} }
	
		[Description("Reference to an <em>IfcDistributionElement</em> that has ports assigned.\r\n<blockq" +
	    "uote class=\"change-ifc2x4\">IFC4 CHANGE  Data type restricted to <em>IfcDistribut" +
	    "ionElement</em>.</blockquote>")]
		public IfcDistributionElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
	
	}
	
}
