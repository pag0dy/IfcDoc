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
	public abstract partial class IfcPropertyDefinition : IfcRoot,
		BuildingSmart.IFC.IfcKernel.IfcDefinitionSelect
	{
		[InverseProperty("RelatedDefinitions")] 
		[MaxLength(1)]
		public ISet<IfcRelDeclares> HasContext { get; protected set; }
	
		[InverseProperty("RelatedObjects")] 
		[Description("Reference to the relationship IfcRelAssociates and thus to those externally defined concepts, like classifications, documents, or library information, which are associated to the property definition.")]
		public ISet<IfcRelAssociates> HasAssociations { get; protected set; }
	
	
		protected IfcPropertyDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.HasContext = new HashSet<IfcRelDeclares>();
			this.HasAssociations = new HashSet<IfcRelAssociates>();
		}
	
	
	}
	
}
