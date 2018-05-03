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


namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public enum IfcTendonTypeEnum
	{
		[Description("The tendon is configured as a bar.")]
		BAR = 1,
	
		[Description("The tendon is coated.")]
		COATED = 2,
	
		[Description("The tendon is a strand.")]
		STRAND = 3,
	
		[Description("The tendon is a wire.")]
		WIRE = 4,
	
		[Description("The type of tendon is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of tendon is not defined.")]
		NOTDEFINED = 0,
	
	}
}
