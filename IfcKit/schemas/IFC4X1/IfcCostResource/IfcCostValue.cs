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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("21cab0f5-bca1-4dd1-84b4-11713d9334b1")]
	public partial class IfcCostValue : IfcAppliedValue
	{
	
		public IfcCostValue()
		{
		}
	
		public IfcCostValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDate? __ApplicableDate, IfcDate? __FixedUntilDate, IfcLabel? __Category, IfcLabel? __Condition, IfcArithmeticOperatorEnum? __ArithmeticOperator, IfcAppliedValue[] __Components)
			: base(__Name, __Description, __AppliedValue, __UnitBasis, __ApplicableDate, __FixedUntilDate, __Category, __Condition, __ArithmeticOperator, __Components)
		{
		}
	
	
	}
	
}
