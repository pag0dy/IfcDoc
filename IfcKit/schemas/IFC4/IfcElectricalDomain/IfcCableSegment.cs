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
	[Guid("a16f4db3-e5ef-49a6-98e0-f7c2116a5580")]
	public partial class IfcCableSegment : IfcFlowSegment
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCableSegmentTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of cable segment from which the type" +
	    " required may be set.</p></EPM-HTML>")]
		public IfcCableSegmentTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
