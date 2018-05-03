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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	public partial class IfcRelSequence : IfcRelConnects
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("    Reference to the process, that is the predecessor.  ")]
		[Required()]
		public IfcProcess RelatingProcess { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("   Reference to the process, that is the successor.  ")]
		[Required()]
		public IfcProcess RelatedProcess { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("    Time duration of the sequence, it is the time lag between the      predecessor and the successor as specified by the      SequenceType.  ")]
		public IfcLagTime TimeLag { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("     The way in which the time lag applies to the sequence.  ")]
		public IfcSequenceEnum? SequenceType { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("    Allows for specification of user defined type of the sequence      beyond the enumeration values (START_START, START_FINISH,      FINISH_START, FINISH_FINISH) provided by <em>SequenceType</em>      attribute of type <em>IfcSequenceEnum</em>. When a value is      provided for attribute <em>UserDefinedSequenceType</em> in      parallel the attribute <em>SequenceType</em> shall have      enumeration value USERDEFINED.      <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  Attribute added</blockquote>")]
		public IfcLabel? UserDefinedSequenceType { get; set; }
	
	
		public IfcRelSequence(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcProcess __RelatingProcess, IfcProcess __RelatedProcess, IfcLagTime __TimeLag, IfcSequenceEnum? __SequenceType, IfcLabel? __UserDefinedSequenceType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.RelatingProcess = __RelatingProcess;
			this.RelatedProcess = __RelatedProcess;
			this.TimeLag = __TimeLag;
			this.SequenceType = __SequenceType;
			this.UserDefinedSequenceType = __UserDefinedSequenceType;
		}
	
	
	}
	
}
