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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyBoundedValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("Upper bound value for the interval defining the property value. If the value is not given, it indicates an open bound (all values to be greater than or equal to LowerBoundValue).")]
		public IfcValue UpperBoundValue { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Lower bound value for the interval defining the property value. If the value is not given, it indicates an open bound (all values to be lower than or equal to UpperBoundValue).")]
		public IfcValue LowerBoundValue { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Unit for the upper and lower bound values, if not given, the default value for the measure type (given by the TYPE of the upper and lower bound values) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit Unit { get; set; }
	
	
		public IfcPropertyBoundedValue(IfcIdentifier __Name, IfcText? __Description, IfcValue __UpperBoundValue, IfcValue __LowerBoundValue, IfcUnit __Unit)
			: base(__Name, __Description)
		{
			this.UpperBoundValue = __UpperBoundValue;
			this.LowerBoundValue = __LowerBoundValue;
			this.Unit = __Unit;
		}
	
	
	}
	
}
