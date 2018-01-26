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
	[Guid("fabdfdbe-8283-487d-ba56-80cbfd5c227e")]
	public partial class IfcStructuralProfileProperties : IfcGeneralProfileProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcMomentOfInertiaMeasure? _TorsionalConstantX;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcMomentOfInertiaMeasure? _MomentOfInertiaYZ;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcMomentOfInertiaMeasure? _MomentOfInertiaY;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcMomentOfInertiaMeasure? _MomentOfInertiaZ;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcWarpingConstantMeasure? _WarpingConstant;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcLengthMeasure? _ShearCentreZ;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLengthMeasure? _ShearCentreY;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcAreaMeasure? _ShearDeformationAreaZ;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcAreaMeasure? _ShearDeformationAreaY;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcSectionModulusMeasure? _MaximumSectionModulusY;
	
		[DataMember(Order=10)] 
		[XmlAttribute]
		IfcSectionModulusMeasure? _MinimumSectionModulusY;
	
		[DataMember(Order=11)] 
		[XmlAttribute]
		IfcSectionModulusMeasure? _MaximumSectionModulusZ;
	
		[DataMember(Order=12)] 
		[XmlAttribute]
		IfcSectionModulusMeasure? _MinimumSectionModulusZ;
	
		[DataMember(Order=13)] 
		[XmlAttribute]
		IfcSectionModulusMeasure? _TorsionalSectionModulus;
	
		[DataMember(Order=14)] 
		[XmlAttribute]
		IfcLengthMeasure? _CentreOfGravityInX;
	
		[DataMember(Order=15)] 
		[XmlAttribute]
		IfcLengthMeasure? _CentreOfGravityInY;
	
	
		public IfcStructuralProfileProperties()
		{
		}
	
		public IfcStructuralProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea, IfcMomentOfInertiaMeasure? __TorsionalConstantX, IfcMomentOfInertiaMeasure? __MomentOfInertiaYZ, IfcMomentOfInertiaMeasure? __MomentOfInertiaY, IfcMomentOfInertiaMeasure? __MomentOfInertiaZ, IfcWarpingConstantMeasure? __WarpingConstant, IfcLengthMeasure? __ShearCentreZ, IfcLengthMeasure? __ShearCentreY, IfcAreaMeasure? __ShearDeformationAreaZ, IfcAreaMeasure? __ShearDeformationAreaY, IfcSectionModulusMeasure? __MaximumSectionModulusY, IfcSectionModulusMeasure? __MinimumSectionModulusY, IfcSectionModulusMeasure? __MaximumSectionModulusZ, IfcSectionModulusMeasure? __MinimumSectionModulusZ, IfcSectionModulusMeasure? __TorsionalSectionModulus, IfcLengthMeasure? __CentreOfGravityInX, IfcLengthMeasure? __CentreOfGravityInY)
			: base(__ProfileName, __ProfileDefinition, __PhysicalWeight, __Perimeter, __MinimumPlateThickness, __MaximumPlateThickness, __CrossSectionArea)
		{
			this._TorsionalConstantX = __TorsionalConstantX;
			this._MomentOfInertiaYZ = __MomentOfInertiaYZ;
			this._MomentOfInertiaY = __MomentOfInertiaY;
			this._MomentOfInertiaZ = __MomentOfInertiaZ;
			this._WarpingConstant = __WarpingConstant;
			this._ShearCentreZ = __ShearCentreZ;
			this._ShearCentreY = __ShearCentreY;
			this._ShearDeformationAreaZ = __ShearDeformationAreaZ;
			this._ShearDeformationAreaY = __ShearDeformationAreaY;
			this._MaximumSectionModulusY = __MaximumSectionModulusY;
			this._MinimumSectionModulusY = __MinimumSectionModulusY;
			this._MaximumSectionModulusZ = __MaximumSectionModulusZ;
			this._MinimumSectionModulusZ = __MinimumSectionModulusZ;
			this._TorsionalSectionModulus = __TorsionalSectionModulus;
			this._CentreOfGravityInX = __CentreOfGravityInX;
			this._CentreOfGravityInY = __CentreOfGravityInY;
		}
	
		[Description("Torsional constant about X-axis of profile coordinate system. Usually measured in" +
	    " [mm4].")]
		public IfcMomentOfInertiaMeasure? TorsionalConstantX { get { return this._TorsionalConstantX; } set { this._TorsionalConstantX = value;} }
	
		[Description("Moment of inertia about Y and Z-axes of profile coordinate system. Usually measur" +
	    "ed in [mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaYZ { get { return this._MomentOfInertiaYZ; } set { this._MomentOfInertiaYZ = value;} }
	
		[Description("Moment of inertia about Y-axis of profile coordinate system. Usually measured in " +
	    "[mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaY { get { return this._MomentOfInertiaY; } set { this._MomentOfInertiaY = value;} }
	
		[Description("Moment of inertia about Z-axis of profile coordinate system. Usually measured in " +
	    "[mm4].")]
		public IfcMomentOfInertiaMeasure? MomentOfInertiaZ { get { return this._MomentOfInertiaZ; } set { this._MomentOfInertiaZ = value;} }
	
		[Description("Warping constant of the profile for torsional action. Usually measured in [mm6].")]
		public IfcWarpingConstantMeasure? WarpingConstant { get { return this._WarpingConstant; } set { this._WarpingConstant = value;} }
	
		[Description(@"<EPM-HTML>Location of the profile's shear centre in the structural Z direction. Mapped on IFC profile coordinate system it is the offset in the direction of the negative Y axis. The offset is relative to the center of gravity.<br>
	The <i>ShearCentreZ</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.
	</EPM-HTML>")]
		public IfcLengthMeasure? ShearCentreZ { get { return this._ShearCentreZ; } set { this._ShearCentreZ = value;} }
	
		[Description(@"<EPM-HTML>Location of the profile's shear centre in the structural Y direction. Mapped on IFC profile coordinate system it is the offset in the direction of the negative X axis. The offset is relative to the center of gravity.<br>
	The <i>ShearCentreY</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.
	</EPM-HTML>")]
		public IfcLengthMeasure? ShearCentreY { get { return this._ShearCentreY; } set { this._ShearCentreY = value;} }
	
		[Description("Area of the profile for calculating the shear deformation for a shear force paral" +
	    "lel to the profiles Z-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearDeformationAreaZ { get { return this._ShearDeformationAreaZ; } set { this._ShearDeformationAreaZ = value;} }
	
		[Description("Area of the profile for calculating the shear deformation for a shear force paral" +
	    "lel to the profiles Y-axis. Usually measured in [mm2].")]
		public IfcAreaMeasure? ShearDeformationAreaY { get { return this._ShearDeformationAreaY; } set { this._ShearDeformationAreaY = value;} }
	
		[Description("Bending resistance about Y-axis of profile coordinate system at maximum Z-ordinat" +
	    "e. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MaximumSectionModulusY { get { return this._MaximumSectionModulusY; } set { this._MaximumSectionModulusY = value;} }
	
		[Description("Bending resistance about Y-axis of profile coordinate system at minimum Z-ordinat" +
	    "e. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MinimumSectionModulusY { get { return this._MinimumSectionModulusY; } set { this._MinimumSectionModulusY = value;} }
	
		[Description("Bending resistance about Z-axis of profile coordinate system at maximum Y-ordinat" +
	    "e. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MaximumSectionModulusZ { get { return this._MaximumSectionModulusZ; } set { this._MaximumSectionModulusZ = value;} }
	
		[Description("Bending resistance about Z-axis of profile coordinate system at minimum Y-ordinat" +
	    "e. Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? MinimumSectionModulusZ { get { return this._MinimumSectionModulusZ; } set { this._MinimumSectionModulusZ = value;} }
	
		[Description("Torsional resistance (about the profiles X-axis). Usually measured in [mm3].")]
		public IfcSectionModulusMeasure? TorsionalSectionModulus { get { return this._TorsionalSectionModulus; } set { this._TorsionalSectionModulus = value;} }
	
		[Description(@"<EPM-HTML>Location of the profile's centre of gravity in the geometric X direction. The <i>CentreOfGravityInX</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute <i>CentreOfGravityInX</i> is a new attribute.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcLengthMeasure? CentreOfGravityInX { get { return this._CentreOfGravityInX; } set { this._CentreOfGravityInX = value;} }
	
		[Description(@"<EPM-HTML>Location of the profile's centre of gravity in the geometric Y direction. The <i>CentreOfGravityInY</i> is measured in the global length unit as defined at <i>IfcProject.UnitsInContext</i>.
	  <blockquote> <small><font color=""#ff0000"">
	IFC2x Edition 3 CHANGE&nbsp; The attribute <i>CentreOfGravityInY</i> is a new attribute.
	  </font></small></blockquote>
	</EPM-HTML>")]
		public IfcLengthMeasure? CentreOfGravityInY { get { return this._CentreOfGravityInY; } set { this._CentreOfGravityInY = value;} }
	
	
	}
	
}
