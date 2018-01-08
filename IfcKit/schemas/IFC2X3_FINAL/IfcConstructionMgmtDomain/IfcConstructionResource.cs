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
	[Guid("3b596541-4bc7-45ac-8419-fe38754b2d16")]
	public abstract partial class IfcConstructionResource : IfcResource
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcIdentifier? _ResourceIdentifier;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ResourceGroup;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcResourceConsumptionEnum? _ResourceConsumption;
	
		[DataMember(Order=3)] 
		IfcMeasureWithUnit _BaseQuantity;
	
	
		[Description("Optional identification of a code or ID for the construction resource")]
		public IfcIdentifier? ResourceIdentifier { get { return this._ResourceIdentifier; } set { this._ResourceIdentifier = value;} }
	
		[Description("The group label, or title of the type resource, e.g. the title of a labour resour" +
	    "ce as carpenter, crane operator, superintendent, etc.")]
		public IfcLabel? ResourceGroup { get { return this._ResourceGroup; } set { this._ResourceGroup = value;} }
	
		[Description("<EPM-HTML>\r\nA value that indicates how the resource is consumed during its use in" +
	    " a process (see <I>IfcResourceConsumptionEnum</I> for more detail)\r\n</EPM-HTML>")]
		public IfcResourceConsumptionEnum? ResourceConsumption { get { return this._ResourceConsumption; } set { this._ResourceConsumption = value;} }
	
		[Description("The basic (i.e. default, or recommended) unit that should be used for measuring t" +
	    "he volume (or amount) of the resource and the basic quantity of the resource ful" +
	    "ly or partially consumed.")]
		public IfcMeasureWithUnit BaseQuantity { get { return this._BaseQuantity; } set { this._BaseQuantity = value;} }
	
	
	}
	
}
