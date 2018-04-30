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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcPresentationResource
{
	public partial class IfcTextStyleFontModel : IfcPreDefinedTextFont
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The value is a prioritized list of font family names and/or generic family names. The first list entry has the highest priority, if this font fails, the next list item shall be used. The last list item should (if possible) be a generic family.<br>  </EPM-HTML>")]
		[MinLength(1)]
		public IList<IfcTextFontName> FontFamily { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The font style property selects between normal (sometimes referred to as \"roman\" or \"upright\"), italic and oblique faces within a font family.<br>  </EPM-HTML>")]
		public IfcFontStyle? FontStyle { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The font variant property selects between normal and small-caps.    <blockquote> <small>NOTE&nbsp; It has been introduced for later compliance to full CSS1 support.</small></blockquote>  </EPM-HTML>")]
		public IfcFontVariant? FontVariant { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The font weight property selects the weight of the font.    <blockquote> <small>NOTE&nbsp; Values other then 'normal' and 'bold' have been introduced for later compliance to full CSS1 support.</small></blockquote>  </EPM-HTML>")]
		public IfcFontWeight? FontWeight { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("<EPM-HTML>  The font size provides the size or height of the text font.    <blockquote> <small>NOTE&nbsp; The following values are allowed, <<i>IfcLengthMeasure<i>, with positive values, the length unit is globally defined at <i>IfcUnitAssignment</i>.</small></blockquote>  </EPM-HTML>")]
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
