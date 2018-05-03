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

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralResultGroup : IfcGroup
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Specifies the analysis theory used to obtain the respective results.")]
		[Required()]
		public IfcAnalysisTheoryTypeEnum TheoryType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Reference to an instance of IfcStructuralLoadGroup for which this instance represents the result.")]
		public IfcStructuralLoadGroup ResultForLoadGroup { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("This value allows to easily recognize whether a linear analysis has been applied (allowing the superposition of analysis results).")]
		[Required()]
		public IfcBoolean IsLinear { get; set; }
	
		[InverseProperty("HasResults")] 
		[Description("Reference to an instance of IfcStructuralAnalysisModel for which this instance captures a result.")]
		[MaxLength(1)]
		public ISet<IfcStructuralAnalysisModel> ResultGroupFor { get; protected set; }
	
	
		public IfcStructuralResultGroup(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcAnalysisTheoryTypeEnum __TheoryType, IfcStructuralLoadGroup __ResultForLoadGroup, IfcBoolean __IsLinear)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this.TheoryType = __TheoryType;
			this.ResultForLoadGroup = __ResultForLoadGroup;
			this.IsLinear = __IsLinear;
			this.ResultGroupFor = new HashSet<IfcStructuralAnalysisModel>();
		}
	
	
	}
	
}
