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
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	public partial class IfcTextStyleFontModel : IfcPreDefinedTextFont
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The value is a prioritized list of font family names and/or generic family names. The first list entry has the highest priority, if this font fails, the next list item shall be used. The last list item should (if possible) be a generic family.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute changed to being mandatory.  </blockquote>")]
		[Required()]
		[MinLength(1)]
		public IList<IfcTextFontName> FontFamily { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The font style property selects between normal (sometimes referred to as \"roman\" or \"upright\"), italic and oblique faces within a font family.<br>")]
		public IfcFontStyle? FontStyle { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The font variant property selects between normal and small-caps.    <blockquote class=\"note\">NOTE&nbsp; It has been introduced for later compliance to full CSS1 support.</blockquote>")]
		public IfcFontVariant? FontVariant { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The font weight property selects the weight of the font.    <blockquote class=\"note\">NOTE&nbsp; Values other then 'normal' and 'bold' have been introduced for later compliance to full CSS1 support.</blockquote>")]
		public IfcFontWeight? FontWeight { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The font size provides the size or height of the text font.    <blockquote class=\"note\">NOTE&nbsp; The following values are allowed, <<em>IfcLengthMeasure<em>, with positive values, the length unit is globally defined at <em>IfcUnitAssignment</em>.</blockquote>")]
		[Required()]
		public IfcSizeSelect FontSize { get; set; }
	
	
		public IfcTextStyleFontModel(IfcLabel __Name, IfcTextFontName[] __FontFamily, IfcFontStyle? __FontStyle, IfcFontVariant? __FontVariant, IfcFontWeight? __FontWeight, IfcSizeSelect __FontSize)
			: base(__Name)
		{
			this.FontFamily = new List<IfcTextFontName>(__FontFamily);
			this.FontStyle = __FontStyle;
			this.FontVariant = __FontVariant;
			this.FontWeight = __FontWeight;
			this.FontSize = __FontSize;
		}
	
	
	}
	
}
