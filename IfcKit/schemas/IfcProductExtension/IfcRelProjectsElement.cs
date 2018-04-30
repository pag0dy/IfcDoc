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
	public partial class IfcRelProjectsElement : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  Element at which a projection is created by the associated <I>IfcProjectionElement</I>.  </EPM-HTML>")]
		[Required()]
		public IfcElement RelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  Reference to the <I>IfcFeatureElementAddition</I> that defines an addition to the volume of the element, by using a Boolean addition operation. An example is a projection at the associated element.  </EPM-HTML>")]
		[Required()]
		public IfcFeatureElementAddition RelatedFeatureElement { get; set; }
	
	
		public IfcRelProjectsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingElement, IfcFeatureElementAddition __RelatedFeatureElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingElement = __RelatingElement;
			this.RelatedFeatureElement = __RelatedFeatureElement;
		}
	
	
	}
	
}
