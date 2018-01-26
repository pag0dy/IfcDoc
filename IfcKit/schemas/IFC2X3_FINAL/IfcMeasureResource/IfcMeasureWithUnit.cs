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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcFacilitiesMgmtDomain;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("0723c581-0348-47f4-bca7-0f9d95f046c0")]
	public partial class IfcMeasureWithUnit :
		BuildingSmart.IFC.IfcCostResource.IfcAppliedValueSelect,
		BuildingSmart.IFC.IfcFacilitiesMgmtDomain.IfcConditionCriterionSelect,
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcValue _ValueComponent;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcUnit _UnitComponent;
	
	
		public IfcMeasureWithUnit()
		{
		}
	
		public IfcMeasureWithUnit(IfcValue __ValueComponent, IfcUnit __UnitComponent)
		{
			this._ValueComponent = __ValueComponent;
			this._UnitComponent = __UnitComponent;
		}
	
		[Description("The value of the physical quantity when expressed in the specified units.")]
		public IfcValue ValueComponent { get { return this._ValueComponent; } set { this._ValueComponent = value;} }
	
		[Description("The unit in which the physical quantity is expressed.")]
		public IfcUnit UnitComponent { get { return this._UnitComponent; } set { this._UnitComponent = value;} }
	
	
	}
	
}
