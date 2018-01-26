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
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("4c814694-171a-4536-8ad3-610cd5770f71")]
	public partial class IfcBuildingElementProxy : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcElementCompositionEnum? _CompositionType;
	
	
		public IfcBuildingElementProxy()
		{
		}
	
		public IfcBuildingElementProxy(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcElementCompositionEnum? __CompositionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._CompositionType = __CompositionType;
		}
	
		[Description("Indication, whether the proxy is intended to form an aggregation (COMPLEX), an in" +
	    "tegral element (ELEMENT), or a part in an aggregation (PARTIAL).")]
		public IfcElementCompositionEnum? CompositionType { get { return this._CompositionType; } set { this._CompositionType = value;} }
	
	
	}
	
}
