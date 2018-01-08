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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("ef1ca58b-1cf6-4925-9fb7-4144c2729c39")]
	public enum IfcBooleanOperator
	{
		[Description("The operation of constructing the regularized set theoretic union of the volumes " +
	    "defined by two solids.")]
		UNION = 1,
	
		[Description("The operation of constructing the regularised set theoretic intersection of the v" +
	    "olumes defined by two solids.")]
		INTERSECTION = 2,
	
		[Description("The regularised set theoretic difference between the volumes defined by two solid" +
	    "s.")]
		DIFFERENCE = 3,
	
	}
}
