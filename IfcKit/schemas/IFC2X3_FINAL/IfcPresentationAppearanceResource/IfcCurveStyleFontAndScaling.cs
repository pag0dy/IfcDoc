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
	[Guid("fc306c92-12c0-4a42-a907-fc0094e3a14f")]
	public partial class IfcCurveStyleFontAndScaling :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcCurveFontOrScaledCurveFontSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcCurveStyleFontSelect _CurveFont;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveRatioMeasure _CurveFontScaling;
	
	
		[Description("Name that may be assigned with the scaling of a curve font.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("The curve font to be scaled.")]
		public IfcCurveStyleFontSelect CurveFont { get { return this._CurveFont; } set { this._CurveFont = value;} }
	
		[Description("The scale factor.")]
		public IfcPositiveRatioMeasure CurveFontScaling { get { return this._CurveFontScaling; } set { this._CurveFontScaling = value;} }
	
	
	}
	
}
