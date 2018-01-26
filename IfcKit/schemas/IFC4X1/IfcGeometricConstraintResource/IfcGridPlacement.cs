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

using BuildingSmart.IFC.IfcKernel;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("f2e1a6b7-3d7a-4c60-a04a-924b62253b52")]
	public partial class IfcGridPlacement : IfcObjectPlacement
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcVirtualGridIntersection _PlacementLocation;
	
		[DataMember(Order=1)] 
		IfcGridPlacementDirectionSelect _PlacementRefDirection;
	
	
		public IfcGridPlacement()
		{
		}
	
		public IfcGridPlacement(IfcVirtualGridIntersection __PlacementLocation, IfcGridPlacementDirectionSelect __PlacementRefDirection)
		{
			this._PlacementLocation = __PlacementLocation;
			this._PlacementRefDirection = __PlacementRefDirection;
		}
	
		[Description("Placement of the object coordinate system defined by the intersection of two grid" +
	    " axes.\r\n")]
		public IfcVirtualGridIntersection PlacementLocation { get { return this._PlacementLocation; } set { this._PlacementLocation = value;} }
	
		[Description("Reference to either an explicit direction, or a second grid axis intersection, wh" +
	    "ich defines the orientation of the grid placement.\r\n<blockquote class=\"change-if" +
	    "c2x4\">IFC4 CHANGE  The select of an explict direction has been added.</blockquot" +
	    "e>")]
		public IfcGridPlacementDirectionSelect PlacementRefDirection { get { return this._PlacementRefDirection; } set { this._PlacementRefDirection = value;} }
	
	
	}
	
}
