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
	[Guid("cfc09c9c-67e9-4354-9a3c-87e3d2f14839")]
	public partial class IfcUnitaryControlElement : IfcDistributionControlElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcUnitaryControlElementTypeEnum? _PredefinedType;
	
	
		public IfcUnitaryControlElementTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
