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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcSurfaceOfLinearExtrusion : IfcSweptSurface
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The direction of the extrusion.")]
		[Required()]
		public IfcDirection ExtrudedDirection { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The depth of the extrusion, it determines the parameterization.")]
		[Required()]
		public IfcLengthMeasure Depth { get; set; }
	
	
		public IfcSurfaceOfLinearExtrusion(IfcProfileDef __SweptCurve, IfcAxis2Placement3D __Position, IfcDirection __ExtrudedDirection, IfcLengthMeasure __Depth)
			: base(__SweptCurve, __Position)
		{
			this.ExtrudedDirection = __ExtrudedDirection;
			this.Depth = __Depth;
		}
	
		public new IfcVector ExtrusionAxis { get { return null; } }
	
	
	}
	
}
