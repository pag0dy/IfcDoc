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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcOutletTypeEnum
	{
		[Description("An outlet used for an audio or visual device.")]
		AUDIOVISUALOUTLET = 1,
	
		[Description("An outlet used for connecting communications equipment.")]
		COMMUNICATIONSOUTLET = 2,
	
		[Description("An outlet used for connecting electrical devices requiring power.")]
		POWEROUTLET = 3,
	
		[Description("An outlet used for connecting data communications equipment.")]
		DATAOUTLET = 4,
	
		[Description("An outlet used for connecting telephone communications equipment.")]
		TELEPHONEOUTLET = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.<")]
		NOTDEFINED = 0,
	
	}
}
