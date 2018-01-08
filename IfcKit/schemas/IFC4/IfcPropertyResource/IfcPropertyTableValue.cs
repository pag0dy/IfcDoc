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
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcPropertyResource
{
	[Guid("e2eafe97-cfcc-4816-951d-b06cbb579702")]
	public partial class IfcPropertyTableValue : IfcSimpleProperty
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcValue> _DefiningValues = new List<IfcValue>();
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcValue> _DefinedValues = new List<IfcValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcText? _Expression;
	
		[DataMember(Order=3)] 
		IfcUnit _DefiningUnit;
	
		[DataMember(Order=4)] 
		IfcUnit _DefinedUnit;
	
	
		[Description("List of defining values, which determine the defined values.")]
		public IList<IfcValue> DefiningValues { get { return this._DefiningValues; } }
	
		[Description("Defined values which are applicable for the scope as defined by the defining valu" +
	    "es.")]
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
	
	
	}
	
}
