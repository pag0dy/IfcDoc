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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("40a56bc9-ee1f-4c1c-8b52-cbd53cb62d74")]
	public enum IfcActionSourceTypeEnum
	{
		DEAD_LOAD_G = 1,
	
		COMPLETION_G1 = 2,
	
		LIVE_LOAD_Q = 3,
	
		SNOW_S = 4,
	
		WIND_W = 5,
	
		PRESTRESSING_P = 6,
	
		SETTLEMENT_U = 7,
	
		TEMPERATURE_T = 8,
	
		EARTHQUAKE_E = 9,
	
		FIRE = 10,
	
		IMPULSE = 11,
	
		IMPACT = 12,
	
		TRANSPORT = 13,
	
		ERECTION = 14,
	
		PROPPING = 15,
	
		SYSTEM_IMPERFECTION = 16,
	
		SHRINKAGE = 17,
	
		CREEP = 18,
	
		LACK_OF_FIT = 19,
	
		BUOYANCY = 20,
	
		ICE = 21,
	
		CURRENT = 22,
	
		WAVE = 23,
	
		RAIN = 24,
	
		BRAKES = 25,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
