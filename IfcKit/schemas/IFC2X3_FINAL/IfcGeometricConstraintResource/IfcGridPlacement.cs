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
	[Guid("ec46e52c-0df8-4d82-b6fc-beb260d50283")]
	public partial class IfcGridPlacement : IfcObjectPlacement
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcVirtualGridIntersection _PlacementLocation;
	
		[DataMember(Order=1)] 
		IfcVirtualGridIntersection _PlacementRefDirection;
	
	
		[Description("A constraint on one or both ends of the path for an ExtrudedSolid.\r\n")]
		public IfcVirtualGridIntersection PlacementLocation { get { return this._PlacementLocation; } set { this._PlacementLocation = value;} }
	
		[Description("Reference to a second grid axis intersection, which defines the orientation of th" +
	    "e grid placement.")]
		public IfcVirtualGridIntersection PlacementRefDirection { get { return this._PlacementRefDirection; } set { this._PlacementRefDirection = value;} }
	
	
	}
	
}
