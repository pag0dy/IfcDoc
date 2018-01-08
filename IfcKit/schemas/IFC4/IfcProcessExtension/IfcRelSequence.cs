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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("99cd2ac0-7e3f-4393-bf5a-fbd991bf194b")]
	public partial class IfcRelSequence : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcProcess")]
		[Required()]
		IfcProcess _RelatingProcess;
	
		[DataMember(Order=1)] 
		[XmlElement("IfcProcess")]
		[Required()]
		IfcProcess _RelatedProcess;
	
		[DataMember(Order=2)] 
		[XmlElement("IfcLagTime")]
		IfcLagTime _TimeLag;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcSequenceEnum? _SequenceType;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedSequenceType;
	
	
		[Description("    Reference to the process, that is the predecessor.\r\n")]
		public IfcProcess RelatingProcess { get { return this._RelatingProcess; } set { this._RelatingProcess = value;} }
	
		[Description("   Reference to the process, that is the successor.\r\n")]
		public IfcProcess RelatedProcess { get { return this._RelatedProcess; } set { this._RelatedProcess = value;} }
	
		[Description("    Time duration of the sequence, it is the time lag between the\r\n    predecesso" +
	    "r and the successor as specified by the\r\n    SequenceType.\r\n")]
		public IfcLagTime TimeLag { get { return this._TimeLag; } set { this._TimeLag = value;} }
	
		[Description("     The way in which the time lag applies to the sequence.\r\n")]
		public IfcSequenceEnum? SequenceType { get { return this._SequenceType; } set { this._SequenceType = value;} }
	
		[Description(@"    Allows for specification of user defined type of the sequence
	    beyond the enumeration values (START_START, START_FINISH,
	    FINISH_START, FINISH_FINISH) provided by <em>SequenceType</em>
	    attribute of type <em>IfcSequenceEnum</em>. When a value is
	    provided for attribute <em>UserDefinedSequenceType</em> in
	    parallel the attribute <em>SequenceType</em> shall have
	    enumeration value USERDEFINED.
	    <blockquote class=""change-ifc2x4"">IFC4 CHANGE  Attribute added</blockquote>")]
		public IfcLabel? UserDefinedSequenceType { get { return this._UserDefinedSequenceType; } set { this._UserDefinedSequenceType = value;} }
	
	
	}
	
}
