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


namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	public enum IfcControllerTypeEnum
	{
		FLOATING = 1,
	
		PROPORTIONAL = 2,
	
		PROPORTIONALINTEGRAL = 3,
	
		PROPORTIONALINTEGRALDERIVATIVE = 4,
	
		TIMEDTWOPOSITION = 5,
	
		TWOPOSITION = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
