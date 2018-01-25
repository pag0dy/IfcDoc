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
	[Guid("e06621e1-1a92-4dd8-8a42-1bba3e74e221")]
	public abstract partial class IfcSweptSurface : IfcSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcProfileDef _SweptCurve;
	
		[DataMember(Order=1)] 
		[XmlElement]
		IfcAxis2Placement3D _Position;
	
	
		[Description("The curve to be swept in defining the surface. The curve is defined as a profile " +
	    "within the position coordinate system.")]
		public IfcProfileDef SweptCurve { get { return this._SweptCurve; } set { this._SweptCurve = value;} }
	
		[Description(@"Position coordinate system for the swept surface, provided by a profile definition within the XY plane of the <em>Position</em> coordinates. If not provided, the position of the profile being swept is determined by the object coordinate system. In this case, the swept surface is not repositioned.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been changed to OPTIONAL with upward compatibility for file-based exchange.</blockquote> ")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
