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
	[Guid("47539a87-e549-4786-85f9-b5b8c8fb705b")]
	public partial class IfcCableCarrierFitting : IfcFlowFitting
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCableCarrierFittingTypeEnum? _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of cable carrier fitting from which " +
	    "the type required may be set.</p></EPM-HTML>")]
		public IfcCableCarrierFittingTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
