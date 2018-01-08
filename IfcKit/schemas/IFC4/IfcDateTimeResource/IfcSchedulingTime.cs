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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("b80d3213-eccf-4e8a-84a3-21c1381ff3cc")]
	public abstract partial class IfcSchedulingTime
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcDataOriginEnum? _DataOrigin;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedDataOrigin;
	
	
		[Description("<EPM-HTML>\r\n    Optional name for the time definition. \r\n</EPM-HTML>")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("<EPM-HTML>\r\n    Specifies the origin of the scheduling time entity. It currently\r" +
	    "\n    differentiates between predicted, simulated, measured, and user defined val" +
	    "ues.\r\n</EPM-HTML>")]
		public IfcDataOriginEnum? DataOrigin { get { return this._DataOrigin; } set { this._DataOrigin = value;} }
	
		[Description("Value of the data origin if DataOrigin attribute is USERDEFINED.")]
		public IfcLabel? UserDefinedDataOrigin { get { return this._UserDefinedDataOrigin; } set { this._UserDefinedDataOrigin = value;} }
	
	
	}
	
}
