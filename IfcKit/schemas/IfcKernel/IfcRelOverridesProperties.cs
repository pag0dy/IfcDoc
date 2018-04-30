// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public partial class IfcRelOverridesProperties : IfcRelDefinesByProperties
	{
		[DataMember(Order = 0)] 
		[Description("A property set, which contains those properties, that have a different value for the subset of objects.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcProperty> OverridingProperties { get; protected set; }
	
	
		public IfcRelOverridesProperties(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObject[] __RelatedObjects, IfcPropertySetDefinition __RelatingPropertyDefinition, IfcProperty[] __OverridingProperties)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatedObjects, __RelatingPropertyDefinition)
		{
			this.OverridingProperties = new HashSet<IfcProperty>(__OverridingProperties);
		}
	
	
	}
	
}
