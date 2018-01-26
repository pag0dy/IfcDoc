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
	[Guid("2749c418-fb5d-400d-92ce-0c491a55cbd7")]
	public partial class IfcRelConnectsElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement]
		IfcConnectionGeometry _ConnectionGeometry;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=2)] 
		[XmlElement]
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
	
		[Description("The geometric shape representation of the connection geometry that is provided in" +
	    " the object coordinate system of the <em>RelatingElement</em> (mandatory) and in" +
	    " the object coordinate system of the <em>RelatedElement</em> (optionally).")]
		public IfcConnectionGeometry ConnectionGeometry { get { return this._ConnectionGeometry; } set { this._ConnectionGeometry = value;} }
	
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection" +
	    " relationship in the role of <em>RelatingElement</em>.\r\n")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to a subtype of <em>IfcElement</em> that is connected by the connection" +
	    " relationship in the role of <em>RelatedElement</em>.")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
	
	}
	
}
