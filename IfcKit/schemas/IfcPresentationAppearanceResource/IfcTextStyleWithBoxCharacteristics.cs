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
	public partial class IfcTextStyleWithBoxCharacteristics :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcTextStyleSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("It is the height scaling factor in the definition of a character glyph.")]
		public IfcPositiveLengthMeasure? BoxHeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("It is the width scaling factor in the definition of a character glyph.")]
		public IfcPositiveLengthMeasure? BoxWidth { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("It indicated that the box of a character glyph shall be represented as a parallelogram, with the angle being between the character up line and an axis perpendicular to the character base line.")]
		public IfcPlaneAngleMeasure? BoxSlantAngle { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("It indicated that the box of a character glyph shall be presented at an angle to the base line of a text string within which the glyph occurs, the angle being that between the base line of the glyph and an axis perpendicular to the baseline of the text string.")]
		public IfcPlaneAngleMeasure? BoxRotateAngle { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The distance between the character boxes of adjacent characters.")]
		public IfcSizeSelect CharacterSpacing { get; set; }
	
	
		public IfcTextStyleWithBoxCharacteristics(IfcPositiveLengthMeasure? __BoxHeight, IfcPositiveLengthMeasure? __BoxWidth, IfcPlaneAngleMeasure? __BoxSlantAngle, IfcPlaneAngleMeasure? __BoxRotateAngle, IfcSizeSelect __CharacterSpacing)
		{
			this.BoxHeight = __BoxHeight;
			this.BoxWidth = __BoxWidth;
			this.BoxSlantAngle = __BoxSlantAngle;
			this.BoxRotateAngle = __BoxRotateAngle;
			this.CharacterSpacing = __CharacterSpacing;
		}
	
	
	}
	
}
