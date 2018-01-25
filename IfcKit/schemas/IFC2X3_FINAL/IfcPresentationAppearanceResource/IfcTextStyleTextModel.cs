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
	[Guid("1381d678-94e6-417d-bf36-57cc610f9189")]
	public partial class IfcTextStyleTextModel :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcTextStyleSelect
	{
		[DataMember(Order=0)] 
		IfcSizeSelect _TextIndent;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcTextAlignment? _TextAlign;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcTextDecoration? _TextDecoration;
	
		[DataMember(Order=3)] 
		IfcSizeSelect _LetterSpacing;
	
		[DataMember(Order=4)] 
		IfcSizeSelect _WordSpacing;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcTextTransformation? _TextTransform;
	
		[DataMember(Order=6)] 
		IfcSizeSelect _LineHeight;
	
	
		[Description("<EPM-HTML>\r\nThe property specifies the indentation that appears before the first " +
	    "formatted line.\r\n  <blockquote> <small>NOTE&nbsp; It has been introduced for lat" +
	    "er compliance to full CSS1 support.</small></blockquote>\r\n</EPM-HTML>")]
		public IfcSizeSelect TextIndent { get { return this._TextIndent; } set { this._TextIndent = value;} }
	
		[Description("<EPM-HTML>\r\nThis property describes how text is aligned horizontally within the e" +
	    "lement. The actual justification algorithm used is dependent on the rendering al" +
	    "gorithm.\r\n</EPM-HTML>")]
		public IfcTextAlignment? TextAlign { get { return this._TextAlign; } set { this._TextAlign = value;} }
	
		[Description("<EPM-HTML>\r\nThis property describes decorations that are added to the text of an " +
	    "element.\r\n</EPM-HTML>")]
		public IfcTextDecoration? TextDecoration { get { return this._TextDecoration; } set { this._TextDecoration = value;} }
	
		[Description(@"<EPM-HTML>
	The length unit indicates an addition to the default space between characters. Values can be negative, but there may be implementation-specific limits. The user agent is free to select the exact spacing algorithm. The letter spacing may also be influenced by justification (which is a value of the 'align' property).
	  <blockquote> <small>NOTE&nbsp; The following values are allowed, <i>IfcDescriptiveMeasure</i> with value='normal', or <i>IfcLengthMeasure<i>, the length unit is globally defined at <i>IfcUnitAssignment</i>.</small></blockquote>
	</EPM-HTML>")]
		public IfcSizeSelect LetterSpacing { get { return this._LetterSpacing; } set { this._LetterSpacing = value;} }
	
		[Description(@"<EPM-HTML>
	The length unit indicates an addition to the default space between words. Values can be negative, but there may be implementation-specific limits. The user agent is free to select the exact spacing algorithm. The word spacing may also be influenced by justification (which is a value of the 'text-align' property).
	  <blockquote> <small>NOTE&nbsp; It has been introduced for later compliance to full CSS1 support.</small></blockquote>
	</EPM-HTML>")]
		public IfcSizeSelect WordSpacing { get { return this._WordSpacing; } set { this._WordSpacing = value;} }
	
		[Description(@"<EPM-HTML>
	This property describes how text characters may transform to upper case, lower case, or capitalized case, independent of the character case used in the text literal.
	  <blockquote> <small>NOTE&nbsp; It has been introduced for later compliance to full CSS1 support.</small></blockquote>
	</EPM-HTML>")]
		public IfcTextTransformation? TextTransform { get { return this._TextTransform; } set { this._TextTransform = value;} }
	
		[Description(@"<EPM-HTML>
	The property sets the distance between two adjacent lines' baselines.<br>
	When a ratio value is specified, the line height is given by the font size of the current element multiplied with the numerical value. A value of 'normal' sets the line height to a reasonable value for the element's font. It is suggested that user agents set the 'normal' value to be a ratio number in the range of 1.0 to 1.2.
	  <blockquote> <small>NOTE&nbsp; The following values are allowed:<br> <i>IfcDescriptiveMeasure</i> with value='normal', or <br>
	<i>IfcLengthMeasure<i>, with non-negative values, the length unit is globally defined at <i>IfcUnitAssignment</i>, or <br><i>IfcRatioMeasure</i>.</small></blockquote>
	</EPM-HTML>")]
		public IfcSizeSelect LineHeight { get { return this._LineHeight; } set { this._LineHeight = value;} }
	
	
	}
	
}
