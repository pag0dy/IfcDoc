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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("0fa060dd-f132-4bb8-8a8a-c3ca6b00aae1")]
	public partial class IfcFaceOuterBound : IfcFaceBound
	{
	
		public IfcFaceOuterBound()
		{
		}
	
		public IfcFaceOuterBound(IfcLoop __Bound, Boolean __Orientation)
			: base(__Bound, __Orientation)
		{
		}
	
	
	}
	
}
