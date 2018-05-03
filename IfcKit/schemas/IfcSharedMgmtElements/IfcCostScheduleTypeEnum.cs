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
	public enum IfcCostScheduleTypeEnum
	{
		[Description("An allocation of money for a particular purpose.")]
		BUDGET = 1,
	
		[Description("An assessment of the amount of money needing to be expended for a defined purpose" +
	    " based on incomplete information about the goods and services required for a con" +
	    "struction or installation.")]
		COSTPLAN = 2,
	
		[Description("An assessment of the amount of money needing to be expended for a defined purpose" +
	    " based on actual information about the goods and services required for a constru" +
	    "ction or installation.")]
		ESTIMATE = 3,
	
		[Description("An offer to provide goods and services.")]
		TENDER = 4,
	
		[Description("A complete listing of all work items forming construction or installation works i" +
	    "n which costs have been allocated to work items.")]
		PRICEDBILLOFQUANTITIES = 5,
	
		[Description("A complete listing of all work items forming construction or installation works i" +
	    "n which costs have not yet been allocated to work items.")]
		UNPRICEDBILLOFQUANTITIES = 6,
	
		[Description("A listing of each type of goods forming construction or installation works with t" +
	    "he cost of purchase, construction/installation, overheads and profit assigned so" +
	    " that additional items of that type can be costed.")]
		SCHEDULEOFRATES = 7,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
