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
	public partial class IfcStructuralSteelProfileProperties : IfcStructuralProfileProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Area of the profile for calculating the shear stress for a shear force parallel to the profiles Z-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearAreaZ { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Area of the profile for calculating the shear stress for a shear force parallel to the profiles Y-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearAreaY { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Ratio of plastic versus elastic bending moment capacity (about y-axis) of the profile.")]
		public IfcPositiveRatioMeasure? PlasticShapeFactorY { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Ratio of plastic versus elastic bending moment capacity (about z-axis) of the profile.")]
		public IfcPositiveRatioMeasure? PlasticShapeFactorZ { get; set; }
	
	
		public IfcStructuralSteelProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea, IfcMomentOfInertiaMeasure? __TorsionalConstantX, IfcMomentOfInertiaMeasure? __MomentOfInertiaYZ, IfcMomentOfInertiaMeasure? __MomentOfInertiaY, IfcMomentOfInertiaMeasure? __MomentOfInertiaZ, IfcWarpingConstantMeasure? __WarpingConstant, IfcLengthMeasure? __ShearCentreZ, IfcLengthMeasure? __ShearCentreY, IfcAreaMeasure? __ShearDeformationAreaZ, IfcAreaMeasure? __ShearDeformationAreaY, IfcSectionModulusMeasure? __MaximumSectionModulusY, IfcSectionModulusMeasure? __MinimumSectionModulusY, IfcSectionModulusMeasure? __MaximumSectionModulusZ, IfcSectionModulusMeasure? __MinimumSectionModulusZ, IfcSectionModulusMeasure? __TorsionalSectionModulus, IfcLengthMeasure? __CentreOfGravityInX, IfcLengthMeasure? __CentreOfGravityInY, IfcAreaMeasure? __ShearAreaZ, IfcAreaMeasure? __ShearAreaY, IfcPositiveRatioMeasure? __PlasticShapeFactorY, IfcPositiveRatioMeasure? __PlasticShapeFactorZ)
			: base(__ProfileName, __ProfileDefinition, __PhysicalWeight, __Perimeter, __MinimumPlateThickness, __MaximumPlateThickness, __CrossSectionArea, __TorsionalConstantX, __MomentOfInertiaYZ, __MomentOfInertiaY, __MomentOfInertiaZ, __WarpingConstant, __ShearCentreZ, __ShearCentreY, __ShearDeformationAreaZ, __ShearDeformationAreaY, __MaximumSectionModulusY, __MinimumSectionModulusY, __MaximumSectionModulusZ, __MinimumSectionModulusZ, __TorsionalSectionModulus, __CentreOfGravityInX, __CentreOfGravityInY)
		{
			this.ShearAreaZ = __ShearAreaZ;
			this.ShearAreaY = __ShearAreaY;
			this.PlasticShapeFactorY = __PlasticShapeFactorY;
			this.PlasticShapeFactorZ = __PlasticShapeFactorZ;
		}
	
	
	}
	
}
