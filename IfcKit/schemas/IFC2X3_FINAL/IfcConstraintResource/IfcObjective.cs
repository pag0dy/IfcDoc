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
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("b0794e67-9191-4c55-a93f-70f1d753d31e")]
	public partial class IfcObjective : IfcConstraint
	{
		[DataMember(Order=0)] 
		IfcMetric _BenchmarkValues;
	
		[DataMember(Order=1)] 
		IfcMetric _ResultValues;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcObjectiveEnum _ObjectiveQualifier;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedQualifier;
	
	
		[Description("A list of any benchmark values used for comparison purposes.")]
		public IfcMetric BenchmarkValues { get { return this._BenchmarkValues; } set { this._BenchmarkValues = value;} }
	
		[Description("A list of any resultant values used for comparison purposes.")]
		public IfcMetric ResultValues { get { return this._ResultValues; } set { this._ResultValues = value;} }
	
		[Description("Enumeration that qualifies the type of objective constraint.\r\n")]
		public IfcObjectiveEnum ObjectiveQualifier { get { return this._ObjectiveQualifier; } set { this._ObjectiveQualifier = value;} }
	
		[Description("<EPM-HTML>A user defined value that qualifies the type of objective constraint wh" +
	    "en ObjectiveQualifier attribute of type <I>IfcObjectiveEnum</I> has value USERDE" +
	    "FINED.</EPM-HTML>")]
		public IfcLabel? UserDefinedQualifier { get { return this._UserDefinedQualifier; } set { this._UserDefinedQualifier = value;} }
	
	
	}
	
}
