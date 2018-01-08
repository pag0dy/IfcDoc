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
	[Guid("00254f70-e0ef-4d79-91de-eade9f1c10c5")]
	public partial class IfcEvaporativeCooler : IfcEnergyConversionDevice
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcEvaporativeCoolerTypeEnum? _PredefinedType;
	
	
		public IfcEvaporativeCoolerTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
