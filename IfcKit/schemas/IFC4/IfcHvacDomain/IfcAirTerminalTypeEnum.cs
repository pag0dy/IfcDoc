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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("2a1d1a8d-13ee-429e-b316-c186dd2f7bfe")]
	public enum IfcAirTerminalTypeEnum
	{
		[Description("An outlet discharging supply air in various directions and planes.")]
		DIFFUSER = 1,
	
		[Description("A covering for any area through which air passes.")]
		GRILLE = 2,
	
		[Description("A rectilinear louvre.")]
		LOUVRE = 3,
	
		[Description("A grille typically equipped with a damper or control valve.")]
		REGISTER = 4,
	
		[Description("User-defined air terminal type.")]
		USERDEFINED = -1,
	
		[Description("Undefined air terminal type.")]
		NOTDEFINED = 0,
	
	}
}
