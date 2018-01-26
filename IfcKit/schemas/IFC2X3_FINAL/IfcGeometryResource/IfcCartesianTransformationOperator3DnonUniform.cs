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
	[Guid("add777e1-a564-4099-a6ee-3f1b33f08944")]
	public partial class IfcCartesianTransformationOperator3DnonUniform : IfcCartesianTransformationOperator3D
	{
		[DataMember(Order=0)] 
		Double? _Scale2;
	
		[DataMember(Order=1)] 
		Double? _Scale3;
	
	
		public IfcCartesianTransformationOperator3DnonUniform()
		{
		}
	
		public IfcCartesianTransformationOperator3DnonUniform(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, Double? __Scale, IfcDirection __Axis3, Double? __Scale2, Double? __Scale3)
			: base(__Axis1, __Axis2, __LocalOrigin, __Scale, __Axis3)
		{
			this._Scale2 = __Scale2;
			this._Scale3 = __Scale3;
		}
	
		[Description("The scaling value specified for the transformation along the axis 2. This is norm" +
	    "ally the y scale factor.")]
		public Double? Scale2 { get { return this._Scale2; } set { this._Scale2 = value;} }
	
		[Description("The scaling value specified for the transformation along the axis 3. This is norm" +
	    "ally the z scale factor.")]
		public Double? Scale3 { get { return this._Scale3; } set { this._Scale3 = value;} }
	
		public new Double Scl2 { get { return null; } }
	
		public new Double Scl3 { get { return null; } }
	
	
	}
	
}
