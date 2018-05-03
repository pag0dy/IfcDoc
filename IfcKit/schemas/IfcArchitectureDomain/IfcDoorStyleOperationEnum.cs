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


namespace BuildingSmart.IFC.IfcArchitectureDomain
{
	public enum IfcDoorStyleOperationEnum
	{
		[Description("Door with one panel that opens (swings) to the left. The hinges are on the left s" +
	    "ide as viewed in the direction of the positive y-axis.")]
		SINGLE_SWING_LEFT = 1,
	
		[Description("Door with one panel that swings in both directions and to the right in the main t" +
	    "rafic direction. Also called double acting door.")]
		SINGLE_SWING_RIGHT = 2,
	
		[Description("Door with two panels, one swings in both directions and to the right in the main " +
	    "trafic direction the other swings also in both directions and to the left in the" +
	    " main trafic direction.")]
		DOUBLE_DOOR_SINGLE_SWING = 3,
	
		[Description("Door with two panels that both open to the left, one panel swings in one directio" +
	    "n and the other panel swings in the opposite direction.")]
		DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_LEFT = 4,
	
		[Description("Door with two panels that both open to the right, one panel swings in one directi" +
	    "on and the other panel swings in the opposite direction.")]
		DOUBLE_DOOR_SINGLE_SWING_OPPOSITE_RIGHT = 5,
	
		DOUBLE_SWING_LEFT = 6,
	
		DOUBLE_SWING_RIGHT = 7,
	
		DOUBLE_DOOR_DOUBLE_SWING = 8,
	
		[Description("Door with one panel that is sliding to the left.")]
		SLIDING_TO_LEFT = 9,
	
		[Description("Door with one panel that is sliding to the right.")]
		SLIDING_TO_RIGHT = 10,
	
		[Description("Door with two panels, one is sliding to the left the other is sliding to the righ" +
	    "t.")]
		DOUBLE_DOOR_SLIDING = 11,
	
		[Description("Door with one panel that is folding to the left.")]
		FOLDING_TO_LEFT = 12,
	
		[Description("Door with one panel that is folding to the right.")]
		FOLDING_TO_RIGHT = 13,
	
		[Description("Door with two panels, one is folding to the left the other is folding to the righ" +
	    "t.")]
		DOUBLE_DOOR_FOLDING = 14,
	
		[Description("An entrance door consisting of four leaves set in a form of a cross and revolving" +
	    " around a central vertical axis (the four panels are described by a single <em>I" +
	    "fcDoor</em> panel property).")]
		REVOLVING = 15,
	
		[Description("Door that opens by rolling up.")]
		ROLLINGUP = 16,
	
		[Description("User defined operation type")]
		USERDEFINED = -1,
	
		[Description("A door with a\r\nnot defined operation type is\r\nconsidered as a door with a lining," +
	    " but no panels. It is thereby always\r\nopen.")]
		NOTDEFINED = 0,
	
	}
}
