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
	[Guid("9022a034-602f-4405-bb14-2e18d8a865db")]
	public partial class IfcElectricFlowStorageDeviceType : IfcFlowStorageDeviceType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcElectricFlowStorageDeviceTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of electric flow storage devices fro" +
	    "m which the type required may be set.</p></EPM-HTML>")]
		public IfcElectricFlowStorageDeviceTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
