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
	[Guid("88a91c6a-1986-40f1-8551-6a855b5424f5")]
	public enum IfcTransformerTypeEnum
	{
		CURRENT = 1,
	
		FREQUENCY = 2,
	
		INVERTER = 3,
	
		RECTIFIER = 4,
	
		VOLTAGE = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
