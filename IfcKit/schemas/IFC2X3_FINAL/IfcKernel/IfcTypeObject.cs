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
	[Guid("14976879-1ae4-476a-8bfa-d72becabda73")]
	public partial class IfcTypeObject : IfcObjectDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _ApplicableOccurrence;
	
		[DataMember(Order=1)] 
		[MinLength(1)]
		ISet<IfcPropertySetDefinition> _HasPropertySets = new HashSet<IfcPropertySetDefinition>();
	
		[InverseProperty("RelatingType")] 
		[MaxLength(1)]
		ISet<IfcRelDefinesByType> _ObjectTypeOf = new HashSet<IfcRelDefinesByType>();
	
	
		public IfcTypeObject()
		{
		}
	
		public IfcTypeObject(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._ApplicableOccurrence = __ApplicableOccurrence;
			this._HasPropertySets = new HashSet<IfcPropertySetDefinition>(__HasPropertySets);
		}
	
		[Description("The attribute optionally defines the data type of the occurrence object, to which" +
	    " the assigned type object can relate. If not present, no instruction is given to" +
	    " which occurrence object the type object is applicable.\r\n")]
		public IfcLabel? ApplicableOccurrence { get { return this._ApplicableOccurrence; } set { this._ApplicableOccurrence = value;} }
	
		[Description(@"<EPM-HTML>
	Set <strike>list</strike> of unique property sets, that are associated with the object type and are common to all object occurrences referring to this object type.
	<blockquote><small><font color=""#ff0000"">
	  IFC2x Edition 3 CHANGE&nbsp; The attribute aggregate type has been changed from LIST to SET.
	</font></small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcPropertySetDefinition> HasPropertySets { get { return this._HasPropertySets; } }
	
		[Description("Reference to the relationship IfcRelDefinedByType and thus to those occurrence ob" +
	    "jects, which are defined by this type.")]
		public ISet<IfcRelDefinesByType> ObjectTypeOf { get { return this._ObjectTypeOf; } }
	
	
	}
	
}
