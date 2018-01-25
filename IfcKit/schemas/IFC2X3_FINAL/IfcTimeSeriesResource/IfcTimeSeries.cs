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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	[Guid("bc1798c5-7055-4819-ae25-b976bd53c66a")]
	public abstract partial class IfcTimeSeries :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[Required()]
		IfcDateTimeSelect _StartTime;
	
		[DataMember(Order=3)] 
		[Required()]
		IfcDateTimeSelect _EndTime;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcTimeSeriesDataTypeEnum _TimeSeriesDataType;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcDataOriginEnum _DataOrigin;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedDataOrigin;
	
		[DataMember(Order=7)] 
		IfcUnit _Unit;
	
		[InverseProperty("ReferencedTimeSeries")] 
		ISet<IfcTimeSeriesReferenceRelationship> _DocumentedBy = new HashSet<IfcTimeSeriesReferenceRelationship>();
	
	
		[Description("An unique name for the time series.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A text description of the data that the series represents.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The start time of a time series.")]
		public IfcDateTimeSelect StartTime { get { return this._StartTime; } set { this._StartTime = value;} }
	
		[Description("The end time of a time series.")]
		public IfcDateTimeSelect EndTime { get { return this._EndTime; } set { this._EndTime = value;} }
	
		[Description("The time series data type.")]
		public IfcTimeSeriesDataTypeEnum TimeSeriesDataType { get { return this._TimeSeriesDataType; } set { this._TimeSeriesDataType = value;} }
	
		[Description("The orgin of a time series data.")]
		public IfcDataOriginEnum DataOrigin { get { return this._DataOrigin; } set { this._DataOrigin = value;} }
	
		[Description("Value of the data origin if DataOrigin attribute is USERDEFINED.")]
		public IfcLabel? UserDefinedDataOrigin { get { return this._UserDefinedDataOrigin; } set { this._UserDefinedDataOrigin = value;} }
	
		[Description(@"<EPM-HTML>
	The unit to be assigned to all values within the time series. Note that mixing units is not allowed. If the value is not given, the global unit for the type of <I>IfcValue</I>, as defined at <I>IfcProject.UnitsInContext</I> is used.
	</EPM-HTML>")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		public ISet<IfcTimeSeriesReferenceRelationship> DocumentedBy { get { return this._DocumentedBy; } }
	
	
	}
	
}
