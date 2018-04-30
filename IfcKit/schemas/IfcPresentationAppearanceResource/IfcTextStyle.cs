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
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order = 0)] 
		[Description("<EPM-HTML>  A character style to be used for presented text.  </EPM-HTML>")]
		public IfcCharacterStyleSelect TextCharacterAppearance { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("<EPM-HTML>  The style applied to the text block for its visual appearance.</br>  It defines the text block characteristics, either for vector based or monospace text fonts (see select item <i>IfcTextStyleWithBoxCharacteristics</i>), or for true type text fonts (see select item <i>IfcTextStyleTextModel</i>.    <blockquote><small><font color=\"#0000ff\">  IFC2x Edition 3 CHANGE&nbsp; The <i>attribute <i>TextBlockStyle</i> has been changed from SET[1:?] to a non-aggregated optional, it has been renamed from TextStyles.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcTextStyleSelect TextStyle { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("<EPM-HTML>  The style applied to the text font for its visual appearance.</br>  It defines the font family, font style, weight and size.    <blockquote><small><font color=\"#ff0000\">  IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>TextFontStyle</i> is a new attribute attached to <i>IfcTextStyle</i>.    </font></small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcTextFontSelect TextFontStyle { get; set; }
	
	
		public IfcTextStyle(IfcLabel? __Name, IfcCharacterStyleSelect __TextCharacterAppearance, IfcTextStyleSelect __TextStyle, IfcTextFontSelect __TextFontStyle)
			: base(__Name)
		{
			this.TextCharacterAppearance = __TextCharacterAppearance;
			this.TextStyle = __TextStyle;
			this.TextFontStyle = __TextFontStyle;
		}
	
	
	}
	
}
