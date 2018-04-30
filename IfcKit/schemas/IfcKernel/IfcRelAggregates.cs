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
	public partial class IfcRelAggregates : IfcRelDecomposes
	{
		[DataMember(Order = 0)] 
		[XmlIgnore]
		[Description("The object definition, either an object type or an object occurrence, that represents the aggregation. It is the whole within the whole/part relationship.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the non-ordered aggregation relationship.</blockquote>")]
		[Required()]
		public IfcObjectDefinition RelatingObject { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The object definitions, either object occurrences or object types, that are being aggregated. They are defined as the parts in the whole/part relationship. No order is implied between the parts.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been demoted from the supertype <em>IfcRelDecomposes</em> and defines the non-ordered set of parts within the aggregation.</blockquote>  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcObjectDefinition> RelatedObjects { get; protected set; }
	
	
		public IfcRelAggregates(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition __RelatingObject, IfcObjectDefinition[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingObject = __RelatingObject;
			this.RelatedObjects = new HashSet<IfcObjectDefinition>(__RelatedObjects);
		}
	
	
	}
	
}
