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
	[Guid("21087b7b-8ee5-404b-8c9b-1b17cfc62c90")]
	public partial class IfcElectricDistributionBoard : IfcFlowController
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcElectricDistributionBoardTypeEnum? _PredefinedType;
	
	
		public IfcElectricDistributionBoardTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
