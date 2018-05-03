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
	public partial class IfcTypeObject : IfcObjectDefinition
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The attribute optionally defines the data type of the occurrence object, to which the assigned type object can relate. If not present, no instruction is given to which occurrence object the type object is applicable. The following conventions are used:  <ul>    <li>The IFC entity name of the applicable occurrence using the IFC naming convention, CamelCase with IFC prefix</li>    <li>It can be optionally followed by the predefined type after the separator \"/\" (forward slash), using uppercase</li>    <li>If one type object is applicable to many occurrence objects, then those occurrence object names should be separate by comma \",\" forming a comma separated string.  </ul>  <blockquote class=\"example\">    EXAMPLE  Refering to a furniture as applicable occurrence entity would be expressed as 'IfcFurnishingElement', refering to a brace as applicable entity would be expressed as 'IfcMember/BRACE', refering to a wall and wall standard case would be expressed as 'IfcWall, IfcWallStandardCase'.  </blockquote>")]
		public IfcIdentifier? ApplicableOccurrence { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Set <strike>list</strike> of unique property sets, that are associated with the object type and are common to all object occurrences referring to this object type.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; The attribute aggregate type has been changed from LIST to SET.</blockquote>")]
		[MinLength(1)]
		public ISet<IfcPropertySetDefinition> HasPropertySets { get; protected set; }
	
		[InverseProperty("RelatingType")] 
		[Description("Reference to the relationship IfcRelDefinedByType and thus to those occurrence objects, which are defined by this type.")]
		[MaxLength(1)]
		public ISet<IfcRelDefinesByType> Types { get; protected set; }
	
	
		public IfcTypeObject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.ApplicableOccurrence = __ApplicableOccurrence;
			this.HasPropertySets = new HashSet<IfcPropertySetDefinition>(__HasPropertySets);
			this.Types = new HashSet<IfcRelDefinesByType>();
		}
	
	
	}
	
}
