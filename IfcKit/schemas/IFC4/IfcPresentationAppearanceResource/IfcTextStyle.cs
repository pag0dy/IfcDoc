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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("a79b1274-8b81-4827-baa7-03f278dc7a39")]
	public partial class IfcTextStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcTextStyleForDefinedFont")]
		IfcTextStyleForDefinedFont _TextCharacterAppearance;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcTextStyleTextModel")]
		IfcTextStyleTextModel _TextStyle;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcTextFontSelect _TextFontStyle;
	
		[DataMember(Order=3)] 
		Boolean? _ModelOrDraughting;
	
	
		[Description("<EPM-HTML>\r\nA character style to be used for presented text.\r\n<blockquote class=\"" +
	    "change-ifc2x4\">IFC4 CHANGE&nbsp; Superfluous select type IfcCharacterStyleSelect" +
	    " has been removed.\r\n</blockquote>\r\n</EPM-HTML>")]
		public IfcTextStyleForDefinedFont TextCharacterAppearance { get { return this._TextCharacterAppearance; } set { this._TextCharacterAppearance = value;} }
	
		[Description(@"<EPM-HTML>
	The style applied to the text block for its visual appearance.
	<blockquote class=""change-ifc2x3"">IFC2x3 CHANGE&nbsp; The attribute <em>TextBlockStyle</em> has been changed from SET[1:?] to a non-aggregated optional and renamed into <em>TextStyles</em>.</blockquote>
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The IfcTextStyleWithBoxCharacteristics and the now superfluous select type IfcTextStyleSelect have been removed.
	</blockquote>
	</EPM-HTML>")]
		public IfcTextStyleTextModel TextStyle { get { return this._TextStyle; } set { this._TextStyle = value;} }
	
		[Description(@"<EPM-HTML>
	The style applied to the text font for its visual appearance. It defines the font family, font style, weight and size.
	  <blockquote class=""change-ifc2x2"">IFC2x2 Add2 CHANGE The attribute <em>TextFontStyle</em> is a new attribute attached to <em>IfcTextStyle</em>.
	  </blockquote>
	</EPM-HTML>")]
		public IfcTextFontSelect TextFontStyle { get { return this._TextFontStyle; } set { this._TextFontStyle = value;} }
	
		[Description("<EPM-HTML>\r\nIndication whether the length measures provided for the presentation " +
	    "style are model based, or draughting based.\r\n<blockquote class=\"change-ifc2x4\">I" +
	    "FC4 CHANGE&nbsp; New attribute.\r\n</blockquote>\r\n</EPM-HTML>")]
		public Boolean? ModelOrDraughting { get { return this._ModelOrDraughting; } set { this._ModelOrDraughting = value;} }
	
	
	}
	
}
