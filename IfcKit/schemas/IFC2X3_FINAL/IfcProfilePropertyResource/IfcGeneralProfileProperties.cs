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
	[Guid("c490a750-12d1-4aeb-8323-866acb23376a")]
	public partial class IfcGeneralProfileProperties : IfcProfileProperties
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcMassPerLengthMeasure? _PhysicalWeight;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Perimeter;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MinimumPlateThickness;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MaximumPlateThickness;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcAreaMeasure? _CrossSectionArea;
	
	
		public IfcGeneralProfileProperties()
		{
		}
	
		public IfcGeneralProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea)
			: base(__ProfileName, __ProfileDefinition)
		{
			this._PhysicalWeight = __PhysicalWeight;
			this._Perimeter = __Perimeter;
			this._MinimumPlateThickness = __MinimumPlateThickness;
			this._MaximumPlateThickness = __MaximumPlateThickness;
			this._CrossSectionArea = __CrossSectionArea;
		}
	
		[Description("Weight of an imaginary steel beam per length, as for example given by the nationa" +
	    "l standards\t for this profile. Usually measured in [kg/m].")]
		public IfcMassPerLengthMeasure? PhysicalWeight { get { return this._PhysicalWeight; } set { this._PhysicalWeight = value;} }
	
		[Description("Perimeter of the profile for calculating the surface area. Usually measured in [m" +
	    "m].")]
		public IfcPositiveLengthMeasure? Perimeter { get { return this._Perimeter; } set { this._Perimeter = value;} }
	
		[Description("This value is needed for stress analysis and to handle buckling problems. It can " +
	    "also be derived from the given profile geometry and therefore it is only an opti" +
	    "onal feature allowing for an explicit description. Usually measured in [mm].")]
		public IfcPositiveLengthMeasure? MinimumPlateThickness { get { return this._MinimumPlateThickness; } set { this._MinimumPlateThickness = value;} }
	
		[Description("This value is needed for stress analysis and to handle buckling problems. It can " +
	    "also be derived from the given profile geometry and therefore it is only an opti" +
	    "onal feature allowing for an explicit description. Usually measured in [mm].")]
		public IfcPositiveLengthMeasure? MaximumPlateThickness { get { return this._MaximumPlateThickness; } set { this._MaximumPlateThickness = value;} }
	
		[Description("Cross sectional area of profile. Usually measured in [mm2].")]
		public IfcAreaMeasure? CrossSectionArea { get { return this._CrossSectionArea; } set { this._CrossSectionArea = value;} }
	
	
	}
	
}
