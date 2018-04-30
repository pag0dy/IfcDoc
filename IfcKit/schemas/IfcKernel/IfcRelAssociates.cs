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
	public partial class IfcRelAssociates : IfcRelationship
	{
		[DataMember(Order = 0)] 
		[Description("Objects or Types, to which the external references or information is associated.")]
		[Required()]
		[MinLength(1)]
		public ISet<IfcRoot> RelatedObjects { get; protected set; }
	
	
		public IfcRelAssociates(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatedObjects = new HashSet<IfcRoot>(__RelatedObjects);
		}
	
	
	}
	
}
