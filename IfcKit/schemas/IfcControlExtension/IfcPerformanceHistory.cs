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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcControlExtension
{
	public partial class IfcPerformanceHistory : IfcControl
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Describes the applicable building life-cycle phase. Typical values should be DESIGNDEVELOPMENT, SCHEMATICDEVELOPMENT, CONSTRUCTIONDOCUMENT, CONSTRUCTION, ASBUILT, COMMISSIONING, OPERATION, etc. ")]
		[Required()]
		public IfcLabel LifeCyclePhase { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Predefined generic type for a performace history that is specified in an enumeration.  <blockquote class=\"change-ifc2x4\">IFC4 CHANGE  The attribute has been added at the end of the entity definition.</blockquote> ")]
		public IfcPerformanceHistoryTypeEnum? PredefinedType { get; set; }
	
	
		public IfcPerformanceHistory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcLabel __LifeCyclePhase, IfcPerformanceHistoryTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification)
		{
			this.LifeCyclePhase = __LifeCyclePhase;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
