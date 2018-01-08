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
	[Guid("d3bb6ca8-fe8d-4d85-a6a2-319d9ca0ca47")]
	public partial class IfcOutletType : IfcFlowTerminalType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcOutletTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of outlet from which the type requir" +
	    "ed may be set.</p></EPM-HTML>")]
		public IfcOutletTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
