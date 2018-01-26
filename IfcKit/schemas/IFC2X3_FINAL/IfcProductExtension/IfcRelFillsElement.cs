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
	[Guid("9a25a464-da5d-45c5-97ee-51a3a57ba941")]
	public partial class IfcRelFillsElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcOpeningElement _RelatingOpeningElement;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcElement _RelatedBuildingElement;
	
	
		public IfcRelFillsElement()
		{
		}
	
		public IfcRelFillsElement(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcOpeningElement __RelatingOpeningElement, IfcElement __RelatedBuildingElement)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingOpeningElement = __RelatingOpeningElement;
			this._RelatedBuildingElement = __RelatedBuildingElement;
		}
	
		[Description("Opening Element being filled by virtue of this relationship.\r\n")]
		public IfcOpeningElement RelatingOpeningElement { get { return this._RelatingOpeningElement; } set { this._RelatingOpeningElement = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to <strike>building</strike> element that occupies fully or partially the associated opening.
	<blockquote><small><font color=""#ff0000"">
	IFC2x PLATFORM CHANGE: The data type has been changed from <i>IfcBuildingElement</i> to <i>IfcElement</i> with upward compatibility for file based exchange.
	</font><small></blockquote>
	</EPM-HTML>")]
		public IfcElement RelatedBuildingElement { get { return this._RelatedBuildingElement; } set { this._RelatedBuildingElement = value;} }
	
	
	}
	
}
