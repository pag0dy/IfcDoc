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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("ead0e11b-6c81-40f3-ac8b-50c6867c3ffb")]
	public enum IfcSurfaceSide
	{
		[Description("The side of a surface which is in the same direction as the surface normal derive" +
	    "d from the mathematical definition.")]
		POSITIVE = 1,
	
		[Description("The side of a surface which is in the opposite direction than the surface normal " +
	    "derived from the mathematical definition.")]
		NEGATIVE = 2,
	
		[Description("Both, positive and negative side.")]
		BOTH = 3,
	
	}
}
