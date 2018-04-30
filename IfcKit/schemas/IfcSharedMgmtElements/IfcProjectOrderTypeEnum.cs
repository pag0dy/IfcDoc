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


namespace BuildingSmart.IFC.IfcSharedMgmtElements
{
	public enum IfcProjectOrderTypeEnum
	{
		[Description("An instruction to make a change to a product or work being undertaken and a descr" +
	    "iption of the work that is to be performed.")]
		CHANGEORDER = 1,
	
		[Description("An instruction to carry out maintenance work and a description of the work that i" +
	    "s to be performed.")]
		MAINTENANCEWORKORDER = 2,
	
		[Description("An instruction to move persons and artefacts and a description of the move locati" +
	    "ons, objects to be moved, etc.")]
		MOVEORDER = 3,
	
		[Description("An instruction to purchase goods and/or services and a description of the goods a" +
	    "nd/or services to be purchased that is to be performed.")]
		PURCHASEORDER = 4,
	
		[Description("A general instruction to carry out work and a description of the work to be done." +
	    " Note the difference between a work order generally and a maintenance work order" +
	    ".")]
		WORKORDER = 5,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
