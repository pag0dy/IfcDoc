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
	public partial class IfcFillAreaStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order = 0)] 
		[Description("The set of fill area styles to use in presenting visible curve segments, annotation fill areas or surfaces.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcFillStyleSelect> FillStyles { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Indication whether the length measures provided for the presentation style are model based, or draughting based.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.  </blockquote>")]
		public IfcBoolean? ModelorDraughting { get; set; }
	
	
		public IfcFillAreaStyle(IfcLabel? __Name, IfcFillStyleSelect[] __FillStyles, IfcBoolean? __ModelorDraughting)
			: base(__Name)
		{
			this.FillStyles = new HashSet<IfcFillStyleSelect>(__FillStyles);
			this.ModelorDraughting = __ModelorDraughting;
		}
	
	
	}
	
}
