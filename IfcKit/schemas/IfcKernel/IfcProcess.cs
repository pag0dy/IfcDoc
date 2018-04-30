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
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public abstract partial class IfcProcess : IfcObject,
		BuildingSmart.IFC.IfcKernel.IfcProcessSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("    An identifying designation given to a process or activity.      It is the identifier at the occurrence level.       <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attribute promoted from subtypes.</blockquote>")]
		public IfcIdentifier? Identification { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("An extended description or narrative that may be provided.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; New attribute.</blockquote>")]
		public IfcText? LongDescription { get; set; }
	
		[InverseProperty("RelatingProcess")] 
		[Description("Dependency between two activities, it refers to the subsequent activity for which this activity is the predecessor. The link between two activities can include a link type and a lag time. ")]
		public ISet<IfcRelSequence> IsPredecessorTo { get; protected set; }
	
		[InverseProperty("RelatedProcess")] 
		[Description("Dependency between two activities, it refers to the previous activity for which this activity is the successor. The link between two activities can include a link type and a lag time. ")]
		public ISet<IfcRelSequence> IsSuccessorFrom { get; protected set; }
	
		[InverseProperty("RelatingProcess")] 
		[Description("Set of relationships to other objects, e.g. products, processes, controls, resources or actors, that are operated on by the process.")]
		public ISet<IfcRelAssignsToProcess> OperatesOn { get; protected set; }
	
	
		protected IfcProcess(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.Identification = __Identification;
			this.LongDescription = __LongDescription;
			this.IsPredecessorTo = new HashSet<IfcRelSequence>();
			this.IsSuccessorFrom = new HashSet<IfcRelSequence>();
			this.OperatesOn = new HashSet<IfcRelAssignsToProcess>();
		}
	
	
	}
	
}
