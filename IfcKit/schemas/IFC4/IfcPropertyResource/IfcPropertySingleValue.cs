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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("6283d4e3-23ff-4d09-b4a2-a0fb4f925aed")]
	public partial class IfcPropertySingleValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IfcValue _NominalValue;
	
		[DataMember(Order=1)] 
		IfcUnit _Unit;
	
	
		[Description(@"<EPM-HTML>
	Value and measure type of this property. 
	<blockquote class=""note"">NOTE&nbsp; By virtue of the defined data type, that is selected from the SELECT <em>IfcValue</em>, the appropriate unit can be found within the <em>IfcUnitAssignment</em>, defined for the project if no value for the unit attribute is given.</blockquote>
	<blockquote class=""note"">IFC2x3 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>
	</EPM-HTML>")]
		public IfcValue NominalValue { get { return this._NominalValue; } set { this._NominalValue = value;} }
	
		[Description("Unit for the nominal value, if not given, the default value for the measure type " +
	    "(given by the TYPE of nominal value) is used as defined by the global unit assig" +
	    "nment at IfcProject.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
	
	}
	
}
