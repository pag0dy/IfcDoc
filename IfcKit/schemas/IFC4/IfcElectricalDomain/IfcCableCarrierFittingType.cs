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
	[Guid("fd9b5bec-e42a-4c5e-bc8a-bd72ae76b43a")]
	public partial class IfcCableCarrierFittingType : IfcFlowFittingType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcCableCarrierFittingTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of cable carrier fitting from which " +
	    "the type required may be set.</p></EPM-HTML>")]
		public IfcCableCarrierFittingTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
