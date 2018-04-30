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

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	public partial class IfcRelaxation
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Time dependent loss of stress, relative to initial stress and therefore dimensionless.")]
		[Required()]
		public IfcNormalisedRatioMeasure RelaxationValue { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Stress at the beginning. Given as relative to the yield stress of the material and is therefore dimensionless.")]
		[Required()]
		public IfcNormalisedRatioMeasure InitialStress { get; set; }
	
	
		public IfcRelaxation(IfcNormalisedRatioMeasure __RelaxationValue, IfcNormalisedRatioMeasure __InitialStress)
		{
			this.RelaxationValue = __RelaxationValue;
			this.InitialStress = __InitialStress;
		}
	
	
	}
	
}
