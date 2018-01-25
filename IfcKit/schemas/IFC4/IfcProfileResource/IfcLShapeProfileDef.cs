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
	[Guid("ac8317b8-fdef-4d3d-afd6-b168298be8c3")]
	public partial class IfcLShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Width;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Thickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _FilletRadius;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _EdgeRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPlaneAngleMeasure? _LegSlope;
	
	
		[Description("Leg length, see illustration above (= h). Same as the overall depth.")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Leg length, see illustration above (= b). Same as the overall width. This attribu" +
	    "te is formally optional for historic reasons only. Whenever the width is known, " +
	    "it shall be provided by value.")]
		public IfcPositiveLengthMeasure? Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("Constant wall thickness of profile, see illustration above (= ts).")]
		public IfcPositiveLengthMeasure Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
		[Description("Fillet radius according the above illustration (= r1).")]
		public IfcNonNegativeLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
		[Description("Edge radius according the above illustration (= r2).")]
		public IfcNonNegativeLengthMeasure? EdgeRadius { get { return this._EdgeRadius; } set { this._EdgeRadius = value;} }
	
		[Description("Slope of the inner face of each leg of the profile.")]
		public IfcPlaneAngleMeasure? LegSlope { get { return this._LegSlope; } set { this._LegSlope = value;} }
	
	
	}
	
}
