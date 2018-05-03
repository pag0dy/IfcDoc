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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	public partial class IfcWindowType : IfcBuildingElementType
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Identifies the predefined types of a window element from which the type required may be set.")]
		[Required()]
		public IfcWindowTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Type defining the general layout of the window type in terms of the partitioning of panels. ")]
		[Required()]
		public IfcWindowTypePartitioningEnum PartitioningType { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The Boolean value reflects, whether the parameter given in the attached lining and panel properties exactly define the geometry (TRUE), or whether the attached style shape take precedence (FALSE). In the last case the parameter have only informative value. If not provided, no such information can be infered.")]
		public IfcBoolean? ParameterTakesPrecedence { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Designator for the user defined partitioning type, shall only be provided, if the value of <em>PartitioningType</em> is set to USERDEFINED.")]
		public IfcLabel? UserDefinedPartitioningType { get; set; }
	
	
		public IfcWindowType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcWindowTypeEnum __PredefinedType, IfcWindowTypePartitioningEnum __PartitioningType, IfcBoolean? __ParameterTakesPrecedence, IfcLabel? __UserDefinedPartitioningType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this.PredefinedType = __PredefinedType;
			this.PartitioningType = __PartitioningType;
			this.ParameterTakesPrecedence = __ParameterTakesPrecedence;
			this.UserDefinedPartitioningType = __UserDefinedPartitioningType;
		}
	
	
	}
	
}
