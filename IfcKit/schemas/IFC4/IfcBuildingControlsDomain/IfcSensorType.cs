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
	[Guid("a5b36357-2503-452f-8599-ce8a92a3ec72")]
	public partial class IfcSensorType : IfcDistributionControlElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcSensorTypeEnum _PredefinedType;
	
	
		[Description("<EPM-HTML><p>Identifies the predefined types of sensor from which the type requir" +
	    "ed may be set.</p></EPM-HTML>")]
		public IfcSensorTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
