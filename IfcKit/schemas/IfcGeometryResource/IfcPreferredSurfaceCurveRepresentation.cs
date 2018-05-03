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
	public enum IfcPreferredSurfaceCurveRepresentation
	{
		[Description("The curve in three-dimensional space is preferred")]
		CURVE3D = 1,
	
		[Description("The first pcurve is preferred")]
		PCURVE_S1 = 2,
	
		[Description("The second pcurve is preferred")]
		PCURVE_S2 = 3,
	
	}
}
