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
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcProfilePropertyResource
{
	[Guid("08eadbb5-12bc-46bb-a1dc-e79ab27d206c")]
	public partial class IfcStructuralSteelProfileProperties : IfcStructuralProfileProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcAreaMeasure? _ShearAreaZ;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcAreaMeasure? _ShearAreaY;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _PlasticShapeFactorY;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveRatioMeasure? _PlasticShapeFactorZ;
	
	
		public IfcStructuralSteelProfileProperties()
		{
		}
	
		public IfcStructuralSteelProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea, IfcMomentOfInertiaMeasure? __TorsionalConstantX, IfcMomentOfInertiaMeasure? __MomentOfInertiaYZ, IfcMomentOfInertiaMeasure? __MomentOfInertiaY, IfcMomentOfInertiaMeasure? __MomentOfInertiaZ, IfcWarpingConstantMeasure? __WarpingConstant, IfcLengthMeasure? __ShearCentreZ, IfcLengthMeasure? __ShearCentreY, IfcAreaMeasure? __ShearDeformationAreaZ, IfcAreaMeasure? __ShearDeformationAreaY, IfcSectionModulusMeasure? __MaximumSectionModulusY, IfcSectionModulusMeasure? __MinimumSectionModulusY, IfcSectionModulusMeasure? __MaximumSectionModulusZ, IfcSectionModulusMeasure? __MinimumSectionModulusZ, IfcSectionModulusMeasure? __TorsionalSectionModulus, IfcLengthMeasure? __CentreOfGravityInX, IfcLengthMeasure? __CentreOfGravityInY, IfcAreaMeasure? __ShearAreaZ, IfcAreaMeasure? __ShearAreaY, IfcPositiveRatioMeasure? __PlasticShapeFactorY, IfcPositiveRatioMeasure? __PlasticShapeFactorZ)
			: base(__ProfileName, __ProfileDefinition, __PhysicalWeight, __Perimeter, __MinimumPlateThickness, __MaximumPlateThickness, __CrossSectionArea, __TorsionalConstantX, __MomentOfInertiaYZ, __MomentOfInertiaY, __MomentOfInertiaZ, __WarpingConstant, __ShearCentreZ, __ShearCentreY, __ShearDeformationAreaZ, __ShearDeformationAreaY, __MaximumSectionModulusY, __MinimumSectionModulusY, __MaximumSectionModulusZ, __MinimumSectionModulusZ, __TorsionalSectionModulus, __CentreOfGravityInX, __CentreOfGravityInY)
		{
			this._ShearAreaZ = __ShearAreaZ;
			this._ShearAreaY = __ShearAreaY;
			this._PlasticShapeFactorY = __PlasticShapeFactorY;
			this._PlasticShapeFactorZ = __PlasticShapeFactorZ;
		}
	
		[Description("Area of the profile for calculating the shear stress for a shear force parallel t" +
	    "o the profiles Z-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearAreaZ { get { return this._ShearAreaZ; } set { this._ShearAreaZ = value;} }
	
		[Description("Area of the profile for calculating the shear stress for a shear force parallel t" +
	    "o the profiles Y-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearAreaY { get { return this._ShearAreaY; } set { this._ShearAreaY = value;} }
	
		[Description("Ratio of plastic versus elastic bending moment capacity (about y-axis) of the pro" +
	    "file.")]
		public IfcPositiveRatioMeasure? PlasticShapeFactorY { get { return this._PlasticShapeFactorY; } set { this._PlasticShapeFactorY = value;} }
	
		[Description("Ratio of plastic versus elastic bending moment capacity (about z-axis) of the pro" +
	    "file.")]
		public IfcPositiveRatioMeasure? PlasticShapeFactorZ { get { return this._PlasticShapeFactorZ; } set { this._PlasticShapeFactorZ = value;} }
	
	
	}
	
}
