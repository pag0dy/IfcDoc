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
	public abstract partial class IfcRelDecomposes : IfcRelationship
	{
		[DataMember(Order = 0)] 
		[Description("The object that represents the nest or aggregation.  ")]
		[Required()]
		public IfcObjectDefinition RelatingObject { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The objects being nested or aggregated.  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcObjectDefinition> RelatedObjects { get; protected set; }
	
	
		protected IfcRelDecomposes(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition __RelatingObject, IfcObjectDefinition[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingObject = __RelatingObject;
			this.RelatedObjects = new HashSet<IfcObjectDefinition>(__RelatedObjects);
		}
	
	
	}
	
}
