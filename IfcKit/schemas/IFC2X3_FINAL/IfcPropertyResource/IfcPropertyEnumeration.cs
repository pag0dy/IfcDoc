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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("b0a8d959-6be7-4b37-8bd8-74c971669777")]
	public partial class IfcPropertyEnumeration
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcValue> _EnumerationValues = new List<IfcValue>();
	
		[DataMember(Order=2)] 
		IfcUnit _Unit;
	
	
		public IfcPropertyEnumeration()
		{
		}
	
		public IfcPropertyEnumeration(IfcLabel __Name, IfcValue[] __EnumerationValues, IfcUnit __Unit)
		{
			this._Name = __Name;
			this._EnumerationValues = new List<IfcValue>(__EnumerationValues);
			this._Unit = __Unit;
		}
	
		[Description("Name of this enumeration.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("List of values that form the enumeration.")]
		public IList<IfcValue> EnumerationValues { get { return this._EnumerationValues; } }
	
		[Description("Unit for the enumerator values, if not given, the default value for the measure t" +
	    "ype (given by the TYPE of nominal value) is used as defined by the global unit a" +
	    "ssignment at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
