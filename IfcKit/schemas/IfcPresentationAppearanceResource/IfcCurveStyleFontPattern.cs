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
	public partial class IfcCurveStyleFontPattern
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>  The length of the visible segment in the pattern definition.  <blockquote><small>    NOTE&nbsp; For a visible segment representing a point, the value 0. should be assigned.<br>  <font color=\"#FF0000\">    IFC2x Edition 3 CHANGE&nbsp; The datatype has been changed to IfcLengthMeasure with upward compatibility for file-based exchange.  </font></small></blockquote>  </EPM-HTML>")]
		[Required()]
		public IfcLengthMeasure VisibleSegmentLength { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The length of the invisible segment in the pattern definition.")]
		[Required()]
		public IfcPositiveLengthMeasure InvisibleSegmentLength { get; set; }
	
	
		public IfcCurveStyleFontPattern(IfcLengthMeasure __VisibleSegmentLength, IfcPositiveLengthMeasure __InvisibleSegmentLength)
		{
			this.VisibleSegmentLength = __VisibleSegmentLength;
			this.InvisibleSegmentLength = __InvisibleSegmentLength;
		}
	
	
	}
	
}
