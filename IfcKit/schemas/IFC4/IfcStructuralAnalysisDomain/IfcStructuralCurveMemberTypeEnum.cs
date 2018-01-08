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
	[Guid("dc662673-0379-4276-8c8c-c30feb5e1d70")]
	public enum IfcStructuralCurveMemberTypeEnum
	{
		RIGID_JOINED_MEMBER = 1,
	
		PIN_JOINED_MEMBER = 2,
	
		CABLE = 3,
	
		TENSION_MEMBER = 4,
	
		COMPRESSION_MEMBER = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
