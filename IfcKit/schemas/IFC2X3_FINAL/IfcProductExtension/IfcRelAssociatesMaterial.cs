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
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("157a4d8c-92d8-4c73-a181-a3fc355cb7a1")]
	public partial class IfcRelAssociatesMaterial : IfcRelAssociates
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcMaterialSelect _RelatingMaterial;
	
	
		public IfcRelAssociatesMaterial()
		{
		}
	
		public IfcRelAssociatesMaterial(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects, IfcMaterialSelect __RelatingMaterial)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects)
		{
			this._RelatingMaterial = __RelatingMaterial;
		}
	
		[Description("Material definition (either a single material, a list of materials, or a set of m" +
	    "aterial layers) assigned to the elements.")]
		public IfcMaterialSelect RelatingMaterial { get { return this._RelatingMaterial; } set { this._RelatingMaterial = value;} }
	
	
	}
	
}
