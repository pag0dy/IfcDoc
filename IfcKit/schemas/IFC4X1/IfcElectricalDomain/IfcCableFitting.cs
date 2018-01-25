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
	[Guid("a981fcc0-253f-4511-8e27-f490e28f4ada")]
	public partial class IfcCableFitting : IfcFlowFitting
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcCableFittingTypeEnum? _PredefinedType;
	
	
		[Description("<p>Identifies the predefined types of cable fitting from which the type required " +
	    "may be set.</p>")]
		public IfcCableFittingTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
