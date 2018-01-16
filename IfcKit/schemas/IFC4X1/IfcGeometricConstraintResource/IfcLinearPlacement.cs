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
	[Guid("0a5f39b5-87f9-40b5-bd87-15f624b84dd0")]
	public partial class IfcLinearPlacement : IfcObjectPlacement
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _PlacementRelTo;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDistanceExpression _Distance;
	
		[DataMember(Order=2)] 
		IfcOrientationExpression _Orientation;
	
		[DataMember(Order=3)] 
		IfcAxis2Placement3D _CartesianPosition;
	
	
		[Description("The curve used as the basis for positioning parameters.")]
		public IfcCurve PlacementRelTo { get { return this._PlacementRelTo; } set { this._PlacementRelTo = value;} }
	
		[Description("The position relative to the referenced curve.")]
		public IfcDistanceExpression Distance { get { return this._Distance; } set { this._Distance = value;} }
	
		[Description("Rotation of the object in the horizontal plane and vertical axis (after applying " +
	    "DistanceAlong, OffsetLateral, OffsetVertical, and OffsetLongitudinal).")]
		public IfcOrientationExpression Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
		[Description("Indicates the calculated global location and orientation in Cartesian coordinates" +
	    " as a fallback which may be used by applications that do not support linear plac" +
	    "ement.")]
		public IfcAxis2Placement3D CartesianPosition { get { return this._CartesianPosition; } set { this._CartesianPosition = value;} }
	
	
	}
	
}
