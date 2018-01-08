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
	[Guid("f2e1a6b7-3d7a-4c60-a04a-924b62253b52")]
	public partial class IfcGridPlacement : IfcObjectPlacement
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcVirtualGridIntersection")]
		[Required()]
		IfcVirtualGridIntersection _PlacementLocation;
	
		[DataMember(Order=1)] 
		IfcGridPlacementDirectionSelect _PlacementRefDirection;
	
	
		[Description("<EPM-HTML>\r\nPlacement of the object coordinate system defined by the intersection" +
	    " of two grid axes.\r\n</EPM-HTML>\r\n")]
		public IfcVirtualGridIntersection PlacementLocation { get { return this._PlacementLocation; } set { this._PlacementLocation = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to either an explicit direction, or a second grid axis intersection, which defines the orientation of the grid placement.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE  The select of an explict direction has been added.</blockquote>
	</EPM-HTML>")]
		public IfcGridPlacementDirectionSelect PlacementRefDirection { get { return this._PlacementRefDirection; } set { this._PlacementRefDirection = value;} }
	
	
	}
	
}
