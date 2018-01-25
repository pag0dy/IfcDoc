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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("283bc76c-8d97-414d-a5ef-96f76f53702f")]
	public partial class IfcCartesianTransformationOperator3DnonUniform : IfcCartesianTransformationOperator3D
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcReal? _Scale2;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcReal? _Scale3;
	
	
		[Description("The scaling value specified for the transformation along the axis 2. This is norm" +
	    "ally the y scale factor.")]
		public IfcReal? Scale2 { get { return this._Scale2; } set { this._Scale2 = value;} }
	
		[Description("The scaling value specified for the transformation along the axis 3. This is norm" +
	    "ally the z scale factor.")]
		public IfcReal? Scale3 { get { return this._Scale3; } set { this._Scale3 = value;} }
	
	
	}
	
}
