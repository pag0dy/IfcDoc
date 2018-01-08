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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcPresentationResource
{
	[Guid("5c827c55-6f86-4658-bb60-77fbec59f843")]
	public partial class IfcTextStyleFontModel : IfcPreDefinedTextFont
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IList<IfcTextFontName> _FontFamily = new List<IfcTextFontName>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcFontStyle? _FontStyle;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcFontVariant? _FontVariant;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcFontWeight? _FontWeight;
	
		[DataMember(Order=4)] 
		[Required()]
		IfcSizeSelect _FontSize;
	
	
		[Description(@"<EPM-HTML>
	The value is a prioritized list of font family names and/or generic family names. The first list entry has the highest priority, if this font fails, the next list item shall be used. The last list item should (if possible) be a generic family.<br>
	</EPM-HTML>")]
		public IList<IfcTextFontName> FontFamily { get { return this._FontFamily; } }
	
		[Description("<EPM-HTML>\r\nThe font style property selects between normal (sometimes referred to" +
	    " as \"roman\" or \"upright\"), italic and oblique faces within a font family.<br>\r\n<" +
	    "/EPM-HTML>")]
		public IfcFontStyle? FontStyle { get { return this._FontStyle; } set { this._FontStyle = value;} }
	
		[Description("<EPM-HTML>\r\nThe font variant property selects between normal and small-caps.\r\n  <" +
	    "blockquote> <small>NOTE&nbsp; It has been introduced for later compliance to ful" +
	    "l CSS1 support.</small></blockquote>\r\n</EPM-HTML>")]
		public IfcFontVariant? FontVariant { get { return this._FontVariant; } set { this._FontVariant = value;} }
	
		[Description("<EPM-HTML>\r\nThe font weight property selects the weight of the font.\r\n  <blockquo" +
	    "te> <small>NOTE&nbsp; Values other then \'normal\' and \'bold\' have been introduced" +
	    " for later compliance to full CSS1 support.</small></blockquote>\r\n</EPM-HTML>")]
		public IfcFontWeight? FontWeight { get { return this._FontWeight; } set { this._FontWeight = value;} }
	
		[Description(@"<EPM-HTML>
	The font size provides the size or height of the text font.
	  <blockquote> <small>NOTE&nbsp; The following values are allowed, <<i>IfcLengthMeasure<i>, with positive values, the length unit is globally defined at <i>IfcUnitAssignment</i>.</small></blockquote>
	</EPM-HTML>")]
		public IfcSizeSelect FontSize { get { return this._FontSize; } set { this._FontSize = value;} }
	
	
	}
	
}
