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


namespace BuildingSmart.IFC.IfcGeometryResource
{
	public enum IfcTrimmingPreference
	{
		[Description("Indicates that trimming by Cartesian point is preferred.")]
		CARTESIAN = 1,
	
		[Description("Indicates the preference for the parameter value.")]
		PARAMETER = 2,
	
		[Description("Indicates that no preference is communicated.")]
		UNSPECIFIED = 3,
	
	}
}
