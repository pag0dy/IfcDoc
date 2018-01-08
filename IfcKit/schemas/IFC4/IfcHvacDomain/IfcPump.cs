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
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("da626cac-98fb-4f4c-8d4a-c8c4bac3a68d")]
	public partial class IfcPump : IfcFlowMovingDevice
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPumpTypeEnum? _PredefinedType;
	
	
		public IfcPumpTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
