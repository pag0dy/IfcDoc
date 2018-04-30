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
	public abstract partial class IfcPropertySetDefinition : IfcPropertyDefinition,
		BuildingSmart.IFC.IfcKernel.IfcPropertySetDefinitionSelect
	{
		[InverseProperty("HasPropertySets")] 
		[Description("The type object to which the property set is assigned. The property set acts as a shared property set to all occurrences of the type object.  <blockquote class=\"note\">  NOTE&nbsp; The relationship between the <em>IfcPropertySetDefinition</em> and the <em>IfcTypeObject</em> is a direct relationship, not utilizing <em>IfcRelDefinesByProperties</em>, for maintaining compatibility with earlier releases of this standard.  </blockquote>  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp;  The cardinality has been changed from 0:1 to 0:? with upward compatibility for file based exchange.  </blockquote>")]
		public ISet<IfcTypeObject> DefinesType { get; protected set; }
	
		[InverseProperty("RelatedPropertySets")] 
		[Description("Relation to the property set template, via the objectified relationship <em>IfcRelDefinesByTemplate</em>, that, if given, provides the definition template for the property set or quantity set and its properties.   <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE&nbsp; New inverse relationship, change made with upward compatibility for file based exchange.  </blockquote>")]
		public ISet<IfcRelDefinesByTemplate> IsDefinedBy { get; protected set; }
	
		[InverseProperty("RelatingPropertyDefinition")] 
		[Description("Reference to the relation to one or many object occurrences that are characterized by the property set definition. A single property set can be assigned to multiple object occurrences using the objectified relationship <em>IfcRefDefinesByProperties</em>.  <blockquote class=\"change-ifc2x4\">  IFC4 CHANGE Inverse attribute renamed from PropertyDefinitionOf with upward compatibility for file-based exchange.  </blockquote>")]
		public ISet<IfcRelDefinesByProperties> DefinesOccurrence { get; protected set; }
	
	
		protected IfcPropertySetDefinition(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.DefinesType = new HashSet<IfcTypeObject>();
			this.IsDefinedBy = new HashSet<IfcRelDefinesByTemplate>();
			this.DefinesOccurrence = new HashSet<IfcRelDefinesByProperties>();
		}
	
	
	}
	
}
