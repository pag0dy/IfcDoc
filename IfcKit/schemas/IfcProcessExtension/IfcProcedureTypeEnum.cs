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


namespace BuildingSmart.IFC.IfcProcessExtension
{
	public enum IfcProcedureTypeEnum
	{
		[Description("A caution that should be taken note of as a procedure or when carrying out a proc" +
	    "edure.")]
		ADVICE_CAUTION = 1,
	
		[Description("Additional information or advice that should be taken note of as a procedure or w" +
	    "hen carrying out a procedure.")]
		ADVICE_NOTE = 2,
	
		[Description("A warning of potential danger that should be taken note of as a procedure or when" +
	    " carrying out a procedure.")]
		ADVICE_WARNING = 3,
	
		[Description("A procedure undertaken to calibrate an artifact.")]
		CALIBRATION = 4,
	
		DIAGNOSTIC = 5,
	
		[Description("A procedure undertaken to shutdown the operation an artifact.")]
		SHUTDOWN = 6,
	
		[Description("A procedure undertaken to start up the operation an artifact.")]
		STARTUP = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
