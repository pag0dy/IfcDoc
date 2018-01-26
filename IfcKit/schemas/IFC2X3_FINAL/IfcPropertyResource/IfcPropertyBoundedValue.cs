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

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("90e087a6-afe3-4dc3-898f-9b657acd43c8")]
	public partial class IfcPropertyBoundedValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IfcValue _UpperBoundValue;
	
		[DataMember(Order=1)] 
		IfcValue _LowerBoundValue;
	
		[DataMember(Order=2)] 
		IfcUnit _Unit;
	
	
		public IfcPropertyBoundedValue()
		{
		}
	
		public IfcPropertyBoundedValue(IfcIdentifier __Name, IfcText? __Description, IfcValue __UpperBoundValue, IfcValue __LowerBoundValue, IfcUnit __Unit)
			: base(__Name, __Description)
		{
			this._UpperBoundValue = __UpperBoundValue;
			this._LowerBoundValue = __LowerBoundValue;
			this._Unit = __Unit;
		}
	
		[Description("Upper bound value for the interval defining the property value. If the value is n" +
	    "ot given, it indicates an open bound (all values to be greater than or equal to " +
	    "LowerBoundValue).")]
		public IfcValue UpperBoundValue { get { return this._UpperBoundValue; } set { this._UpperBoundValue = value;} }
	
		[Description("Lower bound value for the interval defining the property value. If the value is n" +
	    "ot given, it indicates an open bound (all values to be lower than or equal to Up" +
	    "perBoundValue).")]
		public IfcValue LowerBoundValue { get { return this._LowerBoundValue; } set { this._LowerBoundValue = value;} }
	
		[Description("Unit for the upper and lower bound values, if not given, the default value for th" +
	    "e measure type (given by the TYPE of the upper and lower bound values) is used a" +
	    "s defined by the global unit assignment at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
