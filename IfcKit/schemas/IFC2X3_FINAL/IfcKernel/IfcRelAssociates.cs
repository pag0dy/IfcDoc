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
	[Guid("4e970c36-e5df-4493-be7d-f85befcc73e3")]
	public partial class IfcRelAssociates : IfcRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcRoot> _RelatedObjects = new HashSet<IfcRoot>();
	
	
		public IfcRelAssociates()
		{
		}
	
		public IfcRelAssociates(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcRoot[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatedObjects = new HashSet<IfcRoot>(__RelatedObjects);
		}
	
		[Description("Objects or Types, to which the external references or information is associated.")]
		public ISet<IfcRoot> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
