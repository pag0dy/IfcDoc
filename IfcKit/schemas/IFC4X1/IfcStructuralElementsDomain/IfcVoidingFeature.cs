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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("76ade710-1f8c-4677-9f36-a21e6d4c7476")]
	public partial class IfcVoidingFeature : IfcFeatureElementSubtraction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcVoidingFeatureTypeEnum? _PredefinedType;
	
	
		public IfcVoidingFeature()
		{
		}
	
		public IfcVoidingFeature(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcVoidingFeatureTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Qualifies the feature regarding its shape and configuration relative to the voide" +
	    "d element.")]
		public IfcVoidingFeatureTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
