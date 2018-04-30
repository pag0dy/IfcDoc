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
	public enum IfcDamperTypeEnum
	{
		[Description("Damper used for purposes of manually balancing pressure differences.  Commonly op" +
	    "erated by mechanical adjustment.")]
		BACKDRAFTDAMPER = 1,
	
		[Description("Backdraft damper used to restrict the movement of air in one direction.  Commonly" +
	    " operated by mechanical spring.")]
		BALANCINGDAMPER = 2,
	
		[Description("Blast damper used to prevent protect occupants and equipment against overpressure" +
	    "s resultant of an explosion.  Commonly operated by mechanical spring.")]
		BLASTDAMPER = 3,
	
		[Description("Control damper used to modulate the flow of air by adjusting the position of the " +
	    "blades.  Commonly operated by an actuator of a building automation system.")]
		CONTROLDAMPER = 4,
	
		[Description("Fire damper used to prevent the spread of fire for a specified duration.  Commonl" +
	    "y operated by fusable link that melts above a certain temperature.")]
		FIREDAMPER = 5,
	
		[Description("Combination fire and smoke damper used to preven the spread of fire and smoke.  C" +
	    "ommonly operated by a fusable link and a smoke detector.")]
		FIRESMOKEDAMPER = 6,
	
		[Description("Fume hood exhaust damper.  Commonly operated by actuator.")]
		FUMEHOODEXHAUST = 7,
	
		[Description("Gravity damper closes from the force of gravity.  Commonly operated by gravitatio" +
	    "nal weight.")]
		GRAVITYDAMPER = 8,
	
		[Description("Gravity-relief damper used to allow air to move upon a buildup of enough pressure" +
	    " to overcome the gravitational force exerted upon the damper blades.  Commonly o" +
	    "perated by gravitational weight.")]
		GRAVITYRELIEFDAMPER = 9,
	
		[Description("Relief damper used to allow air to move upon a buildup of a specified pressure di" +
	    "fferential.  Commonly operated by mechanical spring.")]
		RELIEFDAMPER = 10,
	
		[Description("Smoke damper used to prevent the spread of smoke.  Commonly operated by a smoke d" +
	    "etector of a building automation system.")]
		SMOKEDAMPER = 11,
	
		[Description("User-defined damper.")]
		USERDEFINED = -1,
	
		[Description("Undefined damper.")]
		NOTDEFINED = 0,
	
	}
}
