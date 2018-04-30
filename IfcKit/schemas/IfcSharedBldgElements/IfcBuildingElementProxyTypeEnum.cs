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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public enum IfcBuildingElementProxyTypeEnum
	{
		[Description("Not used - kept for upward compatibility.")]
		COMPLEX = 1,
	
		[Description("Not used - kept for upward compatibility.")]
		ELEMENT = 2,
	
		[Description("Not used - kept for upward compatibility.")]
		PARTIAL = 3,
	
		[Description("The proxy denotes a provision for voids (an proposed opening not applied as void " +
	    "yet).")]
		PROVISIONFORVOID = 4,
	
		[Description("The proxy denotes a provision for space (e.g. the space allocated as a provision " +
	    "for mechanical equipment or furniture).")]
		PROVISIONFORSPACE = 5,
	
		[Description("User-defined building element proxy.")]
		USERDEFINED = -1,
	
		[Description("Undefined building element proxy.")]
		NOTDEFINED = 0,
	
	}
}
