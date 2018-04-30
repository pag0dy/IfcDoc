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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyBoundedValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("Upper bound value for the interval defining the property value. If the value is not given, it indicates an open bound (all values to be greater than or equal to <em>LowerBoundValue</em>).")]
		public IfcValue UpperBoundValue { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Lower bound value for the interval defining the property value. If the value is not given, it indicates an open bound (all values to be lower than or equal to <em>UpperBoundValue</em>).")]
		public IfcValue LowerBoundValue { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Unit for the upper and lower bound values, if not given, the default value for the measure type is used as defined by the global unit assignment at <em>IfcProject.UnitInContext</em>. The applicable unit is then selected by the underlying TYPE of the <em>UpperBoundValue</em>, <em>LowerBoundValue</em>, and <em>SetPointValue</em>)")]
		public IfcUnit Unit { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Set point value as typically used for operational value setting.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been added at the end of the attribute list.</blockquote>")]
		public IfcValue SetPointValue { get; set; }
	
	
		public IfcPropertyBoundedValue(IfcIdentifier __Name, IfcText? __Description, IfcValue __UpperBoundValue, IfcValue __LowerBoundValue, IfcUnit __Unit, IfcValue __SetPointValue)
			: base(__Name, __Description)
		{
			this.UpperBoundValue = __UpperBoundValue;
			this.LowerBoundValue = __LowerBoundValue;
			this.Unit = __Unit;
			this.SetPointValue = __SetPointValue;
		}
	
	
	}
	
}
