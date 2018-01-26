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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("1ad16494-b844-40aa-bd8c-42b28ea6cf30")]
	public partial class IfcRectangularPyramid : IfcCsgPrimitive3D
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _XLength;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _YLength;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Height;
	
	
		public IfcRectangularPyramid()
		{
		}
	
		public IfcRectangularPyramid(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __XLength, IfcPositiveLengthMeasure __YLength, IfcPositiveLengthMeasure __Height)
			: base(__Position)
		{
			this._XLength = __XLength;
			this._YLength = __YLength;
			this._Height = __Height;
		}
	
		[Description("The length of the base measured along the placement X axis. It is provided by the" +
	    " inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[1]</em>." +
	    "")]
		public IfcPositiveLengthMeasure XLength { get { return this._XLength; } set { this._XLength = value;} }
	
		[Description("The length of the base measured along the placement Y axis. It is provided by the" +
	    " inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[2]</em>." +
	    "")]
		public IfcPositiveLengthMeasure YLength { get { return this._YLength; } set { this._YLength = value;} }
	
		[Description("The height of the apex above the plane of the base, measured in the direction of " +
	    "the placement Z axis, the <em>SELF\\IfcCsgPrimitive3D.Position.P[2]</em>.")]
		public IfcPositiveLengthMeasure Height { get { return this._Height; } set { this._Height = value;} }
	
	
	}
	
}
