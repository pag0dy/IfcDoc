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
	public enum IfcElectricDistributionBoardTypeEnum
	{
		[Description("A distribution point on the incoming electrical supply, typically in domestic pre" +
	    "mises, at which protective devices are located.")]
		CONSUMERUNIT = 1,
	
		[Description("A distribution point at which connections are made for distribution of electrical" +
	    " circuits usually through protective devices.")]
		DISTRIBUTIONBOARD = 2,
	
		[Description("A distribution point at which starting and control devices for major plant items " +
	    "are located.")]
		MOTORCONTROLCENTRE = 3,
	
		[Description("A distribution point at which switching devices are located.")]
		SWITCHBOARD = 4,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
