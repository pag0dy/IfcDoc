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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("8a4f8c35-5289-4e38-a1b9-9f40410d6e20")]
	public partial class IfcServiceLifeFactor : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcServiceLifeFactorTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		IfcMeasureValue _UpperValue;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcMeasureValue _MostUsedValue;
	
		[DataMember(Order=3)] 
		IfcMeasureValue _LowerValue;
	
	
		public IfcServiceLifeFactor()
		{
		}
	
		public IfcServiceLifeFactor(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcServiceLifeFactorTypeEnum __PredefinedType, IfcMeasureValue __UpperValue, IfcMeasureValue __MostUsedValue, IfcMeasureValue __LowerValue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._PredefinedType = __PredefinedType;
			this._UpperValue = __UpperValue;
			this._MostUsedValue = __MostUsedValue;
			this._LowerValue = __LowerValue;
		}
	
		[Description("Predefined service life factor types from which that required may be set. ")]
		public IfcServiceLifeFactorTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Upper of the three values assigned to the service life factor.")]
		public IfcMeasureValue UpperValue { get { return this._UpperValue; } set { this._UpperValue = value;} }
	
		[Description("Most used of the three values assigned to the service life factor.")]
		public IfcMeasureValue MostUsedValue { get { return this._MostUsedValue; } set { this._MostUsedValue = value;} }
	
		[Description("Lower of the three values assigned to the service life factor.")]
		public IfcMeasureValue LowerValue { get { return this._LowerValue; } set { this._LowerValue = value;} }
	
	
	}
	
}
