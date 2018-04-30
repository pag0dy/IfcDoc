// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public partial class IfcBlock : IfcCsgPrimitive3D
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The size of the block along the placement X axis. It is provided by the inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[1]</em>.")]
		[Required()]
		public IfcPositiveLengthMeasure XLength { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The size of the block along the placement Y axis. It is provided by the inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[2]</em>.")]
		[Required()]
		public IfcPositiveLengthMeasure YLength { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The size of the block along the placement Z axis. It is provided by the inherited axis placement through <em>SELF\\IfcCsgPrimitive3D.Position.P[3]</em>.")]
		[Required()]
		public IfcPositiveLengthMeasure ZLength { get; set; }
	
	
		public IfcBlock(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __XLength, IfcPositiveLengthMeasure __YLength, IfcPositiveLengthMeasure __ZLength)
			: base(__Position)
		{
			this.XLength = __XLength;
			this.YLength = __YLength;
			this.ZLength = __ZLength;
		}
	
	
	}
	
}
