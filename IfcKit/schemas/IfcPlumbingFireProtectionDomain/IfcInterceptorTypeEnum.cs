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


namespace BuildingSmart.IFC.IfcPlumbingFireProtectionDomain
{
	public enum IfcInterceptorTypeEnum
	{
		[Description("Removes larger liquid drops or larger solid particles.")]
		CYCLONIC = 1,
	
		[Description("Chamber, on the line of a drain or discharge pipe, that prevents grease passing i" +
	    "nto a drainage system.")]
		GREASE = 2,
	
		[Description("One or more chambers arranged to prevent the ingress of oil to a drain or sewer t" +
	    "hat retains the oil for later removal.")]
		OIL = 3,
	
		[Description("Two or more chambers with inlet and outlet pipes arranged to allow petrol/gasolin" +
	    "e collected on the surface of water drained into them to evaporate through venti" +
	    "lating pipes.")]
		PETROL = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
