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
	[Guid("2d68fd21-4236-40d5-a724-8b24e7764b32")]
	public enum IfcElectricFlowStorageDeviceTypeEnum
	{
		BATTERY = 1,
	
		CAPACITORBANK = 2,
	
		HARMONICFILTER = 3,
	
		INDUCTORBANK = 4,
	
		UPS = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
