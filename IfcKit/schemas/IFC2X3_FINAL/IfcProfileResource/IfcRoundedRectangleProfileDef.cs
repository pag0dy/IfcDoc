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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("fcb990fe-fa91-4a91-af10-de5e3824318d")]
	public partial class IfcRoundedRectangleProfileDef : IfcRectangleProfileDef
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _RoundingRadius;
	
	
		[Description("Radius of the circular arcs, by which all four corners of the rectangle are equal" +
	    "ly rounded. If not given, zero (= no rounding arcs) applies.")]
		public IfcPositiveLengthMeasure RoundingRadius { get { return this._RoundingRadius; } set { this._RoundingRadius = value;} }
	
	
	}
	
}
