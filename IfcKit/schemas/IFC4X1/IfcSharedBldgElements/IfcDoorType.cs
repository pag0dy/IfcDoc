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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("644f260a-0347-4e6a-84b2-be14f6c42b87")]
	public partial class IfcDoorType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcDoorTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcDoorTypeOperationEnum _OperationType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcBoolean? _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedOperationType;
	
	
		public IfcDoorType()
		{
		}
	
		public IfcDoorType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcDoorTypeEnum __PredefinedType, IfcDoorTypeOperationEnum __OperationType, IfcBoolean? __ParameterTakesPrecedence, IfcLabel? __UserDefinedOperationType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
			this._OperationType = __OperationType;
			this._ParameterTakesPrecedence = __ParameterTakesPrecedence;
			this._UserDefinedOperationType = __UserDefinedOperationType;
		}
	
		[Description("Identifies the predefined types of a door element from which the type required ma" +
	    "y be set.")]
		public IfcDoorTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Type defining the general layout and operation of the door type in terms of the p" +
	    "artitioning of panels and panel operations. ")]
		public IfcDoorTypeOperationEnum OperationType { get { return this._OperationType; } set { this._OperationType = value;} }
	
		[Description(@"The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value. If not provided, no such information can be infered.")]
		public IfcBoolean? ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("Designator for the user defined operation type, shall only be provided, if the va" +
	    "lue of <em>OperationType</em> is set to USERDEFINED.")]
		public IfcLabel? UserDefinedOperationType { get { return this._UserDefinedOperationType; } set { this._UserDefinedOperationType = value;} }
	
	
	}
	
}
