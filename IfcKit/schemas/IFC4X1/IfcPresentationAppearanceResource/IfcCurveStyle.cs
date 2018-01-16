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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("49a36789-cab6-4f39-a3b3-5c02c31a8513")]
	public partial class IfcCurveStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		IfcCurveFontOrScaledCurveFontSelect _CurveFont;
	
		[DataMember(Order=1)] 
		IfcSizeSelect _CurveWidth;
	
		[DataMember(Order=2)] 
		IfcColour _CurveColour;
	
	
		[Description(@"A curve style font which is used to present a curve. It can either be a predefined curve font, or an explicitly defined curve font. Both may be scaled. If not given, then the curve font should be taken from the layer assignment with style, if that is not given either, then the default curve font applies.")]
		public IfcCurveFontOrScaledCurveFontSelect CurveFont { get { return this._CurveFont; } set { this._CurveFont = value;} }
	
		[Description("A positive length measure in units of the presentation area for the width of a pr" +
	    "esented curve. If not given, then the style should be taken from the layer assig" +
	    "nment with style, if that is not given either, then the default style applies.")]
		public IfcSizeSelect CurveWidth { get { return this._CurveWidth; } set { this._CurveWidth = value;} }
	
		[Description("The colour of the visible part of the curve. If not given, then the colour should" +
	    " be taken from the layer assignment with style, if that is not given either, the" +
	    "n the default colour applies.")]
		public IfcColour CurveColour { get { return this._CurveColour; } set { this._CurveColour = value;} }
	
	
	}
	
}
