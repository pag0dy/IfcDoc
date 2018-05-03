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


namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public enum IfcTendonAnchorTypeEnum
	{
		[Description("The anchor is an intermediate device which connects two tendons.")]
		COUPLER = 1,
	
		[Description("The anchor fixes the end of a tendon.")]
		FIXED_END = 2,
	
		[Description("The anchor is used or can be used to prestress the tendon.")]
		TENSIONING_END = 3,
	
		[Description("The type of tendon anchor is user defined.")]
		USERDEFINED = -1,
	
		[Description("The type of tendon anchor is not defined.")]
		NOTDEFINED = 0,
	
	}
}
