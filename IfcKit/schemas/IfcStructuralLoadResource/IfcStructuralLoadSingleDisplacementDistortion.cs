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
	public partial class IfcStructuralLoadSingleDisplacementDistortion : IfcStructuralLoadSingleDisplacement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The distortion curvature (warping, i.e. a cross-sectional deplanation) given to the displacement load.")]
		public IfcCurvatureMeasure? Distortion { get; set; }
	
	
		public IfcStructuralLoadSingleDisplacementDistortion(IfcLabel? __Name, IfcLengthMeasure? __DisplacementX, IfcLengthMeasure? __DisplacementY, IfcLengthMeasure? __DisplacementZ, IfcPlaneAngleMeasure? __RotationalDisplacementRX, IfcPlaneAngleMeasure? __RotationalDisplacementRY, IfcPlaneAngleMeasure? __RotationalDisplacementRZ, IfcCurvatureMeasure? __Distortion)
			: base(__Name, __DisplacementX, __DisplacementY, __DisplacementZ, __RotationalDisplacementRX, __RotationalDisplacementRY, __RotationalDisplacementRZ)
		{
			this.Distortion = __Distortion;
		}
	
	
	}
	
}
