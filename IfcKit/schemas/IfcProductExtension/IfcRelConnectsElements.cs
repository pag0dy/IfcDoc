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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	public partial class IfcRelConnectsElements : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The geometric shape representation of the connection geometry that is provided in the object coordinate system of the <em>RelatingElement</em> (mandatory) and in the object coordinate system of the <em>RelatedElement</em> (optionally).")]
		public IfcConnectionGeometry ConnectionGeometry { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection relationship in the role of <em>RelatingElement</em>.  ")]
		[Required()]
		public IfcElement RelatingElement { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection relationship in the role of <em>RelatedElement</em>.")]
		[Required()]
		public IfcElement RelatedElement { get; set; }
	
	
		public IfcRelConnectsElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ConnectionGeometry = __ConnectionGeometry;
			this.RelatingElement = __RelatingElement;
			this.RelatedElement = __RelatedElement;
		}
	
	
	}
	
}
