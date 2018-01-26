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
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("0f341f47-3c39-4147-931a-6c01a7e6d767")]
	public partial class IfcStructuralSurfaceAction : IfcStructuralAction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcProjectedOrTrueLengthEnum? _ProjectedOrTrue;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcStructuralSurfaceActivityTypeEnum _PredefinedType;
	
	
		public IfcStructuralSurfaceAction()
		{
		}
	
		public IfcStructuralSurfaceAction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralLoad __AppliedLoad, IfcGlobalOrLocalEnum __GlobalOrLocal, IfcBoolean? __DestabilizingLoad, IfcProjectedOrTrueLengthEnum? __ProjectedOrTrue, IfcStructuralSurfaceActivityTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __AppliedLoad, __GlobalOrLocal, __DestabilizingLoad)
		{
			this._ProjectedOrTrue = __ProjectedOrTrue;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Defines whether load values are given per true lengths of the surface on which th" +
	    "ey act, or per lengths of the projection of the surface in load direction.  The " +
	    "latter is only applicable to loads which act in global coordinate directions.")]
		public IfcProjectedOrTrueLengthEnum? ProjectedOrTrue { get { return this._ProjectedOrTrue; } set { this._ProjectedOrTrue = value;} }
	
		[Description("Type of action according to its distribution of load values.")]
		public IfcStructuralSurfaceActivityTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
