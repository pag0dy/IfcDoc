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
	public partial class IfcRelSequence : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[Description("Reference to the Process, that is the predecessor.  ")]
		[Required()]
		public IfcProcess RelatingProcess { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Reference to the Process, that is the successor.  ")]
		[Required()]
		public IfcProcess RelatedProcess { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Time Duration of the sequence, it is the time lag between the predecessor and the successor as specified by the SequenceType.  ")]
		[Required()]
		public IfcTimeMeasure TimeLag { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The way in which the time lag applies to the sequence.  ")]
		[Required()]
		public IfcSequenceEnum SequenceType { get; set; }
	
	
		public IfcRelSequence(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProcess __RelatingProcess, IfcProcess __RelatedProcess, IfcTimeMeasure __TimeLag, IfcSequenceEnum __SequenceType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingProcess = __RelatingProcess;
			this.RelatedProcess = __RelatedProcess;
			this.TimeLag = __TimeLag;
			this.SequenceType = __SequenceType;
		}
	
	
	}
	
}
