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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	public partial class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the warping stiffness value.")]
		public IfcWarpingMomentMeasure? WarpingStiffness { get; set; }
	
	
		public IfcBoundaryNodeConditionWarping(IfcLabel? __Name, IfcLinearStiffnessMeasure? __LinearStiffnessX, IfcLinearStiffnessMeasure? __LinearStiffnessY, IfcLinearStiffnessMeasure? __LinearStiffnessZ, IfcRotationalStiffnessMeasure? __RotationalStiffnessX, IfcRotationalStiffnessMeasure? __RotationalStiffnessY, IfcRotationalStiffnessMeasure? __RotationalStiffnessZ, IfcWarpingMomentMeasure? __WarpingStiffness)
			: base(__Name, __LinearStiffnessX, __LinearStiffnessY, __LinearStiffnessZ, __RotationalStiffnessX, __RotationalStiffnessY, __RotationalStiffnessZ)
		{
			this.WarpingStiffness = __WarpingStiffness;
		}
	
	
	}
	
}
