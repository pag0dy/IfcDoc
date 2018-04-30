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


namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public enum IfcOccupantTypeEnum
	{
		[Description("Actor receiving the assignment of a property agreement from an assignor.")]
		ASSIGNEE = 1,
	
		[Description("Actor assigning a property agreement to an assignor.")]
		ASSIGNOR = 2,
	
		[Description("Actor receiving the lease of a property from a lessor.")]
		LESSEE = 3,
	
		[Description("Actor leasing a property to a lessee.")]
		LESSOR = 4,
	
		[Description("Actor participating in a property agreement on behalf of an owner, lessor or assi" +
	    "gnor.")]
		LETTINGAGENT = 5,
	
		[Description("Actor that owns a property.")]
		OWNER = 6,
	
		[Description("Actor renting the use of a property fro a period of time.")]
		TENANT = 7,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
