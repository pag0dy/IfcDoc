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
	[Guid("be13e443-b031-4314-a1ca-5054984b82c8")]
	public partial class IfcPerformanceHistory : IfcControl
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLabel _LifeCyclePhase;
	
	
		public IfcPerformanceHistory()
		{
		}
	
		public IfcPerformanceHistory(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLabel __LifeCyclePhase)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._LifeCyclePhase = __LifeCyclePhase;
		}
	
		[Description("Describes the applicable building life-cycle phase. Typical values should be DESI" +
	    "GNDEVELOPMENT, SCHEMATICDEVELOPMENT, CONSTRUCTIONDOCUMENT, CONSTRUCTION, ASBUILT" +
	    ", COMMISSIONING, OPERATION, etc. ")]
		public IfcLabel LifeCyclePhase { get { return this._LifeCyclePhase; } set { this._LifeCyclePhase = value;} }
	
	
	}
	
}
