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
	public partial class IfcGeneralProfileProperties : IfcProfileProperties
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Weight of an imaginary steel beam per length, as for example given by the national standards	 for this profile. Usually measured in [kg/m].")]
		public IfcMassPerLengthMeasure? PhysicalWeight { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Perimeter of the profile for calculating the surface area. Usually measured in [mm].")]
		public IfcPositiveLengthMeasure? Perimeter { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("This value is needed for stress analysis and to handle buckling problems. It can also be derived from the given profile geometry and therefore it is only an optional feature allowing for an explicit description. Usually measured in [mm].")]
		public IfcPositiveLengthMeasure? MinimumPlateThickness { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("This value is needed for stress analysis and to handle buckling problems. It can also be derived from the given profile geometry and therefore it is only an optional feature allowing for an explicit description. Usually measured in [mm].")]
		public IfcPositiveLengthMeasure? MaximumPlateThickness { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Cross sectional area of profile. Usually measured in [mm2].")]
		public IfcAreaMeasure? CrossSectionArea { get; set; }
	
	
		public IfcGeneralProfileProperties(IfcLabel? __ProfileName, IfcProfileDef __ProfileDefinition, IfcMassPerLengthMeasure? __PhysicalWeight, IfcPositiveLengthMeasure? __Perimeter, IfcPositiveLengthMeasure? __MinimumPlateThickness, IfcPositiveLengthMeasure? __MaximumPlateThickness, IfcAreaMeasure? __CrossSectionArea)
			: base(__ProfileName, __ProfileDefinition)
		{
			this.PhysicalWeight = __PhysicalWeight;
			this.Perimeter = __Perimeter;
			this.MinimumPlateThickness = __MinimumPlateThickness;
			this.MaximumPlateThickness = __MaximumPlateThickness;
			this.CrossSectionArea = __CrossSectionArea;
		}
	
	
	}
	
}
