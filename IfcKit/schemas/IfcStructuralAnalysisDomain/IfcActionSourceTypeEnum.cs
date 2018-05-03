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


namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
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
