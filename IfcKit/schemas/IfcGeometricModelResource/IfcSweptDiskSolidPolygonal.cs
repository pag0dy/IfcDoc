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

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcSweptDiskSolidPolygonal : IfcSweptDiskSolid
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The fillet that is equally applied to all transitions between the segments of the <em>IfcPolyline</em>, providing the geometric representation for <em>the Directrix</em>. If omited, no fillet is applied to the segments. ")]
		public IfcPositiveLengthMeasure? FilletRadius { get; set; }
	
	
		public IfcSweptDiskSolidPolygonal(IfcCurve __Directrix, IfcPositiveLengthMeasure __Radius, IfcPositiveLengthMeasure? __InnerRadius, IfcParameterValue? __StartParam, IfcParameterValue? __EndParam, IfcPositiveLengthMeasure? __FilletRadius)
			: base(__Directrix, __Radius, __InnerRadius, __StartParam, __EndParam)
		{
			this.FilletRadius = __FilletRadius;
		}
	
	
	}
	
}
