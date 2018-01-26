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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcCostResource
{
	[Guid("7f33cb2b-5052-477b-935d-2e15cc042e24")]
	public partial class IfcEnvironmentalImpactValue : IfcAppliedValue
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _ImpactType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcEnvironmentalImpactCategoryEnum _Category;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedCategory;
	
	
		public IfcEnvironmentalImpactValue()
		{
		}
	
		public IfcEnvironmentalImpactValue(IfcLabel? __Name, IfcText? __Description, IfcAppliedValueSelect __AppliedValue, IfcMeasureWithUnit __UnitBasis, IfcDateTimeSelect __ApplicableDate, IfcDateTimeSelect __FixedUntilDate, IfcLabel __ImpactType, IfcEnvironmentalImpactCategoryEnum __Category, IfcLabel? __UserDefinedCategory)
			: base(__Name, __Description, __AppliedValue, __UnitBasis, __ApplicableDate, __FixedUntilDate)
		{
			this._ImpactType = __ImpactType;
			this._Category = __Category;
			this._UserDefinedCategory = __UserDefinedCategory;
		}
	
		[Description("Specification of the environmental impact type to be referenced.")]
		public IfcLabel ImpactType { get { return this._ImpactType; } set { this._ImpactType = value;} }
	
		[Description("The category into which the environmental impact value falls.")]
		public IfcEnvironmentalImpactCategoryEnum Category { get { return this._Category; } set { this._Category = value;} }
	
		[Description("A user defined value category into which the environmental impact value falls.")]
		public IfcLabel? UserDefinedCategory { get { return this._UserDefinedCategory; } set { this._UserDefinedCategory = value;} }
	
	
	}
	
}
