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
	public partial class IfcPropertySetTemplate : IfcPropertyTemplateDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Property set type defining whether the property set is applicable to a type (subtypes of <em>IfcTypeObject</em>), to an occurrence (subtypes of <em>IfcObject</em>), or as a special case to a performance history.<br><br>  The attribute <em>ApplicableEntity</em> may further refine the applicability to a single or multiple entity type(s).")]
		public IfcPropertySetTemplateTypeEnum? TemplateType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The attribute optionally defines the data type of the applicable type or occurrence object, to which the assigned property set template can relate. If not present, no instruction is given to which type or occurrence object the property set template is applicable. The following conventions are used:  <ul>    <li>The IFC entity name of the applicable entity using the IFC naming convention, CamelCase with IFC prefix</li>    <li>It can be optionally followed by the predefined type after the separator \"/\" (forward slash), using upper case</li>    <li>If a performance history object of a particular distribution object is attributes by the property set template, then the entity name (and potentially amended by the predefined type) is expanded by adding '[PerformanceHistory]'    <li>If one property set template is applicable to many type and/or occurrence objects, then those object names should be separate by comma \",\" forming a comma separated string.  </ul>  <blockquote class=\"example\">EXAMPLE  Refering to a boiler type as applicable entity would be expressed as 'IfcBoilerType', refering to a steam boiler type as applicable entity would be expressed as 'IfcBoilerType/STEAM', refering to a wall and wall standard case and a wall type would be expressed as 'IfcWall, IfcWallStandardCase, IfcWallType'. An applicable <em>IfcPerformanceHistory</em> assigned to an occurrence or type object would be indicated by IfcBoilerType[PerformanceHistory], or respectively IfcBoilerType/STEAM[PerformanceHistory].</blockquote>")]
		public IfcIdentifier? ApplicableEntity { get; set; }
	
		[DataMember(Order = 2)] 
		[Description("Set of <em>IfcPropertyTemplate</em>'s that are defined within the scope of the <em>IfcPropertySetTemplate</em>.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcPropertyTemplate> HasPropertyTemplates { get; protected set; }
	
		[InverseProperty("RelatingTemplate")] 
		[Description("Relation to the property sets, via the objectified relationship <em>IfcRelDefinesByTemplate</em>, that, if given, utilize the definition template. ")]
		public ISet<IfcRelDefinesByTemplate> Defines { get; protected set; }
	
	
		public IfcPropertySetTemplate(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcPropertySetTemplateTypeEnum? __TemplateType, IfcIdentifier? __ApplicableEntity, IfcPropertyTemplate[] __HasPropertyTemplates)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.TemplateType = __TemplateType;
			this.ApplicableEntity = __ApplicableEntity;
			this.HasPropertyTemplates = new HashSet<IfcPropertyTemplate>(__HasPropertyTemplates);
			this.Defines = new HashSet<IfcRelDefinesByTemplate>();
		}
	
	
	}
	
}
