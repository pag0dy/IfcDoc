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
	[Guid("1d63be08-0548-4ede-bf7c-c2246ea77676")]
	public partial class IfcExtrudedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDirection _ExtrudedDirection;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Depth;
	
	
		[Description("The direction in which the surface is to be swept.")]
		public IfcDirection ExtrudedDirection { get { return this._ExtrudedDirection; } set { this._ExtrudedDirection = value;} }
	
		[Description("The distance the surface is to be swept.")]
		public IfcPositiveLengthMeasure Depth { get { return this._Depth; } set { this._Depth = value;} }
	
	
	}
	
}
