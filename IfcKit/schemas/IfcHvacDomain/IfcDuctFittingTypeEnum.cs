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
	public enum IfcDuctFittingTypeEnum
	{
		[Description("A fitting with typically two ports used to change the direction of flow between c" +
	    "onnected elements.")]
		BEND = 1,
	
		[Description("Connector fitting, typically used to join two ports together within a flow distri" +
	    "bution system (e.g., a coupling used to join two duct segments).")]
		CONNECTOR = 2,
	
		[Description("Entry fitting, typically unconnected at one port and connected to a flow distribu" +
	    "tion system at the other (e.g., an outside air duct system intake opening).")]
		ENTRY = 3,
	
		[Description("Exit fitting, typically unconnected at one port and connected to a flow distribut" +
	    "ion system at the other (e.g., an exhaust air discharge opening).")]
		EXIT = 4,
	
		[Description("A fitting with typically more than two ports used to redistribute flow among the " +
	    "ports and/or to change the direction of flow between connected elements (e.g, te" +
	    "e, cross, wye, etc.).")]
		JUNCTION = 5,
	
		[Description("A fitting with typically two ports used to obstruct or restrict flow between the " +
	    "connected elements (e.g., screen, perforated plate, etc.).")]
		OBSTRUCTION = 6,
	
		[Description("A fitting with typically two ports having different shapes or sizes. Can also be " +
	    "used to change the direction of flow between connected elements.")]
		TRANSITION = 7,
	
		[Description("User-defined fitting.")]
		USERDEFINED = -1,
	
		[Description("Undefined fitting.")]
		NOTDEFINED = 0,
	
	}
}
