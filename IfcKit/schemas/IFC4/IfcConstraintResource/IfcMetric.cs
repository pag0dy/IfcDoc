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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcConstraintResource
{
	[Guid("80e1bafe-6a4a-46c1-9f7d-1c432b1ad3f8")]
	public partial class IfcMetric : IfcConstraint
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcBenchmarkEnum _Benchmark;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _ValueSource;
	
		[DataMember(Order=2)] 
		IfcMetricValueSelect _DataValue;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcReference")]
		IfcReference _ReferencePath;
	
	
		[Description("Enumeration that identifies the type of benchmark data.\r\n")]
		public IfcBenchmarkEnum Benchmark { get { return this._Benchmark; } set { this._Benchmark = value;} }
	
		[Description("Reference source for data values. \r\n\r\nIf <i>DataValue</i> refers to an <i>IfcTabl" +
	    "e</i>, this attribute identifies the relevent column identified by <i>IfcTableCo" +
	    "lumn</i>.<i>Identifier</i>.\r\n")]
		public IfcLabel? ValueSource { get { return this._ValueSource; } set { this._ValueSource = value;} }
	
		[Description("The value to be compared on associated objects. A null value indicates comparison" +
	    " to null.\r\n<blockquote class=\"change-ifc4\">IFC4 ADD1 CHANGE&nbsp;  This attribut" +
	    "e is now optional.</blockquote>\r\n")]
		public IfcMetricValueSelect DataValue { get { return this._DataValue; } set { this._DataValue = value;} }
	
		[Description(@"Optional path to an attribute to be constrained on associated objects.
	If provided, the metric may be validated by resolving the path to the current value on associated object(s), and comparing such value with <i>DataValue</i> according to the <i>Benchmark</i>.")]
		public IfcReference ReferencePath { get { return this._ReferencePath; } set { this._ReferencePath = value;} }
	
	
	}
	
}
