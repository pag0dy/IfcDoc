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
	[Guid("0b5e3044-5232-4561-be29-c49fef5969d5")]
	public partial class IfcWindowType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcWindowTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcWindowTypePartitioningEnum _PartitioningType;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcBoolean? _ParameterTakesPrecedence;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcLabel? _UserDefinedPartitioningType;
	
	
		public IfcWindowType()
		{
		}
	
		public IfcWindowType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcWindowTypeEnum __PredefinedType, IfcWindowTypePartitioningEnum __PartitioningType, IfcBoolean? __ParameterTakesPrecedence, IfcLabel? __UserDefinedPartitioningType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
			this._PartitioningType = __PartitioningType;
			this._ParameterTakesPrecedence = __ParameterTakesPrecedence;
			this._UserDefinedPartitioningType = __UserDefinedPartitioningType;
		}
	
		[Description("Identifies the predefined types of a window element from which the type required " +
	    "may be set.")]
		public IfcWindowTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Type defining the general layout of the window type in terms of the partitioning " +
	    "of panels. ")]
		public IfcWindowTypePartitioningEnum PartitioningType { get { return this._PartitioningType; } set { this._PartitioningType = value;} }
	
		[Description(@"The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value. If not provided, no such information can be infered.")]
		public IfcBoolean? ParameterTakesPrecedence { get { return this._ParameterTakesPrecedence; } set { this._ParameterTakesPrecedence = value;} }
	
		[Description("Designator for the user defined partitioning type, shall only be provided, if the" +
	    " value of <em>PartitioningType</em> is set to USERDEFINED.")]
		public IfcLabel? UserDefinedPartitioningType { get { return this._UserDefinedPartitioningType; } set { this._UserDefinedPartitioningType = value;} }
	
	
	}
	
}
