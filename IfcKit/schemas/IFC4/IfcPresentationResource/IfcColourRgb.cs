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
	[Guid("4c024f51-b79f-459c-866c-4e638601af7a")]
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
	
	
		[Description("<EPM-HTML>\r\nThe intensity of the red colour component.\r\n<blockquote><small>\r\nNOTE" +
	    "&npsp; The colour component value is given within the range of 0..1, and not wit" +
	    "hin the range of 0..255 as otherwise usual.\r\n</small></blockquote>\r\n</EPM-HTML>")]
		public IfcNormalisedRatioMeasure Red { get { return this._Red; } set { this._Red = value;} }
	
		[Description("<EPM-HTML>\r\nThe intensity of the green colour component.\r\n<blockquote><small>\r\nNO" +
	    "TE&npsp; The colour component value is given within the range of 0..1, and not w" +
	    "ithin the range of 0..255 as otherwise usual.\r\n</small></blockquote>\r\n</EPM-HTML" +
	    ">")]
		public IfcNormalisedRatioMeasure Green { get { return this._Green; } set { this._Green = value;} }
	
		[Description("<EPM-HTML>\r\nThe intensity of the blue colour component.\r\n<blockquote><small>\r\nNOT" +
	    "E&npsp; The colour component value is given within the range of 0..1, and not wi" +
	    "thin the range of 0..255 as otherwise usual.\r\n</small></blockquote>\r\n</EPM-HTML>" +
	    "")]
		public IfcNormalisedRatioMeasure Blue { get { return this._Blue; } set { this._Blue = value;} }
	
	
	}
	
}
