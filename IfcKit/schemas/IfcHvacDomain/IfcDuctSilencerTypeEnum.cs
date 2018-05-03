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
	public enum IfcDuctSilencerTypeEnum
	{
		[Description("Flat-oval shaped duct silencer type.")]
		FLATOVAL = 1,
	
		[Description("Rectangular shaped duct silencer type.")]
		RECTANGULAR = 2,
	
		[Description("Round duct silencer type.")]
		ROUND = 3,
	
		[Description("User-defined duct silencer type.")]
		USERDEFINED = -1,
	
		[Description("Undefined duct silencer type.")]
		NOTDEFINED = 0,
	
	}
}
