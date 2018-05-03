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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcCableCarrierSegmentTypeEnum
	{
		[Description("An open carrier segment on which cables are carried on a ladder structure.")]
		CABLELADDERSEGMENT = 1,
	
		[Description("A (typically) open carrier segment onto which cables are laid.")]
		CABLETRAYSEGMENT = 2,
	
		[Description("An enclosed carrier segment with one or more compartments into which cables are p" +
	    "laced.")]
		CABLETRUNKINGSEGMENT = 3,
	
		[Description("An enclosed tubular carrier segment through which cables are pulled.")]
		CONDUITSEGMENT = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
