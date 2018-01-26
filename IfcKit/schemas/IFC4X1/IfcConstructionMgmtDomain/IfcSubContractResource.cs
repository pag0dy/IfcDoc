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

using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("43fbb978-b475-40b1-8fa8-494040d73aa4")]
	public partial class IfcSubContractResource : IfcConstructionResource
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcSubContractResourceTypeEnum? _PredefinedType;
	
	
		public IfcSubContractResource()
		{
		}
	
		public IfcSubContractResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcResourceTime __Usage, IfcAppliedValue[] __BaseCosts, IfcPhysicalQuantity __BaseQuantity, IfcSubContractResourceTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription, __Usage, __BaseCosts, __BaseQuantity)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Defines types of subcontract resources.\r\n<blockquote class=\"change-ifc2x4\">IFC4 N" +
	    "ew attribute.</blockquote>")]
		public IfcSubContractResourceTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
