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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcAxis2Placement3D : IfcPlacement,
		BuildingSmart.IFC.IfcGeometryResource.IfcAxis2Placement
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The exact direction of the local Z Axis.")]
		public IfcDirection Axis { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("The direction used to determine the direction of the local X Axis. If necessary an adjustment is made to maintain orthogonality to the Axis direction. If Axis and/or RefDirection is omitted, these directions are taken from the geometric coordinate system.")]
		public IfcDirection RefDirection { get; set; }
	
	
		public IfcAxis2Placement3D(IfcCartesianPoint __Location, IfcDirection __Axis, IfcDirection __RefDirection)
			: base(__Location)
		{
			this.Axis = __Axis;
			this.RefDirection = __RefDirection;
		}
	
		public new IList<IfcDirection> P { get { return null; } }
	
	
	}
	
}
