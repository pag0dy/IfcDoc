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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("a9e20aad-c981-4f18-8810-c93f4aa51bc3")]
	public enum IfcMedicalDeviceTypeEnum
	{
		[Description("Device that provides purified medical air, composed of an air compressor and air " +
	    "treatment line.")]
		AIRSTATION = 1,
	
		[Description("Device that feeds air to an oxygen generator, composed of an air compressor, air " +
	    "treatment line, and an air receiver.")]
		FEEDAIRUNIT = 2,
	
		[Description("Device that generates oxygen from air.")]
		OXYGENGENERATOR = 3,
	
		[Description("Device that combines a feed air unit, oxygen generator, and backup oxygen cylinde" +
	    "rs.")]
		OXYGENPLANT = 4,
	
		[Description("Device that provides suction, composed of a vacuum pump and bacterial filtration " +
	    "line.")]
		VACUUMSTATION = 5,
	
		[Description("User-defined medical device type.")]
		USERDEFINED = -1,
	
		[Description("Undefined medical device type.")]
		NOTDEFINED = 0,
	
	}
}
