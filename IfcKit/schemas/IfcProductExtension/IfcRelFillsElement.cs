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
	public partial class IfcRelFillsElement : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("Opening Element being filled by virtue of this relationship.  ")]
		[Required()]
		public IfcOpeningElement RelatingOpeningElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  Reference to <strike>building</strike> element that occupies fully or partially the associated opening.  <blockquote><small><font color=\"#ff0000\">  IFC2x PLATFORM CHANGE: The data type has been changed from <i>IfcBuildingElement</i> to <i>IfcElement</i> with upward compatibility for file based exchange.  </font><small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcElement RelatedBuildingElement { get; set; }
	
	
		public IfcRelFillsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcOpeningElement __RelatingOpeningElement, IfcElement __RelatedBuildingElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingOpeningElement = __RelatingOpeningElement;
			this.RelatedBuildingElement = __RelatedBuildingElement;
		}
	
	
	}
	
}
