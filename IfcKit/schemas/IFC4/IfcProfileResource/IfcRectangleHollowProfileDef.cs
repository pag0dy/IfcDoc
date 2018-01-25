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
	[Guid("19db74b8-9bbd-4310-a2b8-d47984481a40")]
	public partial class IfcRectangleHollowProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _WallThickness;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _InnerFilletRadius;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcNonNegativeLengthMeasure? _OuterFilletRadius;
	
	
		[Description("Thickness of the material.")]
		public IfcPositiveLengthMeasure WallThickness { get { return this._WallThickness; } set { this._WallThickness = value;} }
	
		[Description("Inner corner radius.")]
		public IfcNonNegativeLengthMeasure? InnerFilletRadius { get { return this._InnerFilletRadius; } set { this._InnerFilletRadius = value;} }
	
		[Description("Outer corner radius.")]
		public IfcNonNegativeLengthMeasure? OuterFilletRadius { get { return this._OuterFilletRadius; } set { this._OuterFilletRadius = value;} }
	
	
	}
	
}
