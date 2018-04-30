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
	public abstract partial class IfcProcess : IfcObject
	{
		[InverseProperty("RelatingProcess")] 
		[Description("Set of Relationships to objects that are operated on by the process.  ")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get; protected set; }
	
		[InverseProperty("RelatedProcess")] 
		[Description("Relative placement in time, refers to the previous processes for which this process is successor.  ")]
		public ISet<IfcRelSequence> IsSuccessorFrom { get; protected set; }
	
		[InverseProperty("RelatingProcess")] 
		[Description("Relative placement in time, refers to the subsequent processes for which this process is predecessor.  ")]
		public ISet<IfcRelSequence> IsPredecessorTo { get; protected set; }
	
	
		protected IfcProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.OperatesOn = new HashSet<IfcRelAssignsToProcess>();
			this.IsSuccessorFrom = new HashSet<IfcRelSequence>();
			this.IsPredecessorTo = new HashSet<IfcRelSequence>();
		}
	
	
	}
	
}
