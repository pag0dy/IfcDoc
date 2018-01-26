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
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("a152e66f-594f-4779-90f7-092829204b79")]
	public partial class IfcTubeBundleType : IfcEnergyConversionDeviceType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcTubeBundleTypeEnum _PredefinedType;
	
	
		public IfcTubeBundleType()
		{
		}
	
		public IfcTubeBundleType(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcIdentifier? __ApplicableOccurrence, IfcPropertySetDefinition[] __HasPropertySets, IfcRepresentationMap[] __RepresentationMaps, IfcLabel? __Tag, IfcLabel? __ElementType, IfcTubeBundleTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ApplicableOccurrence, __HasPropertySets, __RepresentationMaps, __Tag, __ElementType)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Defines the type of tube bundle.")]
		public IfcTubeBundleTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
