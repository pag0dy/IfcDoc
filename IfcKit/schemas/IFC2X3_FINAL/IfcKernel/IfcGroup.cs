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
	[Guid("69a0af4c-7e8d-4eef-9640-5013d87c6c55")]
	public partial class IfcGroup : IfcObject
	{
		[InverseProperty("RelatingGroup")] 
		IfcRelAssignsToGroup _IsGroupedBy;
	
	
		public IfcGroup()
		{
		}
	
		public IfcGroup(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
		}
	
		[Description("Contains the relationship that assigns the group members to the group object.\r\n")]
		public IfcRelAssignsToGroup IsGroupedBy { get { return this._IsGroupedBy; } set { this._IsGroupedBy = value;} }
	
	
	}
	
}
