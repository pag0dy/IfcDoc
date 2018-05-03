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
	public enum IfcFanTypeEnum
	{
		[Description("Air flows through the impeller radially using blades that are forward curved.")]
		CENTRIFUGALFORWARDCURVED = 1,
	
		[Description("Air flows through the impeller radially using blades that are uncurved or slightl" +
	    "y forward curved.")]
		CENTRIFUGALRADIAL = 2,
	
		[Description("Air flows through the impeller radially using blades that are backward curved.")]
		CENTRIFUGALBACKWARDINCLINEDCURVED = 3,
	
		[Description("Air flows through the impeller radially using blades that are airfoil shaped.")]
		CENTRIFUGALAIRFOIL = 4,
	
		[Description("Air flows through the impeller axially with guide vanes and reduced running blade" +
	    " tip clearance.")]
		TUBEAXIAL = 5,
	
		[Description("Air flows through the impeller axially with guide vanes and reduced running blade" +
	    " tip clearance.")]
		VANEAXIAL = 6,
	
		[Description("Air flows through the impeller axially and small hub-to-tip ratio impeller mounte" +
	    "d in an orifice plate or inlet ring.")]
		PROPELLORAXIAL = 7,
	
		[Description("User-defined fan type.")]
		USERDEFINED = -1,
	
		[Description("Undefined fan type.")]
		NOTDEFINED = 0,
	
	}
}
