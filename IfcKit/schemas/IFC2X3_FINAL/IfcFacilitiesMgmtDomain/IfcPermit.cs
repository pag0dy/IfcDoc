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
	[Guid("3e2d11e0-922a-475a-bc13-2358eed392da")]
	public partial class IfcPermit : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _PermitID;
	
	
		public IfcPermit()
		{
		}
	
		public IfcPermit(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __PermitID)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._PermitID = __PermitID;
		}
	
		[Description("A unique identifier assigned to a permit.")]
		public IfcIdentifier PermitID { get { return this._PermitID; } set { this._PermitID = value;} }
	
	
	}
	
}
