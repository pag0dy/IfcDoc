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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("388e833a-1b3c-4462-8e69-376d83bdcbb7")]
	public partial class IfcColourRgb : IfcColourSpecification,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcColourOrFactor
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcNormalisedRatioMeasure _Red;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcNormalisedRatioMeasure _Green;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcNormalisedRatioMeasure _Blue;
	
	
		public IfcColourRgb()
		{
		}
	
		public IfcColourRgb(IfcLabel? __Name, IfcNormalisedRatioMeasure __Red, IfcNormalisedRatioMeasure __Green, IfcNormalisedRatioMeasure __Blue)
			: base(__Name)
		{
			this._Red = __Red;
			this._Green = __Green;
			this._Blue = __Blue;
		}
	
		[Description("The intensity of the red colour component.\r\n<blockquote class=\"note\">NOTE&nbsp; T" +
	    "he colour component value is given within the range of 0..1, and not within the " +
	    "range of 0..255 as otherwise usual.</blockquote>")]
		public IfcNormalisedRatioMeasure Red { get { return this._Red; } set { this._Red = value;} }
	
		[Description("The intensity of the green colour component.\r\n<blockquote class=\"note\">NOTE&nbsp;" +
	    " The colour component value is given within the range of 0..1, and not within th" +
	    "e range of 0..255 as otherwise usual.</blockquote>")]
		public IfcNormalisedRatioMeasure Green { get { return this._Green; } set { this._Green = value;} }
	
		[Description("The intensity of the blue colour component.\r\n<blockquote class=\"note\">NOTE&nbsp; " +
	    "The colour component value is given within the range of 0..1, and not within the" +
	    " range of 0..255 as otherwise usual.</blockquote>")]
		public IfcNormalisedRatioMeasure Blue { get { return this._Blue; } set { this._Blue = value;} }
	
	
	}
	
}
