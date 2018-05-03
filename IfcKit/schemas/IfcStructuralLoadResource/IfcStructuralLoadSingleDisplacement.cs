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
	public partial class IfcStructuralLoadSingleDisplacement : IfcStructuralLoadStatic
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Displacement in x-direction.")]
		public IfcLengthMeasure? DisplacementX { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Displacement in y-direction.")]
		public IfcLengthMeasure? DisplacementY { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Displacement in z-direction.")]
		public IfcLengthMeasure? DisplacementZ { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Rotation about the x-axis.")]
		public IfcPlaneAngleMeasure? RotationalDisplacementRX { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Rotation about the y-axis.")]
		public IfcPlaneAngleMeasure? RotationalDisplacementRY { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Rotation about the z-axis.")]
		public IfcPlaneAngleMeasure? RotationalDisplacementRZ { get; set; }
	
	
		public IfcStructuralLoadSingleDisplacement(IfcLabel? __Name, IfcLengthMeasure? __DisplacementX, IfcLengthMeasure? __DisplacementY, IfcLengthMeasure? __DisplacementZ, IfcPlaneAngleMeasure? __RotationalDisplacementRX, IfcPlaneAngleMeasure? __RotationalDisplacementRY, IfcPlaneAngleMeasure? __RotationalDisplacementRZ)
			: base(__Name)
		{
			this.DisplacementX = __DisplacementX;
			this.DisplacementY = __DisplacementY;
			this.DisplacementZ = __DisplacementZ;
			this.RotationalDisplacementRX = __RotationalDisplacementRX;
			this.RotationalDisplacementRY = __RotationalDisplacementRY;
			this.RotationalDisplacementRZ = __RotationalDisplacementRZ;
		}
	
	
	}
	
}
