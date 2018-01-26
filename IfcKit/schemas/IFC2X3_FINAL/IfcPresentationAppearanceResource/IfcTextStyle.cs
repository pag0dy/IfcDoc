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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("5d06ae78-92d1-4cb2-8e64-2698b85168cf")]
	public partial class IfcTextStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		IfcCharacterStyleSelect _TextCharacterAppearance;
	
		[DataMember(Order=1)] 
		IfcTextStyleSelect _TextStyle;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcTextFontSelect _TextFontStyle;
	
	
		public IfcTextStyle()
		{
		}
	
		public IfcTextStyle(IfcLabel? __Name, IfcCharacterStyleSelect __TextCharacterAppearance, IfcTextStyleSelect __TextStyle, IfcTextFontSelect __TextFontStyle)
			: base(__Name)
		{
			this._TextCharacterAppearance = __TextCharacterAppearance;
			this._TextStyle = __TextStyle;
			this._TextFontStyle = __TextFontStyle;
		}
	
		[Description("<EPM-HTML>\r\nA character style to be used for presented text.\r\n</EPM-HTML>")]
		public IfcCharacterStyleSelect TextCharacterAppearance { get { return this._TextCharacterAppearance; } set { this._TextCharacterAppearance = value;} }
	
		[Description(@"<EPM-HTML>
	The style applied to the text block for its visual appearance.</br>
	It defines the text block characteristics, either for vector based or monospace text fonts (see select item <i>IfcTextStyleWithBoxCharacteristics</i>), or for true type text fonts (see select item <i>IfcTextStyleTextModel</i>.
	  <blockquote><small><font color=""#0000ff"">
	IFC2x Edition 3 CHANGE&nbsp; The <i>attribute <i>TextBlockStyle</i> has been changed from SET[1:?] to a non-aggregated optional, it has been renamed from TextStyles.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcTextStyleSelect TextStyle { get { return this._TextStyle; } set { this._TextStyle = value;} }
	
		[Description(@"<EPM-HTML>
	The style applied to the text font for its visual appearance.</br>
	It defines the font family, font style, weight and size.
	  <blockquote><small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>TextFontStyle</i> is a new attribute attached to <i>IfcTextStyle</i>.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcTextFontSelect TextFontStyle { get { return this._TextFontStyle; } set { this._TextFontStyle = value;} }
	
	
	}
	
}
