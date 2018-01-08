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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("d4c2b099-4604-4491-b948-5445dd2ff41c")]
	public partial class IfcSweptDiskSolidPolygonal : IfcSweptDiskSolid
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _FilletRadius;
	
	
		[Description("The fillet that is equally applied to all transitions between the segments of the" +
	    " <em>IfcPolyline</em>, providing the geometric representation for <em>the Direct" +
	    "rix</em>. If omited, no fillet is applied to the segments. ")]
		public IfcPositiveLengthMeasure? FilletRadius { get { return this._FilletRadius; } set { this._FilletRadius = value;} }
	
	
	}
	
}
