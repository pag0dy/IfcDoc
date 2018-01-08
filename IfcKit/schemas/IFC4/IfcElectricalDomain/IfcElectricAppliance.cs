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
	[Guid("bc624491-56a2-49ed-bb31-ca4b61c8deb5")]
	public partial class IfcElectricAppliance : IfcFlowTerminal
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcElectricApplianceTypeEnum? _PredefinedType;
	
	
		public IfcElectricApplianceTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
