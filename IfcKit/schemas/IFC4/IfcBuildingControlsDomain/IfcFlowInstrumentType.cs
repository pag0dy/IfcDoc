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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("92253df9-2c74-4a77-9837-72f4f240f459")]
	public partial class IfcFlowInstrumentType : IfcDistributionControlElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcFlowInstrumentTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of flow instrument from which the ty" +
	    "pe required may be set.</p></EPM-HTML>")]
		public IfcFlowInstrumentTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
