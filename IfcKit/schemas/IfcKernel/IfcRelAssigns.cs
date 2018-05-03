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
	public abstract partial class IfcRelAssigns : IfcRelationship
	{
		[DataMember(Order = 0)] 
		[Description("Related objects, which are assigned to a single object. The type of the single (or relating) object is defined in the subtypes of IfcRelAssigns.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcObjectDefinition> RelatedObjects { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Particular type of the assignment relationship. It can constrain the applicable object types, used within the role of <em>RelatedObjects</em>.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute is deprecated and shall no longer be used. A NIL value should always be assigned.</blockquote>")]
		public IfcObjectTypeEnum? RelatedObjectsType { get; set; }
	
	
		protected IfcRelAssigns(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition[] __RelatedObjects, IfcObjectTypeEnum? __RelatedObjectsType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatedObjects = new HashSet<IfcObjectDefinition>(__RelatedObjects);
			this.RelatedObjectsType = __RelatedObjectsType;
		}
	
	
	}
	
}
