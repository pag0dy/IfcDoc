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
	[Guid("70a1a18c-674c-4d22-a114-cac92992372f")]
	public abstract partial class IfcSweptAreaSolid : IfcSolidModel
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProfileDef _SweptArea;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcAxis2Placement3D _Position;
	
	
		[Description("The surface defining the area to be swept. It is given as a profile definition wi" +
	    "thin the xy plane of the position coordinate system.")]
		public IfcProfileDef SweptArea { get { return this._SweptArea; } set { this._SweptArea = value;} }
	
		[Description("Position coordinate system for the swept area.")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
