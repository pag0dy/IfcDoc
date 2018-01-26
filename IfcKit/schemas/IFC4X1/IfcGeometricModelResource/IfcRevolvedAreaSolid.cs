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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("81970f2f-c63e-4133-adaf-c74d522cb449")]
	public partial class IfcRevolvedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcAxis1Placement _Axis;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPlaneAngleMeasure _Angle;
	
	
		public IfcRevolvedAreaSolid()
		{
		}
	
		public IfcRevolvedAreaSolid(IfcProfileDef __SweptArea, IfcAxis2Placement3D __Position, IfcAxis1Placement __Axis, IfcPlaneAngleMeasure __Angle)
			: base(__SweptArea, __Position)
		{
			this._Axis = __Axis;
			this._Angle = __Angle;
		}
	
		[Description("Axis about which revolution will take place.")]
		public IfcAxis1Placement Axis { get { return this._Axis; } set { this._Axis = value;} }
	
		[Description("The angle through which the sweep will be made. This angle is measured from the p" +
	    "lane of the swept area provided by the XY plane of the position coordinate syste" +
	    "m.")]
		public IfcPlaneAngleMeasure Angle { get { return this._Angle; } set { this._Angle = value;} }
	
		public new IfcLine AxisLine { get { return null; } }
	
	
	}
	
}
