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
	[Guid("76426990-f6c8-4462-b489-68361df1c390")]
	public partial class IfcRectangleProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _XDim;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _YDim;
	
	
		[Description("The extent of the rectangle in the direction of the x-axis.")]
		public IfcPositiveLengthMeasure XDim { get { return this._XDim; } set { this._XDim = value;} }
	
		[Description("The extent of the rectangle in the direction of the y-axis.")]
		public IfcPositiveLengthMeasure YDim { get { return this._YDim; } set { this._YDim = value;} }
	
	
	}
	
}
