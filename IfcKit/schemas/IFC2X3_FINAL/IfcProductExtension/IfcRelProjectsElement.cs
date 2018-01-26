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
	[Guid("521ef25f-3a02-4edc-9334-c735fc651c7d")]
	public partial class IfcRelProjectsElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcElement _RelatingElement;
	
		[DataMember(Order=1)] 
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
	
		[Description("<EPM-HTML>\r\nElement at which a projection is created by the associated <I>IfcProj" +
	    "ectionElement</I>.\r\n</EPM-HTML>")]
		public IfcElement RelatingElement { get { return this._RelatingElement; } set { this._RelatingElement = value;} }
	
		[Description("<EPM-HTML>\r\nReference to the <I>IfcFeatureElementAddition</I> that defines an add" +
	    "ition to the volume of the element, by using a Boolean addition operation. An ex" +
	    "ample is a projection at the associated element.\r\n</EPM-HTML>")]
		public IfcFeatureElementAddition RelatedFeatureElement { get { return this._RelatedFeatureElement; } set { this._RelatedFeatureElement = value;} }
	
	
	}
	
}
