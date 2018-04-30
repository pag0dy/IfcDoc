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
	public partial class IfcColourRgbList : IfcPresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("List of colours defined by the red, green, blue components. All values are provided as a ratio of 0.0 &le; <i>value</i> &le; 1.0. When using 8bit for each colour channel, a value of 0.0 equals 0, a value of 1.0 equals 255, and values between are interpolated.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcNormalisedRatioMeasure> ColourList { get; protected set; }
	
	
		public IfcColourRgbList(IfcNormalisedRatioMeasure[] __ColourList)
		{
			this.ColourList = new List<IfcNormalisedRatioMeasure>(__ColourList);
		}
	
	
	}
	
}
