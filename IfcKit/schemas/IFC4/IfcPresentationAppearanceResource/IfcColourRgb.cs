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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

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
	
	
		[Description("<EPM-HTML>\r\nThe intensity of the red colour component.\r\n<blockquote class=\"note\">" +
	    "NOTE&nbsp; The colour component value is given within the range of 0..1, and not" +
	    " within the range of 0..255 as otherwise usual.</blockquote>\r\n</EPM-HTML>")]
		public IfcNormalisedRatioMeasure Red { get { return this._Red; } set { this._Red = value;} }
	
		[Description("<EPM-HTML>\r\nThe intensity of the green colour component.\r\n<blockquote class=\"note" +
	    "\">NOTE&nbsp; The colour component value is given within the range of 0..1, and n" +
	    "ot within the range of 0..255 as otherwise usual.</blockquote>\r\n</EPM-HTML>")]
		public IfcNormalisedRatioMeasure Green { get { return this._Green; } set { this._Green = value;} }
	
		[Description("<EPM-HTML>\r\nThe intensity of the blue colour component.\r\n<blockquote class=\"note\"" +
	    ">NOTE&nbsp; The colour component value is given within the range of 0..1, and no" +
	    "t within the range of 0..255 as otherwise usual.</blockquote>\r\n</EPM-HTML>")]
		public IfcNormalisedRatioMeasure Blue { get { return this._Blue; } set { this._Blue = value;} }
	
	
	}
	
}
