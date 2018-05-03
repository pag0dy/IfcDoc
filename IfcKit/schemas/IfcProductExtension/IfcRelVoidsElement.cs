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
	public partial class IfcRelVoidsElement : IfcRelDecomposes
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("Reference to element in which a void is created by associated feature subtraction element.  <blockquote class=\"change-ifc2x\">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuildingElement</em> to <em>IfcElement</em> with upward compatibility for file based exchange.</blockquote>  ")]
		[Required()]
		public IfcElement RelatingBuildingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to the feature subtraction element which defines a void in the associated element.  <blockquote class=\"change-ifc2x\">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcOpeningElement</em> to <em>IfcFeatureElementSubtraction</em> with upward compatibility for file based exchange.</blockquote>")]
		[Required()]
		public IfcFeatureElementSubtraction RelatedOpeningElement { get; set; }
	
	
		public IfcRelVoidsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingBuildingElement, IfcFeatureElementSubtraction __RelatedOpeningElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingBuildingElement = __RelatingBuildingElement;
			this.RelatedOpeningElement = __RelatedOpeningElement;
		}
	
	
	}
	
}
