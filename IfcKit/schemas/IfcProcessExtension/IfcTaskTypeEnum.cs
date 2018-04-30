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
	public enum IfcTaskTypeEnum
	{
		[Description("Attendance or waiting on other things happening.")]
		ATTENDANCE = 1,
	
		[Description("Constructing or building something.")]
		CONSTRUCTION = 2,
	
		[Description("Demolishing or breaking down something.")]
		DEMOLITION = 3,
	
		[Description("Taking something apart carefully so that it can be recycled or reused.")]
		DISMANTLE = 4,
	
		[Description("Disposing or getting rid of something.")]
		DISPOSAL = 5,
	
		[Description("Installing something (equivalent to construction but more commonly used for engin" +
	    "eering tasks).")]
		INSTALLATION = 6,
	
		[Description("Transporation or delivery of something.")]
		LOGISTIC = 7,
	
		[Description("Keeping something in good working order.")]
		MAINTENANCE = 8,
	
		[Description("Moving things from one place to another.")]
		MOVE = 9,
	
		[Description("A procedure undertaken to start up the operation an artifact.")]
		OPERATION = 10,
	
		[Description("Removal of an item from use and taking it from its place of use.")]
		REMOVAL = 11,
	
		[Description("Bringing something to an \'as-new\' state.")]
		RENOVATION = 12,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
