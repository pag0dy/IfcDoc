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
	[Guid("f041588e-11cf-4855-a436-a562724c8408")]
	public partial class IfcChimneyType : IfcBuildingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcChimneyTypeEnum _PredefinedType;
	
	
		public IfcChimneyType()
		{
		}
	
		public IfcChimneyType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcChimneyTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Identifies the predefined types of a chimney element from which the type required" +
	    " may be set.")]
		public IfcChimneyTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
