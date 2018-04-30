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


namespace BuildingSmart.IFC.IfcProfileResource
{
	public enum IfcProfileTypeEnum
	{
		[Description(@"The resulting geometric item is of type curve and closed (with the only exception of the curve created by the <em>IfcArbitraryOpenProfileDef</em> which resolves into an open curve). The resulting geometry after applying a sweeping operation is a swept surface. This can be used to define shapes with thin sheets, such as ducts, where the thickness is not appropriate for geometric representation.")]
		CURVE = 1,
	
		[Description("The resulting geometric item is of type surface. The resulting geometry after app" +
	    "lying a sweeping operation is a swept solid with defined volume.")]
		AREA = 2,
	
	}
}
