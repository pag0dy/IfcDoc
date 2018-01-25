// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("db0fd298-bd48-4182-bfab-0f45d1635e2c")]
	public enum IfcTransitionCurveType
	{
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-biquadratic" +
	    "parabola-x.png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransi" +
	    "tioncurvetype-biquadraticparabola-y.png\"/><br/>\r\nNOTE&nbsp; also referred to as " +
	    "Schramm curve.")]
		BIQUADRATICPARABOLA = 1,
	
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-blosscurve-" +
	    "x.png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurve" +
	    "type-blosscurve-y.png\"/><br/>\r\n")]
		BLOSSCURVE = 2,
	
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-clothoidcur" +
	    "ve-x.png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncu" +
	    "rvetype-clothoidcurve-y.png\"/><br/>\r\n\r\n")]
		CLOTHOIDCURVE = 3,
	
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-cosinecurve" +
	    "-x.png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurv" +
	    "etype-cosinecurve-y.png\"/><br/>\r\n")]
		COSINECURVE = 4,
	
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-cubicparabo" +
	    "la-x.png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncu" +
	    "rvetype-cubicparabola-y.png\"/><br/>\r\n")]
		CUBICPARABOLA = 5,
	
		[Description("X coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvetype-sinecurve-x" +
	    ".png\"/><br/>\r\nY coordinate:<br/>\r\n<img src=\"../../../figures/ifctransitioncurvet" +
	    "ype-sinecurve-y.png\"/><br/>\r\nNOTE&nbsp; also referred to as Klein curve.")]
		SINECURVE = 6,
	
	}
}
