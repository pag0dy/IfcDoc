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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcPropertySetDefinition : IfcPropertyDefinition
	{
		[InverseProperty("RelatingPropertyDefinition")] 
		[Description("Reference to the relation to one or many objects that are characterized by the property definition. The reference may be omitted, if the property definition is used to define a style library and no instances, to which the particular style of property set is associated, exist yet.")]
		[MaxLength(1)]
		public ISet<IfcRelDefinesByProperties> PropertyDefinitionOf { get; protected set; }
	
		[InverseProperty("HasPropertySets")] 
		[Description("The property style to which the property set might belong.")]
		[MaxLength(1)]
		public ISet<IfcTypeObject> DefinesType { get; protected set; }
	
	
		protected IfcPropertySetDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.PropertyDefinitionOf = new HashSet<IfcRelDefinesByProperties>();
			this.DefinesType = new HashSet<IfcTypeObject>();
		}
	
	
	}
	
}
