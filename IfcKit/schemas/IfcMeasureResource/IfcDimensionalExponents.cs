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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	public partial class IfcDimensionalExponents
	{
		[DataMember(Order = 0)] 
		[Description("The power of the length base quantity.")]
		[Required()]
		public Int64 LengthExponent { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The power of the mass base quantity.")]
		[Required()]
		public Int64 MassExponent { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("The power of the time base quantity.")]
		[Required()]
		public Int64 TimeExponent { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("The power of the electric current base quantity.")]
		[Required()]
		public Int64 ElectricCurrentExponent { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("The power of the thermodynamic temperature base quantity.")]
		[Required()]
		public Int64 ThermodynamicTemperatureExponent { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("The power of the amount of substance base quantity.")]
		[Required()]
		public Int64 AmountOfSubstanceExponent { get; set; }
	
		[DataMember(Order = 6)] 
		[Description("The power of the luminous intensity base quantity.")]
		[Required()]
		public Int64 LuminousIntensityExponent { get; set; }
	
	
		public IfcDimensionalExponents(Int64 __LengthExponent, Int64 __MassExponent, Int64 __TimeExponent, Int64 __ElectricCurrentExponent, Int64 __ThermodynamicTemperatureExponent, Int64 __AmountOfSubstanceExponent, Int64 __LuminousIntensityExponent)
		{
			this.LengthExponent = __LengthExponent;
			this.MassExponent = __MassExponent;
			this.TimeExponent = __TimeExponent;
			this.ElectricCurrentExponent = __ElectricCurrentExponent;
			this.ThermodynamicTemperatureExponent = __ThermodynamicTemperatureExponent;
			this.AmountOfSubstanceExponent = __AmountOfSubstanceExponent;
			this.LuminousIntensityExponent = __LuminousIntensityExponent;
		}
	
	
	}
	
}
