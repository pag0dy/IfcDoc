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


namespace BuildingSmart.IFC.IfcRepresentationResource
{
	public enum IfcGlobalOrLocalEnum
	{
		[Description("The global project coordinate system is used.")]
		GLOBAL_COORDS = 1,
	
		[Description("The local object coordinate system is used.")]
		LOCAL_COORDS = 2,
	
	}
}
