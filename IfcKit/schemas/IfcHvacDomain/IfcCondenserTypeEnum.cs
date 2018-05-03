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
	public enum IfcCondenserTypeEnum
	{
		[Description("A condenser in which heat is transferred to an air-stream.")]
		AIRCOOLED = 1,
	
		[Description("A condenser that is cooled evaporatively.")]
		EVAPORATIVECOOLED = 2,
	
		[Description("Water-cooled condenser with unspecified operation.")]
		WATERCOOLED = 3,
	
		[Description("Water-cooled condenser with plates brazed together to form an assembly of separat" +
	    "e channels.")]
		WATERCOOLEDBRAZEDPLATE = 4,
	
		[Description("Water-cooled condenser with cooling water circulated through one or more continuo" +
	    "us or assembled coils contained within the shell.")]
		WATERCOOLEDSHELLCOIL = 5,
	
		[Description("Water-cooled condenser with cooling water circulated through one or more tubes co" +
	    "ntained within the shell.")]
		WATERCOOLEDSHELLTUBE = 6,
	
		[Description("Water-cooled condenser consisting of one or more assemblies of two tubes, one wit" +
	    "hin the other.")]
		WATERCOOLEDTUBEINTUBE = 7,
	
		[Description("User-defined condenser type.")]
		USERDEFINED = -1,
	
		[Description("Undefined condenser type.")]
		NOTDEFINED = 0,
	
	}
}
