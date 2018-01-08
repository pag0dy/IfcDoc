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

using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("e5e76080-c2b4-461b-80bc-d38dd823c6d6")]
	public enum IfcProtectiveDeviceTypeEnum
	{
		CIRCUITBREAKER = 1,
	
		EARTHLEAKAGECIRCUITBREAKER = 2,
	
		EARTHINGSWITCH = 3,
	
		FUSEDISCONNECTOR = 4,
	
		RESIDUALCURRENTCIRCUITBREAKER = 5,
	
		RESIDUALCURRENTSWITCH = 6,
	
		VARISTOR = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
