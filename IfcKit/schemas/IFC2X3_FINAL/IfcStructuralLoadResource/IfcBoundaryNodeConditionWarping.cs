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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("7649986d-ba44-4647-bd9e-d64469541f91")]
	public partial class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcWarpingMomentMeasure? _WarpingStiffness;
	
	
		public IfcBoundaryNodeConditionWarping()
		{
		}
	
		public IfcBoundaryNodeConditionWarping(IfcLabel? __Name, IfcLinearStiffnessMeasure? __LinearStiffnessX, IfcLinearStiffnessMeasure? __LinearStiffnessY, IfcLinearStiffnessMeasure? __LinearStiffnessZ, IfcRotationalStiffnessMeasure? __RotationalStiffnessX, IfcRotationalStiffnessMeasure? __RotationalStiffnessY, IfcRotationalStiffnessMeasure? __RotationalStiffnessZ, IfcWarpingMomentMeasure? __WarpingStiffness)
			: base(__Name, __LinearStiffnessX, __LinearStiffnessY, __LinearStiffnessZ, __RotationalStiffnessX, __RotationalStiffnessY, __RotationalStiffnessZ)
		{
			this._WarpingStiffness = __WarpingStiffness;
		}
	
		[Description("Defines the warping stiffness value.")]
		public IfcWarpingMomentMeasure? WarpingStiffness { get { return this._WarpingStiffness; } set { this._WarpingStiffness = value;} }
	
	
	}
	
}
