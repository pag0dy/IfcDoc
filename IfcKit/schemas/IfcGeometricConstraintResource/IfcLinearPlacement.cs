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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcLinearPlacement : IfcObjectPlacement
	{
		[DataMember(Order = 0)] 
		[Description("The curve used as the basis for positioning parameters.")]
		[Required()]
		public IfcCurve PlacementRelTo { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The position relative to the referenced curve.")]
		[Required()]
		public IfcDistanceExpression Distance { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Rotation of the object in the horizontal plane and vertical axis (after applying DistanceAlong, OffsetLateral, OffsetVertical, and OffsetLongitudinal).")]
		public IfcOrientationExpression Orientation { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Indicates the calculated global location and orientation in Cartesian coordinates as a fallback which may be used by applications that do not support linear placement.")]
		public IfcAxis2Placement3D CartesianPosition { get; set; }
	
	
		public IfcLinearPlacement(IfcCurve __PlacementRelTo, IfcDistanceExpression __Distance, IfcOrientationExpression __Orientation, IfcAxis2Placement3D __CartesianPosition)
		{
			this.PlacementRelTo = __PlacementRelTo;
			this.Distance = __Distance;
			this.Orientation = __Orientation;
			this.CartesianPosition = __CartesianPosition;
		}
	
	
	}
	
}
