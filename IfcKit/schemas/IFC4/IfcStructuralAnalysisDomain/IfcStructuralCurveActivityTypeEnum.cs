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
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("2e08e9d6-c90f-49ea-8c0c-2fd435941832")]
	public enum IfcStructuralCurveActivityTypeEnum
	{
		CONST = 1,
	
		LINEAR = 2,
	
		POLYGONAL = 3,
	
		EQUIDISTANT = 4,
	
		SINUS = 5,
	
		PARABOLA = 6,
	
		DISCRETE = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
