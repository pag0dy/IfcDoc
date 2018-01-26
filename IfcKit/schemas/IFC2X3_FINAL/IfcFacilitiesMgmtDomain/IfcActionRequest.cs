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

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	[Guid("b6d11163-93eb-4d0a-b9aa-45d080259377")]
	public partial class IfcActionRequest : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _RequestID;
	
	
		public IfcActionRequest()
		{
		}
	
		public IfcActionRequest(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __RequestID)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._RequestID = __RequestID;
		}
	
		[Description("A unique identifier assigned to the request on receipt.")]
		public IfcIdentifier RequestID { get { return this._RequestID; } set { this._RequestID = value;} }
	
	
	}
	
}
