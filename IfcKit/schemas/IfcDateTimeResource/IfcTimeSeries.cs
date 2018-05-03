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

using BuildingSmart.IFC.IfcConstraintResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	public abstract partial class IfcTimeSeries :
		BuildingSmart.IFC.IfcConstraintResource.IfcMetricValueSelect,
		BuildingSmart.IFC.IfcPropertyResource.IfcObjectReferenceSelect,
		BuildingSmart.IFC.IfcExternalReferenceResource.IfcResourceObjectSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("An unique name for the time series.")]
		[Required()]
		public IfcLabel Name { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("A text description of the data that the series represents.")]
		public IfcText? Description { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The start time of a time series.")]
		[Required()]
		public IfcDateTime StartTime { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The end time of a time series.")]
		[Required()]
		public IfcDateTime EndTime { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The time series data type.")]
		[Required()]
		public IfcTimeSeriesDataTypeEnum TimeSeriesDataType { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("The origin of a time series data.")]
		[Required()]
		public IfcDataOriginEnum DataOrigin { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Value of the data origin if DataOrigin attribute is USERDEFINED.")]
		public IfcLabel? UserDefinedDataOrigin { get; set; }
	
		[DataMember(Order = 7)] 
		[Description("The unit to be assigned to all values within the time series. Note that mixing units is not allowed. If the value is not given, the global unit for the type of <em>IfcValue</em>, as defined at <em>IfcProject.UnitsInContext</em> is used.")]
		public IfcUnit Unit { get; set; }
	
		[InverseProperty("RelatedResourceObjects")] 
		[Description("Reference to an external reference, e.g. library, classification, or document information, that is associated to the IfcTimeSeries.   <blockquote class=\"change-ifc2x4\">IFC4 CHANGE New inverse attribute.</blockquote>    ")]
		[MinLength(1)]
		public ISet<IfcExternalReferenceRelationship> HasExternalReference { get; protected set; }
	
	
		protected IfcTimeSeries(IfcLabel __Name, IfcText? __Description, IfcDateTime __StartTime, IfcDateTime __EndTime, IfcTimeSeriesDataTypeEnum __TimeSeriesDataType, IfcDataOriginEnum __DataOrigin, IfcLabel? __UserDefinedDataOrigin, IfcUnit __Unit)
		{
			this.Name = __Name;
			this.Description = __Description;
			this.StartTime = __StartTime;
			this.EndTime = __EndTime;
			this.TimeSeriesDataType = __TimeSeriesDataType;
			this.DataOrigin = __DataOrigin;
			this.UserDefinedDataOrigin = __UserDefinedDataOrigin;
			this.Unit = __Unit;
			this.HasExternalReference = new HashSet<IfcExternalReferenceRelationship>();
		}
	
	
	}
	
}
