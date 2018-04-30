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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcSphere : IfcCsgPrimitive3D
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The radius of the sphere.")]
		[Required()]
		public IfcPositiveLengthMeasure Radius { get; set; }
	
	
		public IfcSphere(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __Radius)
			: base(__Position)
		{
			this.Radius = __Radius;
		}
	
	
	}
	
}
