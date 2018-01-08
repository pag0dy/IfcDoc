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
	[Guid("bca3ce42-f3a2-4965-829c-1a3206e6adb3")]
	public partial class IfcSurfaceOfRevolution : IfcSweptSurface
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis1Placement _AxisPosition;
	
	
		[Description("A point on the axis of revolution and the direction of the axis of revolution.")]
		public IfcAxis1Placement AxisPosition { get { return this._AxisPosition; } set { this._AxisPosition = value;} }
	
	
	}
	
}
