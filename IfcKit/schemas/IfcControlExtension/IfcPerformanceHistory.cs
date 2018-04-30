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
	
	
		public IfcPerformanceHistory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel __LifeCyclePhase)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.LifeCyclePhase = __LifeCyclePhase;
		}
	
	
	}
	
}
