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
	public enum IfcRampTypeEnum
	{
		[Description("A ramp - which is a sloping floor, walk, or roadway - connecting two levels.\r\nThe" +
	    " straight ramp consists of one straight flight without turns or winders.")]
		STRAIGHT_RUN_RAMP = 1,
	
		[Description("A straight ramp consisting of two straight flights without turns but with one\r\nla" +
	    "nding.")]
		TWO_STRAIGHT_RUN_RAMP = 2,
	
		[Description("A ramp making a 90&deg; turn, consisting of two straight flights connected by\r\na " +
	    "quarterspace landing. The direction of the turn is determined by the walking lin" +
	    "e.")]
		QUARTER_TURN_RAMP = 3,
	
		[Description("A ramp making a 180&deg; turn, consisting of three straight flights connected\r\nby" +
	    " two quarterspace landings. The direction of the turn is determined by the walki" +
	    "ng line.")]
		TWO_QUARTER_TURN_RAMP = 4,
	
		[Description("A ramp making a 180&deg; turn, consisting of two straight flights connected\r\nby a" +
	    " halfspace landing. The orientation of the turn is determined by the walking lin" +
	    "e.")]
		HALF_TURN_RAMP = 5,
	
		[Description("A ramp constructed around a circular or elliptical well without newels and\r\nlandi" +
	    "ngs.")]
		SPIRAL_RAMP = 6,
	
		[Description("Free form ramp (user defined operation type).")]
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
