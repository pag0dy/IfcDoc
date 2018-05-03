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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcSurfaceOfRevolution : IfcSweptSurface
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("A point on the axis of revolution and the direction of the axis of revolution.")]
		[Required()]
		public IfcAxis1Placement AxisPosition { get; set; }
	
	
		public IfcSurfaceOfRevolution(IfcProfileDef __SweptCurve, IfcAxis2Placement3D __Position, IfcAxis1Placement __AxisPosition)
			: base(__SweptCurve, __Position)
		{
			this.AxisPosition = __AxisPosition;
		}
	
		public new IfcLine AxisLine { get { return null; } }
	
	
	}
	
}
