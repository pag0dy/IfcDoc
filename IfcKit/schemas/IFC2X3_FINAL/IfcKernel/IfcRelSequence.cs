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
	[Guid("37f1ed31-71b2-4f20-b9f2-4ae22f5b7448")]
	public partial class IfcRelSequence : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcProcess _RelatingProcess;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcProcess _RelatedProcess;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcTimeMeasure _TimeLag;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcSequenceEnum _SequenceType;
	
	
		public IfcRelSequence()
		{
		}
	
		public IfcRelSequence(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProcess __RelatingProcess, IfcProcess __RelatedProcess, IfcTimeMeasure __TimeLag, IfcSequenceEnum __SequenceType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingProcess = __RelatingProcess;
			this._RelatedProcess = __RelatedProcess;
			this._TimeLag = __TimeLag;
			this._SequenceType = __SequenceType;
		}
	
		[Description("Reference to the Process, that is the predecessor.\r\n")]
		public IfcProcess RelatingProcess { get { return this._RelatingProcess; } set { this._RelatingProcess = value;} }
	
		[Description("Reference to the Process, that is the successor.\r\n")]
		public IfcProcess RelatedProcess { get { return this._RelatedProcess; } set { this._RelatedProcess = value;} }
	
		[Description("Time Duration of the sequence, it is the time lag between the predecessor and the" +
	    " successor as specified by the SequenceType.\r\n")]
		public IfcTimeMeasure TimeLag { get { return this._TimeLag; } set { this._TimeLag = value;} }
	
		[Description("The way in which the time lag applies to the sequence.\r\n")]
		public IfcSequenceEnum SequenceType { get { return this._SequenceType; } set { this._SequenceType = value;} }
	
	
	}
	
}
