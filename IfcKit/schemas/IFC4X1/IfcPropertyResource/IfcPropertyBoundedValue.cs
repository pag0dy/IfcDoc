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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("8e5675b7-1eab-4355-967e-bd85ba01ab9d")]
	public partial class IfcPropertyBoundedValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IfcValue _UpperBoundValue;
	
		[DataMember(Order=1)] 
		IfcValue _LowerBoundValue;
	
		[DataMember(Order=2)] 
		IfcUnit _Unit;
	
		[DataMember(Order=3)] 
		IfcValue _SetPointValue;
	
	
		public IfcPropertyBoundedValue()
		{
		}
	
		public IfcPropertyBoundedValue(IfcIdentifier __Name, IfcText? __Description, IfcValue __UpperBoundValue, IfcValue __LowerBoundValue, IfcUnit __Unit, IfcValue __SetPointValue)
			: base(__Name, __Description)
		{
			this._UpperBoundValue = __UpperBoundValue;
			this._LowerBoundValue = __LowerBoundValue;
			this._Unit = __Unit;
			this._SetPointValue = __SetPointValue;
		}
	
		[Description("Upper bound value for the interval defining the property value. If the value is n" +
	    "ot given, it indicates an open bound (all values to be greater than or equal to " +
	    "<em>LowerBoundValue</em>).")]
		public IfcValue UpperBoundValue { get { return this._UpperBoundValue; } set { this._UpperBoundValue = value;} }
	
		[Description("Lower bound value for the interval defining the property value. If the value is n" +
	    "ot given, it indicates an open bound (all values to be lower than or equal to <e" +
	    "m>UpperBoundValue</em>).")]
		public IfcValue LowerBoundValue { get { return this._LowerBoundValue; } set { this._LowerBoundValue = value;} }
	
		[Description(@"Unit for the upper and lower bound values, if not given, the default value for the measure type is used as defined by the global unit assignment at <em>IfcProject.UnitInContext</em>. The applicable unit is then selected by the underlying TYPE of the <em>UpperBoundValue</em>, <em>LowerBoundValue</em>, and <em>SetPointValue</em>)")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		[Description("Set point value as typically used for operational value setting.\r\n<blockquote cla" +
	    "ss=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been added at the end of " +
	    "the attribute list.</blockquote>")]
		public IfcValue SetPointValue { get { return this._SetPointValue; } set { this._SetPointValue = value;} }
	
	
	}
	
}
