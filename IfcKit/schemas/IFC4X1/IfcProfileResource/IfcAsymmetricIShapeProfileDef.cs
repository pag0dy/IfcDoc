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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("a97ad274-6a1b-4db7-b4a9-46725be04471")]
	public partial class IfcAsymmetricIShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BottomFlangeWidth;
	
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
		IfcPositiveLengthMeasure _BottomFlangeThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _BottomFlangeFilletRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _TopFlangeWidth;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TopFlangeThickness;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _TopFlangeFilletRadius;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _BottomFlangeEdgeRadius;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _BottomFlangeSlope;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _TopFlangeEdgeRadius;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _TopFlangeSlope;
	
	
		public IfcAsymmetricIShapeProfileDef()
		{
		}
	
		public IfcAsymmetricIShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __BottomFlangeWidth, IfcPositiveLengthMeasure __OverallDepth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __BottomFlangeThickness, IfcNonNegativeLengthMeasure? __BottomFlangeFilletRadius, IfcPositiveLengthMeasure __TopFlangeWidth, IfcPositiveLengthMeasure? __TopFlangeThickness, IfcNonNegativeLengthMeasure? __TopFlangeFilletRadius, IfcNonNegativeLengthMeasure? __BottomFlangeEdgeRadius, IfcPlaneAngleMeasure? __BottomFlangeSlope, IfcNonNegativeLengthMeasure? __TopFlangeEdgeRadius, IfcPlaneAngleMeasure? __TopFlangeSlope)
			: base(__ProfileType, __ProfileName, __Position)
		{
			this._BottomFlangeWidth = __BottomFlangeWidth;
			this._OverallDepth = __OverallDepth;
			this._WebThickness = __WebThickness;
			this._BottomFlangeThickness = __BottomFlangeThickness;
			this._BottomFlangeFilletRadius = __BottomFlangeFilletRadius;
			this._TopFlangeWidth = __TopFlangeWidth;
			this._TopFlangeThickness = __TopFlangeThickness;
			this._TopFlangeFilletRadius = __TopFlangeFilletRadius;
			this._BottomFlangeEdgeRadius = __BottomFlangeEdgeRadius;
			this._BottomFlangeSlope = __BottomFlangeSlope;
			this._TopFlangeEdgeRadius = __TopFlangeEdgeRadius;
			this._TopFlangeSlope = __TopFlangeSlope;
		}
	
		[Description("Extent of the bottom flange, defined parallel to the x axis of the position coord" +
	    "inate system.")]
		public IfcPositiveLengthMeasure BottomFlangeWidth { get { return this._BottomFlangeWidth; } set { this._BottomFlangeWidth = value;} }
	
		[Description("Total extent of the depth, defined parallel to the y axis of the position coordin" +
	    "ate system.")]
		public IfcPositiveLengthMeasure OverallDepth { get { return this._OverallDepth; } set { this._OverallDepth = value;} }
	
		[Description("Thickness of the web of the I-shape. The web is centred on the x-axis and the y-a" +
	    "xis of the position coordinate system.")]
		public IfcPositiveLengthMeasure WebThickness { get { return this._WebThickness; } set { this._WebThickness = value;} }
	
		[Description("Flange thickness of the bottom flange.")]
		public IfcPositiveLengthMeasure BottomFlangeThickness { get { return this._BottomFlangeThickness; } set { this._BottomFlangeThickness = value;} }
	
		[Description("The fillet between the web and the bottom flange.  0 if sharp-edged, omitted if u" +
	    "nknown.")]
		public IfcNonNegativeLengthMeasure? BottomFlangeFilletRadius { get { return this._BottomFlangeFilletRadius; } set { this._BottomFlangeFilletRadius = value;} }
	
		[Description("Extent of the top flange, defined parallel to the x axis of the position coordina" +
	    "te system.")]
		public IfcPositiveLengthMeasure TopFlangeWidth { get { return this._TopFlangeWidth; } set { this._TopFlangeWidth = value;} }
	
		[Description("Flange thickness of the top flange. This attribute is formally optional for histo" +
	    "ric reasons only. Whenever the flange thickness is known, it shall be provided b" +
	    "y value.")]
		public IfcPositiveLengthMeasure? TopFlangeThickness { get { return this._TopFlangeThickness; } set { this._TopFlangeThickness = value;} }
	
		[Description("The fillet between the web and the top flange.  0 if sharp-edged, omitted if unkn" +
	    "own.")]
		public IfcNonNegativeLengthMeasure? TopFlangeFilletRadius { get { return this._TopFlangeFilletRadius; } set { this._TopFlangeFilletRadius = value;} }
	
		[Description("Radius of the upper edges of the bottom flange.  0 if sharp-edged, omitted if unk" +
	    "nown.")]
		public IfcNonNegativeLengthMeasure? BottomFlangeEdgeRadius { get { return this._BottomFlangeEdgeRadius; } set { this._BottomFlangeEdgeRadius = value;} }
	
		[Description("Slope of the upper faces of the bottom flange.  Non-zero in case of of tapered bo" +
	    "ttom flange, 0 in case of parallel bottom flange, omitted if unknown.")]
		public IfcPlaneAngleMeasure? BottomFlangeSlope { get { return this._BottomFlangeSlope; } set { this._BottomFlangeSlope = value;} }
	
		[Description("Radius of the lower edges of the top flange.  0 if sharp-edged, omitted if unknow" +
	    "n.")]
		public IfcNonNegativeLengthMeasure? TopFlangeEdgeRadius { get { return this._TopFlangeEdgeRadius; } set { this._TopFlangeEdgeRadius = value;} }
	
		[Description("Slope of the lower faces of the top flange.  Non-zero in case of of tapered top f" +
	    "lange, 0 in case of parallel top flange, omitted if unknown.")]
		public IfcPlaneAngleMeasure? TopFlangeSlope { get { return this._TopFlangeSlope; } set { this._TopFlangeSlope = value;} }
	
	
	}
	
}
