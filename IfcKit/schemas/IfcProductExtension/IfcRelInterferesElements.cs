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
	public partial class IfcRelInterferesElements : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to a subtype of <em>IfcElement</> that is the <em>RelatingElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatingElement</em> may carry the notion to be the element from which the interference geometry should be subtracted.")]
		[Required()]
		public IfcElement RelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to a subtype of <em>IfcElement</> that is the <em>RelatedElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatedElement</em> may carry the notion to be the element from which the interference geometry should not be subtracted.")]
		[Required()]
		public IfcElement RelatedElement { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("The geometric shape representation of the interference geometry that is provided in the object coordinate system of the <em>RelatingElement</em> (mandatory) and in the object coordinate system of the <em>RelatedElement</em> (optionally).")]
		public IfcConnectionGeometry InterferenceGeometry { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Optional identifier that describes the nature of the interference. Examples could include 'Clash', 'ProvisionForVoid', etc.")]
		public IfcIdentifier? InterferenceType { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Logical value indicating whether the interference geometry should be subtracted from the <em>RelatingElement</em> (if TRUE), or whether it should be either subtracted from the <em>RelatingElement</em> or the <em>RelatedElement</em> (if FALSE), or whether no indication can be provided (if UNKNOWN).")]
		[Required()]
		public Boolean? ImpliedOrder { get; set; }
	
	
		public IfcRelInterferesElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcConnectionGeometry __InterferenceGeometry, IfcIdentifier? __InterferenceType, Boolean? __ImpliedOrder)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingElement = __RelatingElement;
			this.RelatedElement = __RelatedElement;
			this.InterferenceGeometry = __InterferenceGeometry;
			this.InterferenceType = __InterferenceType;
			this.ImpliedOrder = __ImpliedOrder;
		}
	
	
	}
	
}
