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
	[Guid("61792a4b-dbd0-4dd6-9d1d-5af75a4780a8")]
	public partial class IfcRelInterferesElements : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcElement _RelatedElement;
	
		[DataMember(Order=2)] 
		[XmlElement]
		IfcConnectionGeometry _InterferenceGeometry;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcIdentifier? _InterferenceType;
	
		[DataMember(Order=4)] 
		[Required()]
		Boolean? _ImpliedOrder;
	
	
		public IfcRelInterferesElements()
		{
		}
	
		public IfcRelInterferesElements(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingElement, IfcElement __RelatedElement, IfcConnectionGeometry __InterferenceGeometry, IfcIdentifier? __InterferenceType, Boolean? __ImpliedOrder)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingElement = __RelatingElement;
			this._RelatedElement = __RelatedElement;
			this._InterferenceGeometry = __InterferenceGeometry;
			this._InterferenceType = __InterferenceType;
			this._ImpliedOrder = __ImpliedOrder;
		}
	
		[Description(@"Reference to a subtype of <em>IfcElement</> that is the <em>RelatingElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatingElement</em> may carry the notion to be the element from which the interference geometry should be subtracted.")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description(@"Reference to a subtype of <em>IfcElement</> that is the <em>RelatedElement</em> in the interference relationship. Depending on the value of <em>ImpliedOrder</em> the <em>RelatedElement</em> may carry the notion to be the element from which the interference geometry should not be subtracted.")]
		public IfcElement RelatedElement { get { return this._RelatedElement; } set { this._RelatedElement = value;} }
	
		[Description("The geometric shape representation of the interference geometry that is provided " +
	    "in the object coordinate system of the <em>RelatingElement</em> (mandatory) and " +
	    "in the object coordinate system of the <em>RelatedElement</em> (optionally).")]
		public IfcConnectionGeometry InterferenceGeometry { get { return this._InterferenceGeometry; } set { this._InterferenceGeometry = value;} }
	
		[Description("Optional identifier that describes the nature of the interference. Examples could" +
	    " include \'Clash\', \'ProvisionForVoid\', etc.")]
		public IfcIdentifier? InterferenceType { get { return this._InterferenceType; } set { this._InterferenceType = value;} }
	
		[Description(@"Logical value indicating whether the interference geometry should be subtracted from the <em>RelatingElement</em> (if TRUE), or whether it should be either subtracted from the <em>RelatingElement</em> or the <em>RelatedElement</em> (if FALSE), or whether no indication can be provided (if UNKNOWN).")]
		public Boolean? ImpliedOrder { get { return this._ImpliedOrder; } set { this._ImpliedOrder = value;} }
	
	
	}
	
}
