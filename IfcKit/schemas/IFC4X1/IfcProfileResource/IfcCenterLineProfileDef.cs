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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("7c8824b5-eca4-4977-8631-71274a016d0c")]
	public partial class IfcCenterLineProfileDef : IfcArbitraryOpenProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Thickness;
	
	
		public IfcCenterLineProfileDef()
		{
		}
	
		public IfcCenterLineProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcBoundedCurve __Curve, IfcPositiveLengthMeasure __Thickness)
			: base(__ProfileType, __ProfileName, __Curve)
		{
			this._Thickness = __Thickness;
		}
	
		[Description("Constant thickness applied along the center line.")]
		public IfcPositiveLengthMeasure Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
	
	}
	
}
