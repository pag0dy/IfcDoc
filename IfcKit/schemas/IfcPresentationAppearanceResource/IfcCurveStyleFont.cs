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
	public partial class IfcCurveStyleFont : IfcPresentationItem,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcCurveStyleFontSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name that may be assigned with the curve font.")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A list of curve font pattern entities, that contains the simple patterns used for drawing curves. The patterns are applied in the order they occur in the list.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcCurveStyleFontPattern> PatternList { get; protected set; }
	
	
		public IfcCurveStyleFont(IfcLabel? __Name, IfcCurveStyleFontPattern[] __PatternList)
		{
			this.Name = __Name;
			this.PatternList = new List<IfcCurveStyleFontPattern>(__PatternList);
		}
	
	
	}
	
}
