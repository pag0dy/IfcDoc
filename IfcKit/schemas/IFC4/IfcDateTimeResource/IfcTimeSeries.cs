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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("4aa23b8c-0acf-4202-9d27-29abd09009e1")]
	public abstract partial class IfcTimeSeries :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcDateTime _StartTime;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcDateTime _EndTime;
	
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
	
		[InverseProperty("RelatedResourceObjects")] 
		ISet<IfcExternalReferenceRelationship> _HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
	
	
		[Description("An unique name for the time series.")]
		public IfcLabel Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A text description of the data that the series represents.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
		[Description("The start time of a time series.")]
		public IfcDateTime StartTime { get { return this._StartTime; } set { this._StartTime = value;} }
	
		[Description("The end time of a time series.")]
		public IfcDateTime EndTime { get { return this._EndTime; } set { this._EndTime = value;} }
	
		[Description("The time series data type.")]
		public IfcTimeSeriesDataTypeEnum TimeSeriesDataType { get { return this._TimeSeriesDataType; } set { this._TimeSeriesDataType = value;} }
	
		[Description("The origin of a time series data.")]
		public IfcDataOriginEnum DataOrigin { get { return this._DataOrigin; } set { this._DataOrigin = value;} }
	
		[Description("Value of the data origin if DataOrigin attribute is USERDEFINED.")]
		public IfcLabel? UserDefinedDataOrigin { get { return this._UserDefinedDataOrigin; } set { this._UserDefinedDataOrigin = value;} }
	
		[Description("The unit to be assigned to all values within the time series. Note that mixing un" +
	    "its is not allowed. If the value is not given, the global unit for the type of <" +
	    "em>IfcValue</em>, as defined at <em>IfcProject.UnitsInContext</em> is used.")]
		public IfcUnit Unit { get { return this._Unit; } set { this._Unit = value;} }
	
		[Description("Reference to an external reference, e.g. library, classification, or document inf" +
	    "ormation, that is associated to the IfcTimeSeries. \r\n<blockquote class=\"change-i" +
	    "fc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>  \r\n")]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get { return this._HasExternalReference; } }
	
	
	}
	
}
