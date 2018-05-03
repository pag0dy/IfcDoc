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
	public partial class IfcPropertySingleValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("Value and measure type of this property.   <blockquote class=\"note\">NOTE&nbsp; By virtue of the defined data type, that is selected from the SELECT <em>IfcValue</em>, the appropriate unit can be found within the <em>IfcUnitAssignment</em>, defined for the project if no value for the unit attribute is given.</blockquote>  <blockquote class=\"note\">IFC2x3 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		public IfcValue NominalValue { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Unit for the nominal value, if not given, the default value for the measure type (given by the TYPE of nominal value) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit Unit { get; set; }
	
	
		public IfcPropertySingleValue(IfcIdentifier __Name, IfcText? __Description, IfcValue __NominalValue, IfcUnit __Unit)
			: base(__Name, __Description)
		{
			this.NominalValue = __NominalValue;
			this.Unit = __Unit;
		}
	
	
	}
	
}
