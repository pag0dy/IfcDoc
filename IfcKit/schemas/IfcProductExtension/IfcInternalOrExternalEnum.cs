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
	public enum IfcInternalOrExternalEnum
	{
		[Description("The space boundary faces a physical or virtual element where there is an internal" +
	    " space on the other side.")]
		INTERNAL = 1,
	
		[Description("The space boundary faces a physical or virtual element where there is an external" +
	    " space on the other side.")]
		EXTERNAL = 2,
	
		[Description("The space boundary faces a physical or virtual element where there is earth (or t" +
	    "errain) on the other side.")]
		EXTERNAL_EARTH = 3,
	
		[Description("The space boundary faces a physical or virtual element where there is water (wate" +
	    "r component of terrain) on the other side.")]
		EXTERNAL_WATER = 4,
	
		[Description("The space boundary faces a physical or virtual element where there is another bui" +
	    "lding on the other side.")]
		EXTERNAL_FIRE = 5,
	
		[Description("No information available.")]
		NOTDEFINED = 0,
	
	}
}
