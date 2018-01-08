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
	[Guid("70c2a9af-9e6c-46ee-a672-009025453926")]
	public partial class IfcCableCarrierSegmentType : IfcFlowSegmentType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCableCarrierSegmentTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of cable carrier segment from which " +
	    "the type required may be set.</p></EPM-HTML>")]
		public IfcCableCarrierSegmentTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
