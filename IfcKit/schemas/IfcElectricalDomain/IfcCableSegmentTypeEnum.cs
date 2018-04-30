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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcCableSegmentTypeEnum
	{
		[Description("Electrical conductor that makes a common connection between several electrical ci" +
	    "rcuits. Properties of a busbar are the same as those of a cable segment and are " +
	    "captured by the cable segment property set.")]
		BUSBARSEGMENT = 1,
	
		[Description("Cable with a specific purpose to lead electric current within a circuit or any ot" +
	    "her electric construction. Includes all types of electric cables, mainly several" +
	    " core segments or conductor segments wrapped together.")]
		CABLESEGMENT = 2,
	
		[Description("A single linear element within a cable or an exposed wire (such as for grounding)" +
	    " with the specific purpose to lead electric current, data, or a telecommunicatio" +
	    "ns signal.")]
		CONDUCTORSEGMENT = 3,
	
		[Description("A self contained element of a  cable that comprises one or more conductors and sh" +
	    "eathing.The core of one lead is normally single wired or multiwired which are in" +
	    "tertwined.")]
		CORESEGMENT = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
