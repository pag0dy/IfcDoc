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
	[Guid("38e3c74b-486e-4323-980b-6375977d83ae")]
	public partial class IfcRelFillsElement : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlIgnore]
		[Required()]
		IfcOpeningElement _RelatingOpeningElement;
	
		[DataMember(Order=1)] 
		[XmlElement]
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
	
		[Description(@"Reference to <strike>building</strike> element that occupies fully or partially the associated opening.
	<blockquote class=""change-ifc2x"">IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuildingElement</em> to <em>IfcElement</em> with upward compatibility for file based exchange.</blockquote>")]
		public IfcElement RelatedBuildingElement { get { return this._RelatedBuildingElement; } set { this._RelatedBuildingElement = value;} }
	
	
	}
	
}
