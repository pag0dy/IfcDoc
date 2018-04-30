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
	public partial class IfcPropertyTableValue : IfcSimpleProperty
	{
		[DataMember(Order = 0)] 
		[Description("List of defining values, which determine the defined values. This list shall have unique values only.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		[MinLength(1)]
		public IList<IfcValue> DefiningValues { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("Defined values which are applicable for the scope as defined by the defining values.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been made optional with upward compatibility for file based exchange.</blockquote>")]
		[MinLength(1)]
		public IList<IfcValue> DefinedValues { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Expression for the derivation of defined values from the defining values, the expression is given for information only, i.e. no automatic processing can be expected from the expression.")]
		public IfcText? Expression { get; set; }
	
		[DataMember(Order = 3)] 
		[Description("Unit for the defining values, if not given, the default value for the measure type (given by the TYPE of the defining values) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit DefiningUnit { get; set; }
	
		[DataMember(Order = 4)] 
		[Description("Unit for the defined values, if not given, the default value for the measure type (given by the TYPE of the defined values) is used as defined by the global unit assignment at IfcProject.")]
		public IfcUnit DefinedUnit { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Interpolation of the curve between two defining and defined values that are provided. if not provided a linear interpolation is assumed.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; The attribute has been added at the end of the attribute list.</blockquote>")]
		public IfcCurveInterpolationEnum? CurveInterpolation { get; set; }
	
	
		public IfcPropertyTableValue(IfcIdentifier __Name, IfcText? __Description, IfcValue[] __DefiningValues, IfcValue[] __DefinedValues, IfcText? __Expression, IfcUnit __DefiningUnit, IfcUnit __DefinedUnit, IfcCurveInterpolationEnum? __CurveInterpolation)
			: base(__Name, __Description)
		{
			this.DefiningValues = new List<IfcValue>(__DefiningValues);
			this.DefinedValues = new List<IfcValue>(__DefinedValues);
			this.Expression = __Expression;
			this.DefiningUnit = __DefiningUnit;
			this.DefinedUnit = __DefinedUnit;
			this.CurveInterpolation = __CurveInterpolation;
		}
	
	
	}
	
}
