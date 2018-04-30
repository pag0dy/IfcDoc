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
	public partial class IfcCartesianTransformationOperator2DnonUniform : IfcCartesianTransformationOperator2D
	{
		[DataMember(Order = 0)] 
		[Description("The scaling value specified for the transformation along the axis 2. This is normally the y scale factor.")]
		public Double? Scale2 { get; set; }
	
	
		public IfcCartesianTransformationOperator2DnonUniform(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, Double? __Scale, Double? __Scale2)
			: base(__Axis1, __Axis2, __LocalOrigin, __Scale)
		{
			this.Scale2 = __Scale2;
		}
	
		public new Double Scl2 { get { return null; } }
	
	
	}
	
}
