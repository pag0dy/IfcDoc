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


namespace BuildingSmart.IFC.IfcUtilityResource
{
	public enum IfcStateEnum
	{
		[Description("Object is in a Read-Write state. It may be modified by an application.")]
		READWRITE = 1,
	
		[Description("Object is in a Read-Only state. It may be viewed but not modified by an applicati" +
	    "on.")]
		READONLY = 2,
	
		[Description("Object is in a Locked state. It may not be accessed by an application.")]
		LOCKED = 3,
	
		[Description("Object is in a Read-Write-Locked state. It may not be accessed by an application." +
	    "")]
		READWRITELOCKED = 4,
	
		[Description("Object is in a Read-Only-Locked state. It may not be accessed by an application.")]
		READONLYLOCKED = 5,
	
	}
}
