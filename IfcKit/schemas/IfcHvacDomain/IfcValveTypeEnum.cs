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
	public enum IfcValveTypeEnum
	{
		[Description("Valve used to release air from a pipe or fitting.")]
		AIRRELEASE = 1,
	
		[Description("Valve that opens to admit air if the pressure falls below atmospheric pressure.")]
		ANTIVACUUM = 2,
	
		[Description("Valve that enables flow to be switched between pipelines (3 or 4 port).")]
		CHANGEOVER = 3,
	
		[Description("Valve that permits water to flow in one direction only and is enclosed when there" +
	    " is no flow (2 port).")]
		CHECK = 4,
	
		[Description("Valve used to facilitate commissioning of a system (2 port).")]
		COMMISSIONING = 5,
	
		[Description("Valve that enables flow to be diverted from one branch of a pipeline to another (" +
	    "3 port).")]
		DIVERTING = 6,
	
		[Description("A valve used to remove fluid from a piping system.")]
		DRAWOFFCOCK = 7,
	
		[Description("An assembly that incorporates two valves used to prevent backflow.")]
		DOUBLECHECK = 8,
	
		[Description("Valve used to facilitate regulation of fluid flow in a system.")]
		DOUBLEREGULATING = 9,
	
		[Description("Faucet valve typically used as a flow discharge.")]
		FAUCET = 10,
	
		[Description("Valve that flushes a predetermined quantity of water to cleanse a toilet, urinal," +
	    " etc.")]
		FLUSHING = 11,
	
		[Description("Valve that is used for controlling the flow of gas.")]
		GASCOCK = 12,
	
		[Description("Gas tap typically used for venting or discharging gas from a system.")]
		GASTAP = 13,
	
		[Description("Valve that closes off flow in a pipeline.")]
		ISOLATING = 14,
	
		[Description("Valve that enables flow from two branches of a pipeline to be mixed together (3 p" +
	    "ort).")]
		MIXING = 15,
	
		[Description("Valve that reduces the pressure of a fluid immediately downstream of its position" +
	    " in a pipeline to a preselected value or by a predetermined ratio.")]
		PRESSUREREDUCING = 16,
	
		[Description("Spring or weight loaded valve that automatically discharges to a safe place fluid" +
	    " that has built up to excessive pressure in pipes or fittings.")]
		PRESSURERELIEF = 17,
	
		[Description("Valve used to facilitate regulation of fluid flow in a system.")]
		REGULATING = 18,
	
		[Description("Valve that closes under the action of a safety mechanism such as a drop weight, s" +
	    "olenoid etc.")]
		SAFETYCUTOFF = 19,
	
		[Description("Valve that restricts flow of steam while allowing condensate to pass through.")]
		STEAMTRAP = 20,
	
		[Description("An isolating valve used on a domestic water service.")]
		STOPCOCK = 21,
	
		[Description("User-defined valve type.")]
		USERDEFINED = -1,
	
		[Description("Undefined valve type.")]
		NOTDEFINED = 0,
	
	}
}
