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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcToroidalSurface : IfcElementarySurface
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The major radius of the torus.")]
		[Required()]
		public IfcPositiveLengthMeasure MajorRadius { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The minor radius of the torus.")]
		[Required()]
		public IfcPositiveLengthMeasure MinorRadius { get; set; }
	
	
		public IfcToroidalSurface(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __MajorRadius, IfcPositiveLengthMeasure __MinorRadius)
			: base(__Position)
		{
			this.MajorRadius = __MajorRadius;
			this.MinorRadius = __MinorRadius;
		}
	
	
	}
	
}
