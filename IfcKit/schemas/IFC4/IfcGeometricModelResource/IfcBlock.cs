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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("e5472b11-5ad6-482e-a790-fd5b136c2bf4")]
	public partial class IfcBlock : IfcCsgPrimitive3D
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
		IfcPositiveLengthMeasure _ZLength;
	
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement X axis. It is provided by t" +
	    "he inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[1]</em" +
	    ">.\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure XLength { get { return this._XLength; } set { this._XLength = value;} }
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement Y axis. It is provided by t" +
	    "he inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[2]</em" +
	    ">.\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure YLength { get { return this._YLength; } set { this._YLength = value;} }
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement Z axis. It is provided by t" +
	    "he inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[3]</em" +
	    ">.\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure ZLength { get { return this._ZLength; } set { this._ZLength = value;} }
	
	
	}
	
}
