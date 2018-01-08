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
	[Guid("67624ad3-5d2e-4f19-abe4-c8abfa34fd54")]
	public partial class IfcFlowInstrument : IfcDistributionControlElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcFlowInstrumentTypeEnum? _PredefinedType;
	
	
		public IfcFlowInstrumentTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
