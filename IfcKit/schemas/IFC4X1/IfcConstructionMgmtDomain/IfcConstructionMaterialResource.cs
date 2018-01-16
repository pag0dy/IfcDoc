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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcSharedMgmtElements;

namespace BuildingSmart.IFC.IfcConstructionMgmtDomain
{
	[Guid("8ca7e9ca-418d-449f-8156-85a0d8c68a74")]
	public partial class IfcConstructionMaterialResource : IfcConstructionResource
	{
		[DataMember(Order=0)] 
		ISet<IfcActorSelect> _Suppliers = new HashSet<IfcActorSelect>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcRatioMeasure? _UsageRatio;
	
	
		[Description("Possible suppliers of the type of materials.")]
		public ISet<IfcActorSelect> Suppliers { get { return this._Suppliers; } }
	
		[Description("The ratio of the amount of a construction material used to the amount provided (d" +
	    "etermined as a quantity)")]
		public IfcRatioMeasure? UsageRatio { get { return this._UsageRatio; } set { this._UsageRatio = value;} }
	
	
	}
	
}
