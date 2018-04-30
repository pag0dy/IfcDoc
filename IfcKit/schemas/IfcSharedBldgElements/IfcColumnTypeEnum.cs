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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public enum IfcColumnTypeEnum
	{
		[Description("A standard member usually vertical and requiring resistance to vertical forces by" +
	    " compression but also sometimes to lateral forces.")]
		COLUMN = 1,
	
		[Description("A column element embedded within a wall that can be required to be load bearing b" +
	    "ut may also only be used for decorative purposes.")]
		PILASTER = 2,
	
		[Description("User-defined linear element.")]
		USERDEFINED = -1,
	
		[Description("Undefined linear element.")]
		NOTDEFINED = 0,
	
	}
}
