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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	public enum IfcFilterTypeEnum
	{
		[Description("A filter used to remove particulates from air.")]
		AIRPARTICLEFILTER = 1,
	
		[Description("A filter used to remove particulates from compressed air.")]
		COMPRESSEDAIRFILTER = 2,
	
		[Description("A filter used to remove odors from air.")]
		ODORFILTER = 3,
	
		[Description("A filter used to remove particulates from oil.")]
		OILFILTER = 4,
	
		[Description("A filter used to remove particulates from a fluid.")]
		STRAINER = 5,
	
		[Description("A filter used to remove particulates from water.")]
		WATERFILTER = 6,
	
		[Description("User-defined filter type.")]
		USERDEFINED = -1,
	
		[Description("Undefined filter type.")]
		NOTDEFINED = 0,
	
	}
}
