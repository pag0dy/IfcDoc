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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("78f8dd59-9152-46ea-a81c-33962e1055c3")]
	public partial class IfcIShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _OverallWidth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _OverallDepth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WebThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _FlangeThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FilletRadius;
	
	
		public IfcIShapeProfileDef()
		{
		}
	
		public IfcIShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallWidth, IfcPositiveLengthMeasure __OverallDepth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcPositiveLengthMeasure? __FilletRadius)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this._OverallWidth = __OverallWidth;
			this._OverallDepth = __OverallDepth;
			this._WebThickness = __WebThickness;
			this._FlangeThickness = __FlangeThickness;
			this._FilletRadius = __FilletRadius;
		}
	
		[Description("Total extent of the width, defined parallel to the x axis of the position coordin" +
	    "ate system.")]
		public IfcPositiveLengthMeasure OverallWidth { get { return this._OverallWidth; } set { this._OverallWidth = value;} }
	
		[Description("Total extent of the depth, defined parallel to the y axis of the position coordin" +
	    "ate system.")]
		public IfcPositiveLengthMeasure OverallDepth { get { return this._OverallDepth; } set { this._OverallDepth = value;} }
	
		[Description("Thickness of the web of the I-shape. The web is centred on the x-axis and the y-a" +
	    "xis of the position coordinate system.")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Flange thickness of the I-shape. Both, the upper and the lower flanges have the s" +
	    "ame thickness and they are centred on the y-axis of the position coordinate syst" +
	    "em.")]
		public IfcPositiveLengthMeasure FlangeThickness { get { return this._FlangeThickness; } set { this._FlangeThickness = value;} }
	
		[Description("The fillet between the web and the flange, if not given, zero is assumed.")]
		public IfcPositiveLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
	
	}
	
}
