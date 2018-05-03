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
	public partial class IfcBoundingBox : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Location of the bottom left corner (having the minimum values).")]
		[Required()]
		public IfcCartesianPoint Corner { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Length attribute (measured along the edge parallel to the X Axis)")]
		[Required()]
		public IfcPositiveLengthMeasure XDim { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Width attribute (measured along the edge parallel to the Y Axis)")]
		[Required()]
		public IfcPositiveLengthMeasure YDim { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Height attribute (measured along the edge parallel to the Z Axis).")]
		[Required()]
		public IfcPositiveLengthMeasure ZDim { get; set; }
	
	
		public IfcBoundingBox(IfcCartesianPoint __Corner, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __ZDim)
		{
			this.Corner = __Corner;
			this.XDim = __XDim;
			this.YDim = __YDim;
			this.ZDim = __ZDim;
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
