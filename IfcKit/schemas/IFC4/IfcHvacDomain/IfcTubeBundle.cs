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
	[Guid("082b5dfd-90c2-4db4-bd80-d6f63876cb70")]
	public partial class IfcTubeBundle : IfcEnergyConversionDevice
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcTubeBundleTypeEnum? _PredefinedType;
	
	
		public IfcTubeBundleTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
