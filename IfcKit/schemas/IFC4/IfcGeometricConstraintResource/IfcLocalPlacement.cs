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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("ca6001c7-db80-4168-bd0d-32259a34d423")]
	public partial class IfcLocalPlacement : IfcObjectPlacement
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcObjectPlacement")]
		IfcObjectPlacement _PlacementRelTo;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcAxis2Placement _RelativePlacement;
	
	
		[Description("Reference to Object that provides the relative placement by its local coordinate " +
	    "system. If it is omitted, then the local placement is given to the WCS, establis" +
	    "hed by the geometric representation context.\r\n")]
		public IfcObjectPlacement PlacementRelTo { get { return this._PlacementRelTo; } set { this._PlacementRelTo = value;} }
	
		[Description("Geometric placement that defines the transformation from the related coordinate s" +
	    "ystem into the relating. The placement can be either 2D or 3D, depending on the " +
	    "dimension count of the coordinate system.")]
		public IfcAxis2Placement RelativePlacement { get { return this._RelativePlacement; } set { this._RelativePlacement = value;} }
	
	
	}
	
}
