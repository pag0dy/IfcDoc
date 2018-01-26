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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("6a71ad06-e92c-4e8d-bb08-441d03da182e")]
	public abstract partial class IfcSolidModel : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricModelResource.IfcBooleanOperand,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcSolidOrShell
	{
	
		public IfcSolidModel()
		{
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
