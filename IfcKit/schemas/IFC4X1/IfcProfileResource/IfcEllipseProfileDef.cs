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
	[Guid("e019e0b0-86e1-4188-85b1-4d934b9a1046")]
	public partial class IfcEllipseProfileDef : IfcParameterizedProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _SemiAxis1;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _SemiAxis2;
	
	
		[Description("The first radius of the ellipse. It is measured along the direction of Position.P" +
	    "[1].")]
		public IfcPositiveLengthMeasure SemiAxis1 { get { return this._SemiAxis1; } set { this._SemiAxis1 = value;} }
	
		[Description("The second radius of the ellipse. It is measured along the direction of Position." +
	    "P[2].")]
		public IfcPositiveLengthMeasure SemiAxis2 { get { return this._SemiAxis2; } set { this._SemiAxis2 = value;} }
	
	
	}
	
}
