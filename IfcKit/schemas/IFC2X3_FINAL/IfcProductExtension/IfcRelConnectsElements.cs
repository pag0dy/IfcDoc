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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("014665cc-d91c-4aeb-b4eb-ae4b758e1172")]
	public partial class IfcRelConnectsElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		IfcConnectionGeometry _ConnectionGeometry;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcElement _RelatedElement;
	
	
		public IfcRelConnectsElements()
		{
		}
	
		public IfcRelConnectsElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._ConnectionGeometry = __ConnectionGeometry;
			this._RelatingElement = __RelatingElement;
			this._RelatedElement = __RelatedElement;
		}
	
		[Description("Relationship to the control class, that provides the geometrical constraints of t" +
	    "he connection.\r\n")]
		public IfcConnectionGeometry ConnectionGeometry { get { return this._ConnectionGeometry; } set { this._ConnectionGeometry = value;} }
	
		[Description("Reference to an Element that is connected by the objectified relationship.\r\n")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to an Element that is connected by the objectified relationship.\r\n")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
	
	}
	
}
