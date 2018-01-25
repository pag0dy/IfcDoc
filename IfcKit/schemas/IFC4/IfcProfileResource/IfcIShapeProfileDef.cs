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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("254749ac-db77-4f69-a8a0-b4cc5d5e66fa")]
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
		IfcNonNegativeLengthMeasure? _FilletRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _FlangeEdgeRadius;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _FlangeSlope;
	
	
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
	
		[Description("The fillet between the web and the flange.  0 if sharp-edged, omitted if unknown." +
	    "")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Radius of the lower edges of the top flange and the upper edges of the bottom fla" +
	    "nge.  0 if sharp-edged, omitted if unknown.")]
		public IfcNonNegativeLengthMeasure? FlangeEdgeRadius { get { return this._FlangeEdgeRadius; } set { this._FlangeEdgeRadius = value;} }
	
		[Description("Slope of the lower faces of the top flange and of the upper faces of the bottom f" +
	    "lange.  Non-zero in case of tapered flanges, 0 in case of parallel flanges, omit" +
	    "ted if unknown.")]
		public IfcPlaneAngleMeasure? FlangeSlope { get { return this._FlangeSlope; } set { this._FlangeSlope = value;} }
	
	
	}
	
}
