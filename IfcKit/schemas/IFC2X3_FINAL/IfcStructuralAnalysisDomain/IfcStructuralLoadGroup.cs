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

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("e3c9c714-198c-4207-bec8-0f12bc40d170")]
	public partial class IfcStructuralLoadGroup : IfcGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcLoadGroupTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcActionTypeEnum _ActionType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcActionSourceTypeEnum _ActionSource;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcRatioMeasure? _Coefficient;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcLabel? _Purpose;
	
		[InverseProperty("ResultForLoadGroup")] 
		[MaxLength(1)]
		ISet<IfcStructuralResultGroup> _SourceOfResultGroup = new HashSet<IfcStructuralResultGroup>();
	
		[InverseProperty("LoadedBy")] 
		ISet<IfcStructuralAnalysisModel> _LoadGroupFor = new HashSet<IfcStructuralAnalysisModel>();
	
	
		public IfcStructuralLoadGroup()
		{
		}
	
		public IfcStructuralLoadGroup(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcLoadGroupTypeEnum __PredefinedType, IfcActionTypeEnum __ActionType, IfcActionSourceTypeEnum __ActionSource, IfcRatioMeasure? __Coefficient, IfcLabel? __Purpose)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
			this._PredefinedType = __PredefinedType;
			this._ActionType = __ActionType;
			this._ActionSource = __ActionSource;
			this._Coefficient = __Coefficient;
			this._Purpose = __Purpose;
		}
	
		[Description("Selects a predefined type for the load group. It can be differentiated between lo" +
	    "ad groups, load cases, load combination groups (a necessary construct for the de" +
	    "scription of load combinations) and load combinations. ")]
		public IfcLoadGroupTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Type of actions in the group. Normally needed if \'PredefinedType\' specifies a LOA" +
	    "D_COMBINATION_GROUP.")]
		public IfcActionTypeEnum ActionType { get { return this._ActionType; } set { this._ActionType = value;} }
	
		[Description("Source of actions in the group. Normally needed if \'PredefinedType\' specifies a L" +
	    "OAD_CASE.")]
		public IfcActionSourceTypeEnum ActionSource { get { return this._ActionSource; } set { this._ActionSource = value;} }
	
		[Description("Load factor. If omitted, a factor is not yet known or not specified. A load facto" +
	    "r of 1.0 shall be explicitly exported as Coefficient = 1.0.")]
		public IfcRatioMeasure? Coefficient { get { return this._Coefficient; } set { this._Coefficient = value;} }
	
		[Description("Description of the purpose of this instance. Among else, possible values of the P" +
	    "urpose of load combinations are \'SLS\', \'ULS\', \'ALS\' to indicate serviceability, " +
	    "ultimate, or accidental limit state.")]
		public IfcLabel? Purpose { get { return this._Purpose; } set { this._Purpose = value;} }
	
		[Description("Results which were computed using this load group.")]
		public ISet<IfcStructuralResultGroup> SourceOfResultGroup { get { return this._SourceOfResultGroup; } }
	
		[Description("Analysis models in which this load group is used.")]
		public ISet<IfcStructuralAnalysisModel> LoadGroupFor { get { return this._LoadGroupFor; } }
	
	
	}
	
}
