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
	[Guid("4a3a5141-fc1b-450b-8bdd-ce1d2ce53d85")]
	public abstract partial class IfcRelDecomposes : IfcRelationship
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcObjectDefinition _RelatingObject;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcObjectDefinition> _RelatedObjects = new HashSet<IfcObjectDefinition>();
	
	
		public IfcRelDecomposes()
		{
		}
	
		public IfcRelDecomposes(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcObjectDefinition __RelatingObject, IfcObjectDefinition[] __RelatedObjects)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingObject = __RelatingObject;
			this._RelatedObjects = new HashSet<IfcObjectDefinition>(__RelatedObjects);
		}
	
		[Description("The object that represents the nest or aggregation.\r\n")]
		public IfcObjectDefinition RelatingObject { get { return this._RelatingObject; } set { this._RelatingObject = value;} }
	
		[Description("The objects being nested or aggregated.\r\n")]
		public ISet<IfcObjectDefinition> RelatedObjects { get { return this._RelatedObjects; } }
	
	
	}
	
}
