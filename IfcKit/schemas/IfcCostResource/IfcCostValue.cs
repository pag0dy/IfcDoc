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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	public partial class IfcCostValue : IfcAppliedValue,
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("<EPM-HTML>Specification of the type of cost type used.    <BLOCKQUOTE>NOTE: There are many possible types of cost value that may be identified. Whilst there is a broad understanding of the meaning of names that may be assigned to different types of costs, there is no general standard for naming cost types nor are there any broadly defined classifications. To allow for any type of cost value, the IfcLabel datatype is assigned.</BLOCKQUOTE>     In the absence of any well defined standard, it is recommended that local agreements should be made to define allowable and understandable cost value types within a project or region.  </EPM-HTML>    ")]
		[Required()]
		public IfcLabel CostType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The condition under which a cost value applies.")]
		public IfcText? Condition { get; set; }
	
	
		public IfcCostValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDateTimeSelect __ApplicableDate, IfcDateTimeSelect __FixedUntilDate, IfcLabel __CostType, IfcText? __Condition)
			: base(__Name, __Description, __AppliedValue, __UnitBasis, __ApplicableDate, __FixedUntilDate)
		{
			this.CostType = __CostType;
			this.Condition = __Condition;
		}
	
	
	}
	
}
