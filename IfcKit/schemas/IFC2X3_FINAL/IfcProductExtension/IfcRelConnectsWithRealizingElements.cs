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
	[Guid("d323c3ef-322b-43ec-85c2-f5eab3b2ec47")]
	public partial class IfcRelConnectsWithRealizingElements : IfcRelConnectsElements
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcElement> _RealizingElements = new HashSet<IfcElement>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ConnectionType;
	
	
		public IfcRelConnectsWithRealizingElements()
		{
		}
	
		public IfcRelConnectsWithRealizingElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcConnectionGeometry __ConnectionGeometry, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcElement[] __RealizingElements, IfcLabel? __ConnectionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ConnectionGeometry, __RelatingElement, __RelatedElement)
		{
			this._RealizingElements = new HashSet<IfcElement>(__RealizingElements);
			this._ConnectionType = __ConnectionType;
		}
	
		[Description("Defines the elements that realize a connection relationship.")]
		public ISet<IfcElement> RealizingElements { get { return this._RealizingElements; } }
	
		[Description("The type of the connection given for informal purposes, it may include labels, li" +
	    "ke \'joint\', \'rigid joint\', \'flexible joint\', etc.")]
		public IfcLabel? ConnectionType { get { return this._ConnectionType; } set { this._ConnectionType = value;} }
	
	
	}
	
}
