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
	public partial class IfcAxis1Placement : IfcPlacement
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The direction of the local Z axis.")]
		public IfcDirection Axis { get; set; }
	
	
		public IfcAxis1Placement(IfcCartesianPoint __Location, IfcDirection __Axis)
			: base(__Location)
		{
			this.Axis = __Axis;
		}
	
		public new IfcDirection Z { get { return null; } }
	
	
	}
	
}
