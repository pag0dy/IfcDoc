// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcPlumbingFireProtectionDomain
{
	[Guid("22261424-e552-4b02-8f83-74abf3d0247f")]
	public enum IfcSanitaryTerminalTypeEnum
	{
		[Description("Sanitary appliance for immersion of the human body or parts of it.")]
		BATH = 1,
	
		[Description("Waste water appliance for washing the excretory organs while sitting astride the " +
	    "bowl.")]
		BIDET = 2,
	
		[Description("A water storage unit attached to a sanitary terminal that is fitted with a device" +
	    ", operated automatically or by the user, that discharges water to cleanse a wate" +
	    "r closet (toilet) pan, urinal or slop hopper.")]
		CISTERN = 3,
	
		[Description("Installation or waste water appliance that emits a spray of water to wash the hum" +
	    "an body.")]
		SHOWER = 4,
	
		[Description("Waste water appliance for receiving, retaining or disposing of domestic, culinary" +
	    ", laboratory or industrial process liquids.")]
		SINK = 5,
	
		[Description("A sanitary terminal that provides a low pressure jet of water for a specific purp" +
	    "ose.")]
		SANITARYFOUNTAIN = 6,
	
		[Description("Soil appliance for the disposal of excrement.")]
		TOILETPAN = 7,
	
		[Description("Soil appliance that receives urine and directs it to a waste outlet.")]
		URINAL = 8,
	
		[Description("Waste water appliance for washing the upper parts of the body.")]
		WASHHANDBASIN = 9,
	
		[Description("Hinged seat that fits on the top of a water closet (WC) pan.\r\n<blockquote class=\"" +
	    "deprecated\">DEPRECATION&nbsp; Enumerator shall not be used in IFC4.</blockquote>" +
	    "")]
		WCSEAT = 10,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
