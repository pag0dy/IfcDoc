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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("0dec71ae-dfa6-4284-9891-3929855c44d7")]
	public enum IfcVoidingFeatureTypeEnum
	{
		CUTOUT = 1,
	
		NOTCH = 2,
	
		HOLE = 3,
	
		MITER = 4,
	
		CHAMFER = 5,
	
		EDGE = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
