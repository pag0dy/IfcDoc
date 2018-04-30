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

using BuildingSmart.IFC.IfcKernel;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcGridPlacement : IfcObjectPlacement
	{
		[DataMember(Order = 0)] 
		[Description("A constraint on one or both ends of the path for an ExtrudedSolid.  ")]
		[Required()]
		public IfcVirtualGridIntersection PlacementLocation { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to a second grid axis intersection, which defines the orientation of the grid placement.")]
		public IfcVirtualGridIntersection PlacementRefDirection { get; set; }
	
	
		public IfcGridPlacement(IfcVirtualGridIntersection __PlacementLocation, IfcVirtualGridIntersection __PlacementRefDirection)
		{
			this.PlacementLocation = __PlacementLocation;
			this.PlacementRefDirection = __PlacementRefDirection;
		}
	
	
	}
	
}
