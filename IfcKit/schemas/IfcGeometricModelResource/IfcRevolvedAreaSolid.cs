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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcRevolvedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Axis about which revolution will take place.")]
		[Required()]
		public IfcAxis1Placement Axis { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The angle through which the sweep will be made. This angle is measured from the plane of the swept area provided by the XY plane of the position coordinate system.")]
		[Required()]
		public IfcPlaneAngleMeasure Angle { get; set; }
	
	
		public IfcRevolvedAreaSolid(IfcProfileDef __SweptArea, IfcAxis2Placement3D __Position, IfcAxis1Placement __Axis, IfcPlaneAngleMeasure __Angle)
			: base(__SweptArea, __Position)
		{
			this.Axis = __Axis;
			this.Angle = __Angle;
		}
	
		public new IfcLine AxisLine { get { return null; } }
	
	
	}
	
}
