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

using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("cbe43c1f-9ddd-4279-bb40-699045a1e748")]
	public partial class IfcCableCarrierSegment : IfcFlowSegment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCableCarrierSegmentTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of cable carrier segment from which " +
	    "the type required may be set.</p></EPM-HTML>")]
		public IfcCableCarrierSegmentTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
