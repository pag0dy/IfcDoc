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
	[Guid("0935fc73-9d2c-4777-a78c-13e931da9996")]
	public abstract partial class IfcPropertyTemplateDefinition : IfcPropertyDefinition
	{
	
		public IfcPropertyTemplateDefinition()
		{
		}
	
		public IfcPropertyTemplateDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
		}
	
	
	}
	
}
