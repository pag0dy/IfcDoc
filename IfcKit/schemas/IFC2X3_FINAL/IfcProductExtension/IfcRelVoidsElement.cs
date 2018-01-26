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
	[Guid("907e3b05-19b5-4d83-a001-b63a5a87ef22")]
	public partial class IfcRelVoidsElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcElement _RelatingBuildingElement;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcFeatureElementSubtraction _RelatedOpeningElement;
	
	
		public IfcRelVoidsElement()
		{
		}
	
		public IfcRelVoidsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcElement __RelatingBuildingElement, IfcFeatureElementSubtraction __RelatedOpeningElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingBuildingElement = __RelatingBuildingElement;
			this._RelatedOpeningElement = __RelatedOpeningElement;
		}
	
		[Description(@"<EPM-HTML>
	Reference to <strike>building</strike> element in which a void is created by associated <strike>opening</strike> feature subtraction element.
	<blockquote><small><font color=""#ff0000"">
	IFC2x PLATFORM CHANGE: The data type has been changed from <i>IfcBuildingElement</i> to <i>IfcElement</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>
	")]
		public IfcElement RelatingBuildingElement { get { return this._RelatingBuildingElement; } set { this._RelatingBuildingElement = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to the <strike>opening</strike> feature subtraction element which defines a void in the associated <strike>opening</strike> element.
	<blockquote><small><font color=""#ff0000"">
	IFC2x PLATFORM CHANGE&nbsp; The data type has been changed from <i>IfcOpeningElement</i> to <i>IfcFeatureElementSubtraction</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>")]
		public IfcFeatureElementSubtraction RelatedOpeningElement { get { return this._RelatedOpeningElement; } set { this._RelatedOpeningElement = value;} }
	
	
	}
	
}
