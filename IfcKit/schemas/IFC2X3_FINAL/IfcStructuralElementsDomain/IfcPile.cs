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
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("aa9e82e6-aecd-486e-91f7-de1a0685c8c0")]
	public partial class IfcPile : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPileTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPileConstructionEnum? _ConstructionType;
	
	
		public IfcPile()
		{
		}
	
		public IfcPile(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcPileTypeEnum __PredefinedType, IfcPileConstructionEnum? __ConstructionType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._PredefinedType = __PredefinedType;
			this._ConstructionType = __ConstructionType;
		}
	
		[Description("The predefined generic type of the pile according to function.")]
		public IfcPileTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("General designator for how the pile is constructed.")]
		public IfcPileConstructionEnum? ConstructionType { get { return this._ConstructionType; } set { this._ConstructionType = value;} }
	
	
	}
	
}
