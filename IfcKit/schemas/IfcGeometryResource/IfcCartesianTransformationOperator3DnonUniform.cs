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

using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcCartesianTransformationOperator3DnonUniform : IfcCartesianTransformationOperator3D
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The scaling value specified for the transformation along the axis 2. This is normally the y scale factor.")]
		public IfcReal? Scale2 { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The scaling value specified for the transformation along the axis 3. This is normally the z scale factor.")]
		public IfcReal? Scale3 { get; set; }
	
	
		public IfcCartesianTransformationOperator3DnonUniform(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, IfcReal? __Scale, IfcDirection __Axis3, IfcReal? __Scale2, IfcReal? __Scale3)
			: base(__Axis1, __Axis2, __LocalOrigin, __Scale, __Axis3)
		{
			this.Scale2 = __Scale2;
			this.Scale3 = __Scale3;
		}
	
		public new IfcReal Scl2 { get { return new IfcReal(); } }
	
		public new IfcReal Scl3 { get { return new IfcReal(); } }
	
	
	}
	
}
