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
	[Guid("b8350f31-1606-49d5-a710-ffec9f84a7a8")]
	public abstract partial class IfcResource : IfcObject
	{
		[InverseProperty("RelatingResource")] 
		ISet<IfcRelAssignsToResource> _ResourceOf = new HashSet<IfcRelAssignsToResource>();
	
	
		public IfcResource()
		{
		}
	
		public IfcResource(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
		}
	
		[Description("Reference to the IfcRelAssignsToResource relationship and thus pointing to those " +
	    "objects, which are used as resources.")]
		public ISet<IfcRelAssignsToResource> ResourceOf { get { return this._ResourceOf; } }
	
	
	}
	
}
