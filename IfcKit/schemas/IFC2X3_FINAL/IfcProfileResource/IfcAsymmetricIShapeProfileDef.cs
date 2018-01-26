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
	[Guid("05390904-1128-43d6-81a1-6662199f18e4")]
	public partial class IfcAsymmetricIShapeProfileDef : IfcIShapeProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _TopFlangeWidth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TopFlangeThickness;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TopFlangeFilletRadius;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInY;
	
	
		public IfcAsymmetricIShapeProfileDef()
		{
		}
	
		public IfcAsymmetricIShapeProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcAxis2Placement2D __Position, IfcPositiveLengthMeasure __OverallWidth, IfcPositiveLengthMeasure __OverallDepth, IfcPositiveLengthMeasure __WebThickness, IfcPositiveLengthMeasure __FlangeThickness, IfcPositiveLengthMeasure? __FilletRadius, IfcPositiveLengthMeasure __TopFlangeWidth, IfcPositiveLengthMeasure? __TopFlangeThickness, IfcPositiveLengthMeasure? __TopFlangeFilletRadius, IfcPositiveLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileType, __ProfileName, __Position, __OverallWidth, __OverallDepth, __WebThickness, __FlangeThickness, __FilletRadius)
		{
			this._TopFlangeWidth = __TopFlangeWidth;
			this._TopFlangeThickness = __TopFlangeThickness;
			this._TopFlangeFilletRadius = __TopFlangeFilletRadius;
			this._CentreOfGravityInY = __CentreOfGravityInY;
		}
	
		[Description("Extent of the top flange, defined parallel to the x axis of the position coordina" +
	    "te system.")]
		public IfcPositiveLengthMeasure TopFlangeWidth { get { return this._TopFlangeWidth; } set { this._TopFlangeWidth = value;} }
	
		[Description("Flange thickness of the top flange of the I-shape. If given, the upper and the lo" +
	    "wer flanges can have different thicknesses. If not given, the value of the inher" +
	    "ited FlangeThickness attribute applies to both, the top and bottom flange thickn" +
	    "ess.")]
		public IfcPositiveLengthMeasure? TopFlangeThickness { get { return this._TopFlangeThickness; } set { this._TopFlangeThickness = value;} }
	
		[Description(@"The fillet between the web and the top flange of the I-shape. If given, the fillet between upper and the lower flanges and the web can be different. If not given, the value of the inherited FilletRadius attribute applies to both, the top and bottom fillet. If the inherited FilletRadius is not given either, no filler is applied.")]
		public IfcPositiveLengthMeasure? TopFlangeFilletRadius { get { return this._TopFlangeFilletRadius; } set { this._TopFlangeFilletRadius = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the y axis measured from the center of the bounding box. 
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInY</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInY { get { return this._CentreOfGravityInY; } set { this._CentreOfGravityInY = value;} }
	
	
	}
	
}
