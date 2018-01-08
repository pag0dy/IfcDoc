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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("a4f2c60a-b8a0-4f54-a66a-b99e53d00ea4")]
	public partial class IfcCShapeProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Width;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WallThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Girth;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _InternalFilletRadius;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _CentreOfGravityInX;
	
	
		[Description("Profile depth, see illustration above (= h). ")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
		[Description("Profile width, see illustration above (= b).")]
		public IfcPositiveLengthMeasure Width { get { return this._Width; } set { this._Width = value;} }
	
		[Description("Constant wall thickness of profile (= ts).")]
		public IfcPositiveLengthMeasure WallThickness { get { return this._WallThickness; } set { this._WallThickness = value;} }
	
		[Description("Lengths of girth, see illustration above (= c). ")]
		public IfcPositiveLengthMeasure Girth { get { return this._Girth; } set { this._Girth = value;} }
	
		[Description("Internal fillet radius according the above illustration (= r1). If it is not give" +
	    "n, zero is assumed. ")]
		public IfcPositiveLengthMeasure? InternalFilletRadius { get { return this._InternalFilletRadius; } set { this._InternalFilletRadius = value;} }
	
		[Description(@"<EPM-HTML> Location of centre of gravity along the x axis measured from the center of the bounding box. 
	  <blockquote> <small><color=""#ff0000"">
	IFC2x Edition 2 Addendum 2 CHANGE The attribute <i>CentreOfGravityInX</i> has been made optional. Upward compatibility for file based exchange is guaranteed.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcPositiveLengthMeasure? CentreOfGravityInX { get { return this._CentreOfGravityInX; } set { this._CentreOfGravityInX = value;} }
	
	
	}
	
}
