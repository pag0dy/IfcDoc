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
	[Guid("e9d95f21-bd10-40ff-ada5-a024a15bf019")]
	public partial class IfcStructuralSurfaceReaction : IfcStructuralReaction
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStructuralSurfaceActivityTypeEnum _PredefinedType;
	
	
		public IfcStructuralSurfaceReaction()
		{
		}
	
		public IfcStructuralSurfaceReaction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralLoad __AppliedLoad, IfcGlobalOrLocalEnum __GlobalOrLocal, IfcStructuralSurfaceActivityTypeEnum __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __AppliedLoad, __GlobalOrLocal)
		{
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Type of reaction according to its distribution of load values.")]
		public IfcStructuralSurfaceActivityTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
