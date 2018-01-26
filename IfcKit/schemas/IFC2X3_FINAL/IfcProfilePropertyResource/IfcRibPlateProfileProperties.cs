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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	[Guid("1ea1a4ea-b939-45c5-bf5b-50b59b82f634")]
	public partial class IfcRibPlateProfileProperties : IfcProfileProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Thickness;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _RibHeight;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _RibWidth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _RibSpacing;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcRibPlateDirectionEnum _Direction;
	
	
		public IfcRibPlateProfileProperties()
		{
		}
	
		public IfcRibPlateProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcPositiveLengthMeasure? __Thickness, IfcPositiveLengthMeasure? __RibHeight, IfcPositiveLengthMeasure? __RibWidth, IfcPositiveLengthMeasure? __RibSpacing, IfcRibPlateDirectionEnum __Direction)
			: base(__ProfileName, __ProfileDefinition)
		{
			this._Thickness = __Thickness;
			this._RibHeight = __RibHeight;
			this._RibWidth = __RibWidth;
			this._RibSpacing = __RibSpacing;
			this._Direction = __Direction;
		}
	
		[Description("Defines the thickness of the structural face member.")]
		public IfcPositiveLengthMeasure? Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
		[Description("Height of the ribs. ")]
		public IfcPositiveLengthMeasure? RibHeight { get { return this._RibHeight; } set { this._RibHeight = value;} }
	
		[Description("Width of the ribs. ")]
		public IfcPositiveLengthMeasure? RibWidth { get { return this._RibWidth; } set { this._RibWidth = value;} }
	
		[Description("Spacing between the axes of the ribs.")]
		public IfcPositiveLengthMeasure? RibSpacing { get { return this._RibSpacing; } set { this._RibSpacing = value;} }
	
		[Description("Defines the direction of profile definition as described on figure above.")]
		public IfcRibPlateDirectionEnum Direction { get { return this._Direction; } set { this._Direction = value;} }
	
	
	}
	
}
