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


namespace BuildingSmart.IFC.IfcGeometricModelResource
{
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
