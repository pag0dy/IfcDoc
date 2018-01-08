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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("414eeb02-3011-42cf-96ea-f319b3328e17")]
	public abstract partial class IfcWorkControl : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcIdentifier _Identifier;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcDateTimeSelect _CreationDate;
	
		[DataMember(Order=2)] 
		ISet<IfcPerson> _Creators = new HashSet<IfcPerson>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _Purpose;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcTimeMeasure? _Duration;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcTimeMeasure? _TotalFloat;
	
		[DataMember(Order=6)] 
		[Required()]
		IfcDateTimeSelect _StartTime;
	
		[DataMember(Order=7)] 
		IfcDateTimeSelect _FinishTime;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcWorkControlTypeEnum? _WorkControlType;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedControlType;
	
	
		[Description("Identifier of the work plan, given by user.\r\n")]
		public IfcIdentifier Identifier { get { return this._Identifier; } set { this._Identifier = value;} }
	
		[Description("The date that the plan is created.")]
		public IfcDateTimeSelect CreationDate { get { return this._CreationDate; } set { this._CreationDate = value;} }
	
		[Description("The authors of the work plan.")]
		public ISet<IfcPerson> Creators { get { return this._Creators; } }
	
		[Description("A description of the purpose of the work schedule.")]
		public IfcLabel? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("The total duration of the entire work schedule.")]
		public IfcTimeMeasure? Duration { get { return this._Duration; } set { this._Duration = value;} }
	
		[Description("The total time float of the entire work schedule.")]
		public IfcTimeMeasure? TotalFloat { get { return this._TotalFloat; } set { this._TotalFloat = value;} }
	
		[Description("The start time of the schedule.")]
		public IfcDateTimeSelect StartTime { get { return this._StartTime; } set { this._StartTime = value;} }
	
		[Description("The finish time of the schedule.")]
		public IfcDateTimeSelect FinishTime { get { return this._FinishTime; } set { this._FinishTime = value;} }
	
		[Description("Predefined work control types from which that required may be set. ")]
		public IfcWorkControlTypeEnum? WorkControlType { get { return this._WorkControlType; } set { this._WorkControlType = value;} }
	
		[Description("A user defined work control type.")]
		public IfcLabel? UserDefinedControlType { get { return this._UserDefinedControlType; } set { this._UserDefinedControlType = value;} }
	
	
	}
	
}
