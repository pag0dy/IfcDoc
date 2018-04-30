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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyEnumeration : IfcPropertyAbstraction
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Name of this enumeration.")]
		[Required()]
		[CustomValidation(typeof(IfcPropertyEnumeration), "Unique")]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("List of values that form the enumeration.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcValue> EnumerationValues { get; protected set; }
	
		[DataMember(Order = 2)] 
		[Description("Unit for the enumerator values, if not given, the default value for the measure type (given by the TYPE of nominal value) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit Unit { get; set; }
	
	
		public IfcPropertyEnumeration(IfcLabel __Name, IfcValue[] __EnumerationValues, IfcUnit __Unit)
		{
			this.Name = __Name;
			this.EnumerationValues = new List<IfcValue>(__EnumerationValues);
			this.Unit = __Unit;
		}
	
	
	}
	
}
