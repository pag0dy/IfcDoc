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

using BuildingSmart.IFC.IfcApprovalResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	public partial class IfcPropertyListValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("List of property values.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		[MinLength(1)]
		public IList<IfcValue> ListValues { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("Unit for the list values, if not given, the default value for the measure type (given by the TYPE of nominal value) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit Unit { get; set; }
	
	
		public IfcPropertyListValue(IfcIdentifier __Name, IfcText? __Description, IfcValue[] __ListValues, IfcUnit __Unit)
			: base(__Name, __Description)
		{
			this.ListValues = new List<IfcValue>(__ListValues);
			this.Unit = __Unit;
		}
	
	
	}
	
}
