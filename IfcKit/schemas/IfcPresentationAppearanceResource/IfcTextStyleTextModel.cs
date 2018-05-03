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

using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextStyleTextModel : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("The property specifies the indentation that appears before the first formatted line.    <blockquote class=\"note\">NOTE&nbsp; It has been introduced for later compliance to full CSS support.</blockquote>")]
		public IfcSizeSelect TextIndent { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("This property describes how text is aligned horizontally within the element. The actual justification algorithm used is dependent on the rendering algorithm.")]
		public IfcTextAlignment? TextAlign { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("This property describes decorations that are added to the text of an element.")]
		public IfcTextDecoration? TextDecoration { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The length unit indicates an addition to the default space between characters. Values can be negative, but there may be implementation-specific limits. The importing application is free to select the exact spacing algorithm. The letter spacing may also be influenced by justification (which is a value of the <em>TextAlign</em> attribute).  <blockquote class=\"note\">NOTE&nbsp; The following values are allowed, <em>IfcDescriptiveMeasure</em> with value='normal', <em>IfcRatioMeasure</em>, or <em>IfcLengthMeasure</em>, where the length unit is globally defined at <em>IfcUnitAssignment</em>.</blockquote>")]
		public IfcSizeSelect LetterSpacing { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The length unit indicates an addition to the default space between words. Values can be negative, but there may be implementation-specific limits. The importing application is free to select the exact spacing algorithm. The word spacing may also be influenced by justification (which is a value of the 'text-align' property).    <blockquote class=\"note\">NOTE&nbsp; It has been introduced for later compliance to full CSS support.</blockquote>")]
		public IfcSizeSelect WordSpacing { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("This property describes how text characters may transform to upper case, lower case, or capitalized case, independent of the character case used in the text literal.    <blockquote class=\"note\">NOTE&nbsp; It has been introduced for later compliance to full CSS support.</blockquote>")]
		public IfcTextTransformation? TextTransform { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("The property sets the distance between two adjacent lines' baselines.<br>  When a ratio value is specified, the line height is given by the font size of the current element multiplied with the numerical value. A value of 'normal' sets the line height to a reasonable value for the element's font. It is suggested that importing applications set the 'normal' value to be a ratio number in the range of 1.0 to 1.2.    <blockquote class=\"note\">NOTE&nbsp; The following values are allowed: <em>IfcDescriptiveMeasure</em> with value='normal', or   <em>IfcLengthMeasure<em>, with non-negative values, the length unit is globally defined at <em>IfcUnitAssignment</em>, or <em>IfcRatioMeasure</em>.</blockquote>")]
		public IfcSizeSelect LineHeight { get; set; }
	
	
		public IfcTextStyleTextModel(IfcSizeSelect __TextIndent, IfcTextAlignment? __TextAlign, IfcTextDecoration? __TextDecoration, IfcSizeSelect __LetterSpacing, IfcSizeSelect __WordSpacing, IfcTextTransformation? __TextTransform, IfcSizeSelect __LineHeight)
		{
			this.TextIndent = __TextIndent;
			this.TextAlign = __TextAlign;
			this.TextDecoration = __TextDecoration;
			this.LetterSpacing = __LetterSpacing;
			this.WordSpacing = __WordSpacing;
			this.TextTransform = __TextTransform;
			this.LineHeight = __LineHeight;
		}
	
	
	}
	
}
