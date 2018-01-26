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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	[Guid("eff34c4d-41a1-48b3-badc-950cf6816a7b")]
	public partial class IfcProject : IfcContext
	{
	
		public IfcProject()
		{
		}
	
		public IfcProject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel? __LongName, IfcLabel? __Phase, IfcRepresentationContext[] __RepresentationContexts, IfcUnitAssignment __UnitsInContext)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __LongName, __Phase, __RepresentationContexts, __UnitsInContext)
		{
		}
	
	
	}
	
}
