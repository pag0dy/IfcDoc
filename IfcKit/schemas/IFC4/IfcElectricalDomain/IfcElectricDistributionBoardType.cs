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
	[Guid("e153e8ad-aea7-4f9a-b6aa-2f143a1c3e18")]
	public partial class IfcElectricDistributionBoardType : IfcFlowControllerType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcElectricDistributionBoardTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of electric distribution type from w" +
	    "hich the type required may be set.</p></EPM-HTML>")]
		public IfcElectricDistributionBoardTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
