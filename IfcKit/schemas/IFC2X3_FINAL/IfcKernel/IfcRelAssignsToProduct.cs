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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("55319343-8365-4a00-a7de-4cf13f760e2b")]
	public partial class IfcRelAssignsToProduct : IfcRelAssigns
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProduct _RelatingProduct;
	
	
		public IfcRelAssignsToProduct()
		{
		}
	
		public IfcRelAssignsToProduct(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType, IfcProduct __RelatingProduct)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatedObjectsType)
		{
			this._RelatingProduct = __RelatingProduct;
		}
	
		[Description("Reference to the Product to which the objects are assigned to.\r\n")]
		public IfcProduct RelatingProduct { get { return this._RelatingProduct; } set { this._RelatingProduct = value;} }
	
	
	}
	
}
