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
	public abstract partial class IfcPropertyTemplate : IfcPropertyTemplateDefinition
	{
		[InverseProperty("HasPropertyTemplates")] 
		[Description("Reference to a complex property templates. It should only be provided, if the <em>PropertyType</em> of the referenced complex property template is set to <small>COMPLEX</small>.")]
		public ISet<IfcComplexPropertyTemplate> PartOfComplexTemplate { get; protected set; }
	
		[InverseProperty("HasPropertyTemplates")] 
		[Description("Reference to the <em>IfcPropertySetTemplate</em> that defines the scope for the <em>IfcPropertyTemplate</em>. A single <em>IfcPropertyTemplate</em> can be defined within the scope of zero, one or many <em>IfcPropertySetTemplate</em>'.")]
		public ISet<IfcPropertySetTemplate> PartOfPsetTemplate { get; protected set; }
	
	
		protected IfcPropertyTemplate(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.PartOfComplexTemplate = new HashSet<IfcComplexPropertyTemplate>();
			this.PartOfPsetTemplate = new HashSet<IfcPropertySetTemplate>();
		}
	
	
	}
	
}
