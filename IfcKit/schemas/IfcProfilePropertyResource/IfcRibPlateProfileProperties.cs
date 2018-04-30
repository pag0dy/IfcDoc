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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	public partial class IfcRibPlateProfileProperties : IfcProfileProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the thickness of the structural face member.")]
		public IfcPositiveLengthMeasure? Thickness { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Height of the ribs. ")]
		public IfcPositiveLengthMeasure? RibHeight { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Width of the ribs. ")]
		public IfcPositiveLengthMeasure? RibWidth { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Spacing between the axes of the ribs.")]
		public IfcPositiveLengthMeasure? RibSpacing { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Defines the direction of profile definition as described on figure above.")]
		[Required()]
		public IfcRibPlateDirectionEnum Direction { get; set; }
	
	
		public IfcRibPlateProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcPositiveLengthMeasure? __Thickness, IfcPositiveLengthMeasure? __RibHeight, IfcPositiveLengthMeasure? __RibWidth, IfcPositiveLengthMeasure? __RibSpacing, IfcRibPlateDirectionEnum __Direction)
			: base(__ProfileName, __ProfileDefinition)
		{
			this.Thickness = __Thickness;
			this.RibHeight = __RibHeight;
			this.RibWidth = __RibWidth;
			this.RibSpacing = __RibSpacing;
			this.Direction = __Direction;
		}
	
	
	}
	
}
