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
	[Guid("3a589d07-713f-4a7d-90a7-1b9c3b668e2b")]
	public partial class IfcRelProjectsElement : IfcRelDecomposes
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcFeatureElementAddition _RelatedFeatureElement;
	
	
		public IfcRelProjectsElement()
		{
		}
	
		public IfcRelProjectsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingElement, IfcFeatureElementAddition __RelatedFeatureElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingElement = __RelatingElement;
			this._RelatedFeatureElement = __RelatedFeatureElement;
		}
	
		[Description("Element at which a projection is created by the associated <em>IfcProjectionEleme" +
	    "nt</em>.")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("Reference to the <em>IfcFeatureElementAddition</em> that defines an addition to t" +
	    "he volume of the element, by using a Boolean addition operation. An example is a" +
	    " projection at the associated element.")]
		public IfcFeatureElementAddition RelatedFeatureElement { get { return this._RelatedFeatureElement; } set { this._RelatedFeatureElement = value;} }
	
	
	}
	
}
