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
	[Guid("c19af08b-7c2a-43da-af36-f179667c4b1b")]
	public partial class IfcCartesianTransformationOperator2D : IfcCartesianTransformationOperator
	{
	
		public IfcCartesianTransformationOperator2D()
		{
		}
	
		public IfcCartesianTransformationOperator2D(IfcDirection __Axis1, IfcDirection __Axis2, IfcCartesianPoint __LocalOrigin, Double? __Scale)
			: base(__Axis1, __Axis2, __LocalOrigin, __Scale)
		{
		}
	
		public new IList<IfcDirection> U { get { return null; } }
	
	
	}
	
}
