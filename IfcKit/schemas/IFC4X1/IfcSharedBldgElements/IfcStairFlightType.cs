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
	[Guid("7116fa64-a466-426e-84ce-c82bc9a1a8c4")]
	public partial class IfcStairFlightType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStairFlightTypeEnum _PredefinedType;
	
	
		public IfcStairFlightType()
		{
		}
	
		public IfcStairFlightType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcStairFlightTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Identifies the predefined types of a stair flight element from which the type req" +
	    "uired may be set.")]
		public IfcStairFlightTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
