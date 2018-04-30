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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	public partial class IfcEnvironmentalImpactValue : IfcAppliedValue
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Specification of the environmental impact type to be referenced.")]
		[Required()]
		public IfcLabel ImpactType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The category into which the environmental impact value falls.")]
		[Required()]
		public IfcEnvironmentalImpactCategoryEnum Category { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A user defined value category into which the environmental impact value falls.")]
		public IfcLabel? UserDefinedCategory { get; set; }
	
	
		public IfcEnvironmentalImpactValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDateTimeSelect __ApplicableDate, IfcDateTimeSelect __FixedUntilDate, IfcLabel __ImpactType, IfcEnvironmentalImpactCategoryEnum __Category, IfcLabel? __UserDefinedCategory)
			: base(__Name, __Description, __AppliedValue, __UnitBasis, __ApplicableDate, __FixedUntilDate)
		{
			this.ImpactType = __ImpactType;
			this.Category = __Category;
			this.UserDefinedCategory = __UserDefinedCategory;
		}
	
	
	}
	
}
