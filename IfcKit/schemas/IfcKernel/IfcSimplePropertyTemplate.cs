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
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcKernel
{
	public partial class IfcSimplePropertyTemplate : IfcPropertyTemplate
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Property type defining whether the property template defines a property with a single value, a bounded value, a list value, a table value, an enumerated value, or a reference value. Or the quantity type defining whether the template defines a quantity with a length, area, volume, weight or time value.  <blockquote class=\"note\">NOTE&nbsp; the value of this property determines the correct use of the <em>PrimaryUnit</em>, <em>SecondaryUnit</em>, <em>PrimaryDataType</em>, <em>SecondaryDataType</em>, and <em>Expression</em> attributes.</blockquote>")]
		public IfcSimplePropertyTemplateTypeEnum? TemplateType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Primary measure type assigned to the definition of the property. It should be provided, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_SINGLEVALUE</small>: determining the measure type of <em>IfcPropertySingleValue.NominalValue</em></li>  <li><small>P_ENUMERATEDVALUE</small>: determining the measure type of <em>IfcPropertyEnumeratedValue.EnumerationValues</em></li>  <li><small>P_BOUNDEDVALUE</small>: determining the measure type of <em>IfcPropertyBoundedValue.LowerBoundValue</em></li>  <li><small>P_LISTVALUE</small>: determining the measure type of <em>IfcPropertyListValue.ListValues</em></li>  <li><small>P_TABLEVALUE</small>: determining the measure type of <em>IfcPropertyTableValue.DefiningValues</em></li>  <li><small>P_REFERENCEVALUE</small>: determining the measure type of <em>IfcPropertyTableValue.PropertyReference</em></li></ul>  <blockquote class=\"note\">NOTE&nbsp; The value range of the measure type is within the select type <em>IfcValue</em> for all <em>PropertyType</em>'s with the exeption of <small>P_REFERENCEVALUE</small>. Here it is within the select type <em>IfcObjectReferenceSelect</em>.</blockquote>")]
		public IfcLabel? PrimaryMeasureType { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Secondary measure type assigned to the definition of the property. It should be provided, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_BOUNDEDVALUE</small>: determining the measure type of <em>IfcPropertyBoundedValue.UpperBoundValue</em></li>  <li><small>P_TABLEVALUE</small>: determining the measure type of <em>IfcPropertyTableValue.DefinedValues</em></li>  </ul>  The value range of the measure type is within the select type <em>IfcValue</em>  for all <em>PropertyType</em>'s with the exeption of <small>P_ENUMERATEDVALUE</small>. Here it is the comma delimited list of enumerators.  <blockquote class=\"note\">      NOTE&nbsp; The measure type of <em>IfcPropertyEnumeration.EnumerationValues</em> is provided as <em>PrimaryDataType</em>.  </blockquote>")]
		public IfcLabel? SecondaryMeasureType { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlElement]
		[Description("Name of the property enumeration, and list of all valid enumerators being selectable values, assigned to the definition of the property.   This attribute shall only be provided, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_ENUMERATEDVALUE</small></li>  </ul>")]
		public IfcPropertyEnumeration Enumerators { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Primary unit assigned to the definition of the property. It should be provided, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_SINGLEVALUE</small>: determining the <em>IfcPropertySingleValue.Unit</em></li>  <li><small>P_ENUMERATEDVALUE</small>: determining the <em>IfcPropertyEnumeration.Unit</em></li>  <li><small>P_BOUNDEDVALUE</small>: determining the <em>IfcPropertyBoundedValue.Unit</em></li>  <li><small>P_LISTVALUE</small>: determining the <em>IfcPropertyListValue.Unit</em></li>  <li><small>P_TABLEVALUE</small>: determining the <em>IfcPropertyTableValue.DefiningUnit</em></li>  </ul>")]
		public IfcUnit PrimaryUnit { get; set; }
	
		[DataMember(Order = 5)] 
		[Description("Secondary unit assigned to the definition of the property. It should be provided, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_TABLEVALUE</small>: determining the <em>IfcPropertyTableValue.DefinedUnit</em></li>  </ul>")]
		public IfcUnit SecondaryUnit { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("The expression used to store additional information for the property template depending on the <em>PropertyType</em>. It should the following definitions, if the <em>PropertyType</em> is set to:  <ul>  <li><small>P_TABLEVALUE</small>: the expression that could be evaluated to define the correlation between the defining values and the defined values.</li>  <li><small>Q_LENGTH, Q_AREA, Q_VOLUME, Q_COUNT, Q_WEIGTH, Q_TIME</small>: the formula to be used to calculate the quantity</li>  </ul>  <blockquote class=\"note\">NOTE&nbsp; No value shall be asserted if the <em>PropertyType</em> is not listed above.</blockquote>")]
		public IfcLabel? Expression { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Information about the access state of the property. It determines whether a property be viewed and/or modified by any receiving application without specific knowledge of it. <br><br>  <b>Attribute use definition for <em>IfcStateEnum</em></b>    <ul>  <li>READWRITE: Properties of this template are readable and writable. They may be viewed and modified by users of any application. These are typical informational properties set by a user.</li>    <li>READONLY: Properties of this template are read-only. They may be viewed but not modified by users of any application. (Applications may generate such values). These are typical automatically generated properties that should be displayed only, but not written back.</li>    <li>LOCKED: Properties of this template are locked. They may only be accessed by the owning application (the publisher of the property set template). These are typically application depended, internal properties that should not be published.</li>    <li>READWRITELOCKED: Properties of this template are locked, readable, and writable. They may only be accessed by the owning application.</li>    <li>READONLYLOCKED: Properties of this template are locked and read-only. They may only be accessed by the owning application. </li>    </ul>")]
		public IfcStateEnum? AccessState { get; set; }
	
	
		public IfcSimplePropertyTemplate(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSimplePropertyTemplateTypeEnum? __TemplateType, IfcLabel? __PrimaryMeasureType, IfcLabel? __SecondaryMeasureType, IfcPropertyEnumeration __Enumerators, IfcUnit __PrimaryUnit, IfcUnit __SecondaryUnit, IfcLabel? __Expression, IfcStateEnum? __AccessState)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this.TemplateType = __TemplateType;
			this.PrimaryMeasureType = __PrimaryMeasureType;
			this.SecondaryMeasureType = __SecondaryMeasureType;
			this.Enumerators = __Enumerators;
			this.PrimaryUnit = __PrimaryUnit;
			this.SecondaryUnit = __SecondaryUnit;
			this.Expression = __Expression;
			this.AccessState = __AccessState;
		}
	
	
	}
	
}
