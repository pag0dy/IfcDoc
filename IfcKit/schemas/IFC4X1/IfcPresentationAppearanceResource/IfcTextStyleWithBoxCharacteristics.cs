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
	[Guid("ff2a1d63-e13c-4ed8-902b-624bdfdc3f53")]
	public partial class IfcTextStyleWithBoxCharacteristics :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcTextStyleSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _BoxHeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _BoxWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _BoxSlantAngle;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _BoxRotateAngle;
	
		[DataMember(Order=4)] 
		IfcSizeSelect _CharacterSpacing;
	
	
		[Description("It is the height scaling factor in the definition of a character glyph.")]
		public IfcPositiveLengthMeasure? BoxHeight { get { return this._BoxHeight; } set { this._BoxHeight = value;} }
	
		[Description("It is the width scaling factor in the definition of a character glyph.")]
		public IfcPositiveLengthMeasure? BoxWidth { get { return this._BoxWidth; } set { this._BoxWidth = value;} }
	
		[Description("It indicated that the box of a character glyph shall be represented as a parallel" +
	    "ogram, with the angle being between the character up line and an axis perpendicu" +
	    "lar to the character base line.")]
		public IfcPlaneAngleMeasure? BoxSlantAngle { get { return this._BoxSlantAngle; } set { this._BoxSlantAngle = value;} }
	
		[Description(@"It indicated that the box of a character glyph shall be presented at an angle to the base line of a text string within which the glyph occurs, the angle being that between the base line of the glyph and an axis perpendicular to the baseline of the text string.")]
		public IfcPlaneAngleMeasure? BoxRotateAngle { get { return this._BoxRotateAngle; } set { this._BoxRotateAngle = value;} }
	
		[Description("The distance between the character boxes of adjacent characters.")]
		public IfcSizeSelect CharacterSpacing { get { return this._CharacterSpacing; } set { this._CharacterSpacing = value;} }
	
	
	}
	
}
