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


namespace BuildingSmart.IFC.IfcProcessExtension
{
	public enum IfcEventTriggerTypeEnum
	{
		[Description("An event trigger that is a rule or constraint.")]
		EVENTRULE = 1,
	
		[Description("An event trigger that is a message or set of information.")]
		EVENTMESSAGE = 2,
	
		[Description("An event trigger that is at, or occurs after, a particular point in or period of " +
	    "time.")]
		EVENTTIME = 3,
	
		[Description("An event trigger that is a complex combination of things.")]
		EVENTCOMPLEX = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
