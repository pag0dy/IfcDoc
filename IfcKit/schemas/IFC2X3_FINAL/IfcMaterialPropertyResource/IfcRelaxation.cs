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

namespace BuildingSmart.IFC.IfcMaterialPropertyResource
{
	[Guid("cd349656-deb5-45e0-8e2d-69f5b70cdeb5")]
	public partial class IfcRelaxation
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcNormalisedRatioMeasure _RelaxationValue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcNormalisedRatioMeasure _InitialStress;
	
	
		public IfcRelaxation()
		{
		}
	
		public IfcRelaxation(IfcNormalisedRatioMeasure __RelaxationValue, IfcNormalisedRatioMeasure __InitialStress)
		{
			this._RelaxationValue = __RelaxationValue;
			this._InitialStress = __InitialStress;
		}
	
		[Description("Time dependent loss of stress, relative to initial stress and therefore dimension" +
	    "less.")]
		public IfcNormalisedRatioMeasure RelaxationValue { get { return this._RelaxationValue; } set { this._RelaxationValue = value;} }
	
		[Description("Stress at the beginning. Given as relative to the yield stress of the material an" +
	    "d is therefore dimensionless.")]
		public IfcNormalisedRatioMeasure InitialStress { get { return this._InitialStress; } set { this._InitialStress = value;} }
	
	
	}
	
}
