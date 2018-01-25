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
	[Guid("f2867726-186b-4245-b97b-1107c4d81252")]
	public abstract partial class IfcSweptSurface : IfcSurface
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProfileDef _SweptCurve;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcAxis2Placement3D _Position;
	
	
		[Description("The curve to be swept in defining the surface. The curve is defined as a profile " +
	    "within the position coordinate system.")]
		public IfcProfileDef SweptCurve { get { return this._SweptCurve; } set { this._SweptCurve = value;} }
	
		[Description("Position coordinate system for the placement of the profile within the xy plane o" +
	    "f the axis placement.")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
