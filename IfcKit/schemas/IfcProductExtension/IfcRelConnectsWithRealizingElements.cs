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
	public partial class IfcRelConnectsWithRealizingElements : IfcRelConnectsElements
	{
		[DataMember(Order = 0)] 
		[Description("Defines the elements that realize a connection relationship.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcElement> RealizingElements { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The type of the connection given for informal purposes, it may include labels, like 'joint', 'rigid joint', 'flexible joint', etc.")]
		public IfcLabel? ConnectionType { get; set; }
	
	
		public IfcRelConnectsWithRealizingElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcElement[] __RealizingElements, IfcLabel? __ConnectionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ConnectionGeometry, __RelatingElement, __RelatedElement)
		{
			this.RealizingElements = new HashSet<IfcElement>(__RealizingElements);
			this.ConnectionType = __ConnectionType;
		}
	
	
	}
	
}
