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
	[Guid("411d5533-5833-44cd-9be0-a1e9d468c8fb")]
	public abstract partial class IfcProcess : IfcObject
	{
		[InverseProperty("RelatingProcess")] 
		ISet<IfcRelAssignsToProcess> _OperatesOn = new HashSet<IfcRelAssignsToProcess>();
	
		[InverseProperty("RelatedProcess")] 
		ISet<IfcRelSequence> _IsSuccessorFrom = new HashSet<IfcRelSequence>();
	
		[InverseProperty("RelatingProcess")] 
		ISet<IfcRelSequence> _IsPredecessorTo = new HashSet<IfcRelSequence>();
	
	
		public IfcProcess()
		{
		}
	
		public IfcProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
		}
	
		[Description("Set of Relationships to objects that are operated on by the process.\r\n")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get { return this._OperatesOn; } }
	
		[Description("Relative placement in time, refers to the previous processes for which this proce" +
	    "ss is successor.\r\n")]
		public ISet<IfcRelSequence> IsSuccessorFrom { get { return this._IsSuccessorFrom; } }
	
		[Description("Relative placement in time, refers to the subsequent processes for which this pro" +
	    "cess is predecessor.\r\n")]
		public ISet<IfcRelSequence> IsPredecessorTo { get { return this._IsPredecessorTo; } }
	
	
	}
	
}
