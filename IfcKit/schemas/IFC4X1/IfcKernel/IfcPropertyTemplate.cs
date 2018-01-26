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
	[Guid("dfa52a71-6e64-4b4c-af07-d476c558c888")]
	public abstract partial class IfcPropertyTemplate : IfcPropertyTemplateDefinition
	{
		[InverseProperty("HasPropertyTemplates")] 
		ISet<IfcComplexPropertyTemplate> _PartOfComplexTemplate = new HashSet<IfcComplexPropertyTemplate>();
	
		[InverseProperty("HasPropertyTemplates")] 
		ISet<IfcPropertySetTemplate> _PartOfPsetTemplate = new HashSet<IfcPropertySetTemplate>();
	
	
		public IfcPropertyTemplate()
		{
		}
	
		public IfcPropertyTemplate(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
		}
	
		[Description("Reference to a complex property templates. It should only be provided, if the <em" +
	    ">PropertyType</em> of the referenced complex property template is set to <small>" +
	    "COMPLEX</small>.")]
		public ISet<IfcComplexPropertyTemplate> PartOfComplexTemplate { get { return this._PartOfComplexTemplate; } }
	
		[Description("Reference to the <em>IfcPropertySetTemplate</em> that defines the scope for the <" +
	    "em>IfcPropertyTemplate</em>. A single <em>IfcPropertyTemplate</em> can be define" +
	    "d within the scope of zero, one or many <em>IfcPropertySetTemplate</em>\'.")]
		public ISet<IfcPropertySetTemplate> PartOfPsetTemplate { get { return this._PartOfPsetTemplate; } }
	
	
	}
	
}
