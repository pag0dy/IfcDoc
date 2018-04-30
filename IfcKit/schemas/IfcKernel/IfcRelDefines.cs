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
	public abstract partial class IfcRelDefines : IfcRelationship
	{
		[DataMember(Order = 0)] 
		[Description("Reference to the objects (or single object) to which the property definition applies.  ")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcObject> RelatedObjects { get; protected set; }
	
	
		protected IfcRelDefines(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObject[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatedObjects = new HashSet<IfcObject>(__RelatedObjects);
		}
	
	
	}
	
}
