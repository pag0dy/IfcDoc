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

namespace BuildingSmart.IFC.IfcProcessExtension
{
	[Guid("77b2b704-db87-472e-a29a-8703008a914e")]
	public partial class IfcTaskType : IfcTypeProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTaskTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLabel? _WorkMethod;
	
	
		public IfcTaskType()
		{
		}
	
		public IfcTaskType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcLabel? __ProcessType, IfcTaskTypeEnum __PredefinedType, IfcLabel? __WorkMethod)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __Identification, __LongDescription, __ProcessType)
		{
			this._PredefinedType = __PredefinedType;
			this._WorkMethod = __WorkMethod;
		}
	
		[Description("    Identifies the predefined types of a task type from which \r\n    the type requ" +
	    "ired may be set.")]
		public IfcTaskTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("    The method of work used in carrying out a task.")]
		public IfcLabel? WorkMethod { get { return this._WorkMethod; } set { this._WorkMethod = value;} }
	
	
	}
	
}
