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
	[Guid("b0708265-0f85-4d96-a7f6-caf74b3bb754")]
	public partial class IfcBoundingBox : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCartesianPoint _Corner;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _XDim;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _YDim;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _ZDim;
	
	
		public IfcBoundingBox()
		{
		}
	
		public IfcBoundingBox(IfcCartesianPoint __Corner, IfcPositiveLengthMeasure __XDim, IfcPositiveLengthMeasure __YDim, IfcPositiveLengthMeasure __ZDim)
		{
			this._Corner = __Corner;
			this._XDim = __XDim;
			this._YDim = __YDim;
			this._ZDim = __ZDim;
		}
	
		[Description("Location of the bottom left corner (having the minimum values).")]
		public IfcCartesianPoint Corner { get { return this._Corner; } set { this._Corner = value;} }
	
		[Description("Length attribute (measured along the edge parallel to the X Axis)")]
		public IfcPositiveLengthMeasure XDim { get { return this._XDim; } set { this._XDim = value;} }
	
		[Description("Width attribute (measured along the edge parallel to the Y Axis)")]
		public IfcPositiveLengthMeasure YDim { get { return this._YDim; } set { this._YDim = value;} }
	
		[Description("Height attribute (measured along the edge parallel to the Z Axis).")]
		public IfcPositiveLengthMeasure ZDim { get { return this._ZDim; } set { this._ZDim = value;} }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
