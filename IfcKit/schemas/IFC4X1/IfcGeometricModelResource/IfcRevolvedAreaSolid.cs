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
	[Guid("7da3601b-9ac2-4100-91e3-d883f16a8be8")]
	public partial class IfcRevolvedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis1Placement _Axis;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPlaneAngleMeasure _Angle;
	
	
		[Description("Axis about which revolution will take place.")]
		public IfcAxis1Placement Axis { get { return this._Axis; } set { this._Axis = value;} }
	
		[Description("Angle through which the sweep will be made. This angle is measured from the plane" +
	    " of the sweep.")]
		public IfcPlaneAngleMeasure Angle { get { return this._Angle; } set { this._Angle = value;} }
	
		public new IfcLine AxisLine { get { return null; } }
	
	
	}
	
}
