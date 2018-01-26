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
	[Guid("50e72608-2b70-4951-afa7-68d8cf130d15")]
	public abstract partial class IfcRelAssociates : IfcRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcDefinitionSelect> _RelatedObjects = new HashSet<IfcDefinitionSelect>();
	
	
		public IfcRelAssociates()
		{
		}
	
		public IfcRelAssociates(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcDefinitionSelect[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedObjects = new HashSet<IfcDefinitionSelect>(__RelatedObjects);
		}
	
		[Description(@"Set of object or property definitions to which the external references or information is associated. It includes object and type objects, property set templates, property templates and property sets and contexts.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute datatype has been changed from <em>IfcRoot</em> to <em>IfcDefinitionSelect</em>.</blockquote>")]
		public ISet<IfcDefinitionSelect> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
