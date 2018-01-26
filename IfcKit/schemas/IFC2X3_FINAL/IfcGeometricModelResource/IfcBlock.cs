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
	[Guid("be97cd87-4373-4f2d-ae45-79636757b234")]
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
	
	
		public IfcBlock()
		{
		}
	
		public IfcBlock(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __XLength, IfcPositiveLengthMeasure __YLength, IfcPositiveLengthMeasure __ZLength)
			: base(__Position)
		{
			this._XLength = __XLength;
			this._YLength = __YLength;
			this._ZLength = __ZLength;
		}
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement X axis. It is provided by t" +
	    "he inherited axis placement through <i>SELF\\IfcCsgPrimitive3D.Position.P[1]</i>." +
	    "\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure XLength { get { return this._XLength; } set { this._XLength = value;} }
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement Y axis. It is provided by t" +
	    "he inherited axis placement through <i>SELF\\IfcCsgPrimitive3D.Position.P[2]</i>." +
	    "\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure YLength { get { return this._YLength; } set { this._YLength = value;} }
	
		[Description("<EPM-HTML>\r\nThe size of the block along the placement Z axis. It is provided by t" +
	    "he inherited axis placement through <i>SELF\\IfcCsgPrimitive3D.Position.P[3]</i>." +
	    "\r\n</EPM-HTML>")]
		public IfcPositiveLengthMeasure ZLength { get { return this._ZLength; } set { this._ZLength = value;} }
	
	
	}
	
}
