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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	[Guid("e8ca45f2-cf0b-4a93-84ca-ea3c10c7b27e")]
	public partial class IfcPerformanceHistory : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _LifeCyclePhase;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPerformanceHistoryTypeEnum? _PredefinedType;
	
	
		public IfcPerformanceHistory()
		{
		}
	
		public IfcPerformanceHistory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcLabel __LifeCyclePhase, IfcPerformanceHistoryTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this._LifeCyclePhase = __LifeCyclePhase;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Describes the applicable building life-cycle phase. Typical values should be DESI" +
	    "GNDEVELOPMENT, SCHEMATICDEVELOPMENT, CONSTRUCTIONDOCUMENT, CONSTRUCTION, ASBUILT" +
	    ", COMMISSIONING, OPERATION, etc. ")]
		public IfcLabel LifeCyclePhase { get { return this._LifeCyclePhase; } set { this._LifeCyclePhase = value;} }
	
		[Description("Predefined generic type for a performace history that is specified in an enumerat" +
	    "ion.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been adde" +
	    "d at the end of the entity definition.</blockquote> ")]
		public IfcPerformanceHistoryTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
