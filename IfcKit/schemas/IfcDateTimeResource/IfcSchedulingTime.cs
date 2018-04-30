// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public abstract partial class IfcSchedulingTime
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("    Optional name for the time definition. ")]
		public IfcLabel? Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("    Specifies the origin of the scheduling time entity. It currently      differentiates between predicted, simulated, measured, and user defined values.")]
		public IfcDataOriginEnum? DataOrigin { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Value of the data origin if DataOrigin attribute is USERDEFINED.")]
		public IfcLabel? UserDefinedDataOrigin { get; set; }
	
	
		protected IfcSchedulingTime(IfcLabel? __Name, IfcDataOriginEnum? __DataOrigin, IfcLabel? __UserDefinedDataOrigin)
		{
			this.Name = __Name;
			this.DataOrigin = __DataOrigin;
			this.UserDefinedDataOrigin = __UserDefinedDataOrigin;
		}
	
	
	}
	
}
