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
	public partial class IfcPointOnSurface : IfcPoint
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The surface to which the parameter values relate.")]
		[Required()]
		public IfcSurface BasisSurface { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The first parameter value of the point location.")]
		[Required()]
		public IfcParameterValue PointParameterU { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The second parameter value of the point location.")]
		[Required()]
		public IfcParameterValue PointParameterV { get; set; }
	
	
		public IfcPointOnSurface(IfcSurface __BasisSurface, IfcParameterValue __PointParameterU, IfcParameterValue __PointParameterV)
		{
			this.BasisSurface = __BasisSurface;
			this.PointParameterU = __PointParameterU;
			this.PointParameterV = __PointParameterV;
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
