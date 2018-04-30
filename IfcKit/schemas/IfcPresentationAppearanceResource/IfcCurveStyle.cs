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
	public partial class IfcCurveStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order = 0)] 
		[Description("A curve style font which is used to present a curve. It can either be a predefined curve font, or an explicitly defined curve font. Both may be scaled. If not given, then the curve font should be taken from the layer assignment with style, if that is not given either, then the default curve font applies.")]
		public IfcCurveFontOrScaledCurveFontSelect CurveFont { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A positive length measure in units of the presentation area for the width of a presented curve. If not given, then the style should be taken from the layer assignment with style, if that is not given either, then the default style applies.")]
		public IfcSizeSelect CurveWidth { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The colour of the visible part of the curve. If not given, then the colour should be taken from the layer assignment with style, if that is not given either, then the default colour applies.")]
		public IfcColour CurveColour { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Indication whether the length measures provided for the presentation style are model based, or draughting based.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.  </blockquote>")]
		public IfcBoolean? ModelOrDraughting { get; set; }
	
	
		public IfcCurveStyle(IfcLabel? __Name, IfcCurveFontOrScaledCurveFontSelect __CurveFont, IfcSizeSelect __CurveWidth, IfcColour __CurveColour, IfcBoolean? __ModelOrDraughting)
			: base(__Name)
		{
			this.CurveFont = __CurveFont;
			this.CurveWidth = __CurveWidth;
			this.CurveColour = __CurveColour;
			this.ModelOrDraughting = __ModelOrDraughting;
		}
	
	
	}
	
}
