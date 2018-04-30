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
	public partial class IfcExtrudedAreaSolid : IfcSweptAreaSolid
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The direction in which the surface, provided by <em>SweptArea</em> is to be swept.")]
		[Required()]
		public IfcDirection ExtrudedDirection { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The distance the surface is to be swept along the <em>ExtrudedDirection</em>.")]
		[Required()]
		public IfcPositiveLengthMeasure Depth { get; set; }
	
	
		public IfcExtrudedAreaSolid(IfcProfileDef __SweptArea, IfcAxis2Placement3D __Position, IfcDirection __ExtrudedDirection, IfcPositiveLengthMeasure __Depth)
			: base(__SweptArea, __Position)
		{
			this.ExtrudedDirection = __ExtrudedDirection;
			this.Depth = __Depth;
		}
	
	
	}
	
}
