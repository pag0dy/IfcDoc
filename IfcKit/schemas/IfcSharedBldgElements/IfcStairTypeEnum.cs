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
	public enum IfcStairTypeEnum
	{
		[Description("A stair extending from one level to another without turns or winders. The stair c" +
	    "onsists of one straight flight.")]
		STRAIGHT_RUN_STAIR = 1,
	
		[Description("A straight stair consisting of two straight flights without turns but with one la" +
	    "nding.")]
		TWO_STRAIGHT_RUN_STAIR = 2,
	
		[Description("A stair consisting of one flight with a quarter winder, which is making a 90&deg;" +
	    " turn. The direction of the turn is determined by the walking line.")]
		QUARTER_WINDING_STAIR = 3,
	
		[Description("A stair making a 90&deg; turn, consisting of two straight flights connected by a " +
	    "quarterspace landing. The direction of the turn is determined by the walking lin" +
	    "e.")]
		QUARTER_TURN_STAIR = 4,
	
		[Description("A stair consisting of one flight with one half winder, which makes a 180&deg; tur" +
	    "n. The orientation of the turn is determined by the walking line.")]
		HALF_WINDING_STAIR = 5,
	
		[Description("A stair making a 180&deg; turn, consisting of two straight flights connected\r\nby " +
	    "a halfspace landing. The orientation of the turn is determined by the walking li" +
	    "ne.")]
		HALF_TURN_STAIR = 6,
	
		[Description("A stair consisting of one flight with two quarter winders, which make a\r\n90&deg; " +
	    "turn. The stair makes a 180&deg; turn. The direction of the turns is determined " +
	    "by the walking line.")]
		TWO_QUARTER_WINDING_STAIR = 7,
	
		[Description("A stair making a 180&deg; turn, consisting of three straight flights connected by" +
	    " two quarterspace landings. The direction of the turns is determined by the walk" +
	    "ing line.")]
		TWO_QUARTER_TURN_STAIR = 8,
	
		[Description("A stair consisting of one flight with three quarter winders, which make a\r\n90&deg" +
	    "; turn. The stair makes a 270&deg; turn. The direction of the turns is determine" +
	    "d by the walking line.")]
		THREE_QUARTER_WINDING_STAIR = 9,
	
		[Description("A stair making a 270&deg; turn, consisting of four straight flights connected\r\nby" +
	    " three quarterspace landings. The direction of the turns is determined by the wa" +
	    "lking line.")]
		THREE_QUARTER_TURN_STAIR = 10,
	
		[Description("A stair constructed with winders around a circular newel often without landings. " +
	    "Depending on outer boundary it can be either a circular, elliptical or rectangul" +
	    "ar spiral stair. The orientation of the winding stairs is determined by the walk" +
	    "ing line.")]
		SPIRAL_STAIR = 11,
	
		[Description("A stair having one straight flight to a wide quarterspace landing, and two side f" +
	    "lights from that landing into opposite directions. The stair is making a 90&deg;" +
	    " turn. The direction of traffic is determined by the walking line.")]
		DOUBLE_RETURN_STAIR = 12,
	
		[Description("A stair extending from one level to another without turns or winders. The stair i" +
	    "s consisting of one curved flight.")]
		CURVED_RUN_STAIR = 13,
	
		[Description("A curved stair consisting of two curved flights without turns but with one landin" +
	    "g.")]
		TWO_CURVED_RUN_STAIR = 14,
	
		[Description("Free form stair (user defined operation type).")]
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
