// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
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
	[Guid("6b283852-794e-461c-8a05-2d7e9a211c85")]
	public partial class IfcCartesianTransformationOperator2DnonUniform : IfcCartesianTransformationOperator2D
	{
		[DataMember(Order=0)] 
		Double? _Scale2;
	
	
		public IfcCartesianTransformationOperator2DnonUniform()
		{
		}
	
		public IfcCartesianTransformationOperator2DnonUniform(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, Double? __Scale, Double? __Scale2)
			: base(__Axis1, __Axis2, __LocalOrigin, __Scale)
		{
			this._Scale2 = __Scale2;
		}
	
		[Description("The scaling value specified for the transformation along the axis 2. This is norm" +
	    "ally the y scale factor.")]
		public Double? Scale2 { get { return this._Scale2; } set { this._Scale2 = value;} }

        public new Double Scl2 { get { return 0.0; } }
	
	
	}
	
}
