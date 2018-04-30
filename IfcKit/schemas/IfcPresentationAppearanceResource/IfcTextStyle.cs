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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("A character style to be used for presented text.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Superfluous select type IfcCharacterStyleSelect has been removed.  </blockquote>")]
		public IfcTextStyleForDefinedFont TextCharacterAppearance { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The style applied to the text block for its visual appearance.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The attribute <em>TextBlockStyle</em> has been changed from SET[1:?] to a non-aggregated optional and renamed into <em>TextStyles</em>.</blockquote>  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The IfcTextStyleWithBoxCharacteristics and the now superfluous select type IfcTextStyleSelect have been removed.  </blockquote>")]
		public IfcTextStyleTextModel TextStyle { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The style applied to the text font for its visual appearance. It defines the font family, font style, weight and size.    <blockquote class=\"change-ifc2x2\">IFC2x2 Add2 CHANGE The attribute <em>TextFontStyle</em> is a new attribute attached to <em>IfcTextStyle</em>.    </blockquote>")]
		[Required()]
		public IfcTextFontSelect TextFontStyle { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indication whether the length measures provided for the presentation style are model based, or draughting based.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.  </blockquote>")]
		public IfcBoolean? ModelOrDraughting { get; set; }
	
	
		public IfcTextStyle(IfcLabel? __Name, IfcTextStyleForDefinedFont __TextCharacterAppearance, IfcTextStyleTextModel __TextStyle, IfcTextFontSelect __TextFontStyle, IfcBoolean? __ModelOrDraughting)
			: base(__Name)
		{
			this.TextCharacterAppearance = __TextCharacterAppearance;
			this.TextStyle = __TextStyle;
			this.TextFontStyle = __TextFontStyle;
			this.ModelOrDraughting = __ModelOrDraughting;
		}
	
	
	}
	
}
