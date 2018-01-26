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
	[Guid("c208d56a-9c19-4967-bdf5-47bb2f46c8f4")]
	public partial class IfcPropertyListValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcValue> _ListValues = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		IfcUnit _Unit;
	
	
		public IfcPropertyListValue()
		{
		}
	
		public IfcPropertyListValue(IfcIdentifier __Name, IfcText? __Description, IfcValue[] __ListValues, IfcUnit __Unit)
			: base(__Name, __Description)
		{
			this._ListValues = new List<IfcValue>(__ListValues);
			this._Unit = __Unit;
		}
	
		[Description("List of values.")]
		public IList<IfcValue> ListValues { get { return this._ListValues; } }
	
		[Description("Unit for the list values, if not given, the default value for the measure type (g" +
	    "iven by the TYPE of nominal value) is used as defined by the global unit assignm" +
	    "ent at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
