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
using BuildingSmart.IFC.IfcApprovalResource;
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
	[Guid("e3c26a8d-a8eb-45a1-ae3b-cf89be51902e")]
	public partial class IfcPropertyTableValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		IList<IfcValue> _DefiningValues = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		IList<IfcValue> _DefinedValues = new List<IfcValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Expression;
	
		[DataMember(Order=3)] 
		IfcUnit _DefiningUnit;
	
		[DataMember(Order=4)] 
		IfcUnit _DefinedUnit;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcCurveInterpolationEnum? _CurveInterpolation;
	
	
		[Description("List of defining values, which determine the defined values. This list shall have" +
	    " unique values only.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The at" +
	    "tribute has been made optional with upward compatibility for file based exchange" +
	    ".</blockquote>")]
		public IList<IfcValue> DefiningValues { get { return this._DefiningValues; } }
	
		[Description("Defined values which are applicable for the scope as defined by the defining valu" +
	    "es.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been " +
	    "made optional with upward compatibility for file based exchange.</blockquote>")]
		public IList<IfcValue> DefinedValues { get { return this._DefinedValues; } }
	
		[Description("Expression for the derivation of defined values from the defining values, the exp" +
	    "ression is given for information only, i.e. no automatic processing can be expec" +
	    "ted from the expression.")]
		public IfcText? Expression { get { return this._Expression; } set { this._Expression = value;} }
	
		[Description("Unit for the defining values, if not given, the default value for the measure typ" +
	    "e (given by the TYPE of the defining values) is used as defined by the global un" +
	    "it assignment at IfcProject.")]
		public IfcUnit DefiningUnit { get { return this._DefiningUnit; } set { this._DefiningUnit = value;} }
	
		[Description("Unit for the defined values, if not given, the default value for the measure type" +
	    " (given by the TYPE of the defined values) is used as defined by the global unit" +
	    " assignment at IfcProject.")]
		public IfcUnit DefinedUnit { get { return this._DefinedUnit; } set { this._DefinedUnit = value;} }
	
		[Description(@"Interpolation of the curve between two defining and defined values that are provided. if not provided a linear interpolation is assumed.
	<blockquote class=""change-ifc2x4"">IFC4 CHANGE&nbsp; The attribute has been added at the end of the attribute list.</blockquote>")]
		public IfcCurveInterpolationEnum? CurveInterpolation { get { return this._CurveInterpolation; } set { this._CurveInterpolation = value;} }
	
	
	}
	
}
