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
		[XmlElement]
		[Description("Placement of the object coordinate system defined by the intersection of two grid axes.  ")]
		[Required()]
		public IfcVirtualGridIntersection PlacementLocation { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to either an explicit direction, or a second grid axis intersection, which defines the orientation of the grid placement.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The select of an explict direction has been added.</blockquote>")]
		public IfcGridPlacementDirectionSelect PlacementRefDirection { get; set; }
	
	
		public IfcGridPlacement(IfcVirtualGridIntersection __PlacementLocation, IfcGridPlacementDirectionSelect __PlacementRefDirection)
		{
			this.PlacementLocation = __PlacementLocation;
			this.PlacementRefDirection = __PlacementRefDirection;
		}
	
	
	}
	
}
