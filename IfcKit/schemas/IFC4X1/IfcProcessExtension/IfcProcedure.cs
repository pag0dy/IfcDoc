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
	[Guid("0cce4f12-90b1-4e02-a09b-0dab4f9a731c")]
	public partial class IfcProcedure : IfcProcess
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcProcedureTypeEnum? _PredefinedType;
	
	
		public IfcProcedure()
		{
		}
	
		public IfcProcedure(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier? __Identification, IfcText? __LongDescription, IfcProcedureTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __Identification, __LongDescription)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("    Identifies the predefined types of a procedure from which \r\n    the type requ" +
	    "ired may be set.")]
		public IfcProcedureTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
