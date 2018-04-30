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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	public partial class IfcStructuralProfileProperties : IfcGeneralProfileProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Torsional constant about X-axis of profile coordinate system. Usually measured in [mm4].")]
		public IfcMomentOfInertiaMeasure? TorsionalConstantX { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Moment of inertia about Y and Z-axes of profile coordinate system. Usually measured in [mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaYZ { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Moment of inertia about Y-axis of profile coordinate system. Usually measured in [mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaY { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Moment of inertia about Z-axis of profile coordinate system. Usually measured in [mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaZ { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Warping constant of the profile for torsional action. Usually measured in [mm6].")]
		public IfcWarpingConstantMeasure? WarpingConstant { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Location of the profile's shear centre in the structural Z direction. Mapped on IFC profile coordinate system it is the offset in the direction of the negative Y axis. The offset is relative to the center of gravity.<br>  The <i>ShearCentreZ</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.  </EPM-HTML>")]
		public IfcLengthMeasure? ShearCentreZ { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Location of the profile's shear centre in the structural Y direction. Mapped on IFC profile coordinate system it is the offset in the direction of the negative X axis. The offset is relative to the center of gravity.<br>  The <i>ShearCentreY</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.  </EPM-HTML>")]
		public IfcLengthMeasure? ShearCentreY { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Area of the profile for calculating the shear deformation for a shear force parallel to the profiles Z-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearDeformationAreaZ { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Area of the profile for calculating the shear deformation for a shear force parallel to the profiles Y-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearDeformationAreaY { get; set; }
	
		[DataMember(Order = 9)] 
		[XmlAttribute]
		[Description("Bending resistance about Y-axis of profile coordinate system at maximum Z-ordinate. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MaximumSectionModulusY { get; set; }
	
		[DataMember(Order = 10)] 
		[XmlAttribute]
		[Description("Bending resistance about Y-axis of profile coordinate system at minimum Z-ordinate. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MinimumSectionModulusY { get; set; }
	
		[DataMember(Order = 11)] 
		[XmlAttribute]
		[Description("Bending resistance about Z-axis of profile coordinate system at maximum Y-ordinate. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MaximumSectionModulusZ { get; set; }
	
		[DataMember(Order = 12)] 
		[XmlAttribute]
		[Description("Bending resistance about Z-axis of profile coordinate system at minimum Y-ordinate. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MinimumSectionModulusZ { get; set; }
	
		[DataMember(Order = 13)] 
		[XmlAttribute]
		[Description("Torsional resistance (about the profiles X-axis). Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? TorsionalSectionModulus { get; set; }
	
		[DataMember(Order = 14)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Location of the profile's centre of gravity in the geometric X direction. The <i>CentreOfGravityInX</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.    <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute <i>CentreOfGravityInX</i> is a new attribute.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcLengthMeasure? CentreOfGravityInX { get; set; }
	
		[DataMember(Order = 15)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Location of the profile's centre of gravity in the geometric Y direction. The <i>CentreOfGravityInY</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.    <blockquote> <small><font color=\"#ff0000\">  IFC2x Edition 3 CHANGE&nbsp; The attribute <i>CentreOfGravityInY</i> is a new attribute.    </font></small></blockquote>  </EPM-HTML>")]
		public IfcLengthMeasure? CentreOfGravityInY { get; set; }
	
	
		public IfcStructuralProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea, IfcMomentOfInertiaMeasure? __TorsionalConstantX, IfcMomentOfInertiaMeasure? __MomentOfInertiaYZ, IfcMomentOfInertiaMeasure? __MomentOfInertiaY, IfcMomentOfInertiaMeasure? __MomentOfInertiaZ, IfcWarpingConstantMeasure? __WarpingConstant, IfcLengthMeasure? __ShearCentreZ, IfcLengthMeasure? __ShearCentreY, IfcAreaMeasure? __ShearDeformationAreaZ, IfcAreaMeasure? __ShearDeformationAreaY, IfcSectionModulusMeasure? __MaximumSectionModulusY, IfcSectionModulusMeasure? __MinimumSectionModulusY, IfcSectionModulusMeasure? __MaximumSectionModulusZ, IfcSectionModulusMeasure? __MinimumSectionModulusZ, IfcSectionModulusMeasure? __TorsionalSectionModulus, IfcLengthMeasure? __CentreOfGravityInX, IfcLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileName, __ProfileDefinition, __PhysicalWeight, __Perimeter, __MinimumPlateThickness, __MaximumPlateThickness, __CrossSectionArea)
		{
			this.TorsionalConstantX = __TorsionalConstantX;
			this.MomentOfInertiaYZ = __MomentOfInertiaYZ;
			this.MomentOfInertiaY = __MomentOfInertiaY;
			this.MomentOfInertiaZ = __MomentOfInertiaZ;
			this.WarpingConstant = __WarpingConstant;
			this.ShearCentreZ = __ShearCentreZ;
			this.ShearCentreY = __ShearCentreY;
			this.ShearDeformationAreaZ = __ShearDeformationAreaZ;
			this.ShearDeformationAreaY = __ShearDeformationAreaY;
			this.MaximumSectionModulusY = __MaximumSectionModulusY;
			this.MinimumSectionModulusY = __MinimumSectionModulusY;
			this.MaximumSectionModulusZ = __MaximumSectionModulusZ;
			this.MinimumSectionModulusZ = __MinimumSectionModulusZ;
			this.TorsionalSectionModulus = __TorsionalSectionModulus;
			this.CentreOfGravityInX = __CentreOfGravityInX;
			this.CentreOfGravityInY = __CentreOfGravityInY;
		}
	
	
	}
	
}
