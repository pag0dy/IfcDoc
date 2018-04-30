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


namespace BuildingSmart.IFC.IfcProductExtension
{
	public enum IfcExternalSpatialElementTypeEnum
	{
		[Description("External air space around the building.")]
		EXTERNAL = 1,
	
		[Description("External volume covered by earth around the building.")]
		EXTERNAL_EARTH = 2,
	
		[Description("External volume covered with water around the building.")]
		EXTERNAL_WATER = 3,
	
		[Description("Space occupied by a neightboring building.")]
		EXTERNAL_FIRE = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
