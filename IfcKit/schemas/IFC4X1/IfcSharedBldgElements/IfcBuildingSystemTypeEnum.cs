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


namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("8a8555b2-d8ec-4f31-bb13-c7e62d7326b9")]
	public enum IfcBuildingSystemTypeEnum
	{
		[Description("System of doors, windows, and other fillings in opening in a building envelop tha" +
	    "t are designed to permit the passage of air or light.")]
		FENESTRATION = 1,
	
		[Description("System of shallow and deep foundation element that transmit forces to the support" +
	    "ing ground.")]
		FOUNDATION = 2,
	
		[Description("System of building elements that transmit forces and stiffen the construction.")]
		LOADBEARING = 3,
	
		[Description("System of building elements that provides the outer skin to protect the construct" +
	    "ion (such as the facade).")]
		OUTERSHELL = 4,
	
		[Description("System of shading elements (external or internal) that permits the limitation or " +
	    "control of impact of natural sun light.")]
		SHADING = 5,
	
		[Description("System of all transport elements in a building that enables the transport of peop" +
	    "le or goods.")]
		TRANSPORT = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
