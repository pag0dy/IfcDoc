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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralLinearAction : IfcStructuralAction
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines if the load values are given by using the length of the member on which they act (true length) or by using the projected length resulting from the loaded member and the global project coordinate system. It is only considered if the global project coordinate system is used, and if the action is of type IfcStructuralLinearAction or IfcStructuralPlanarAction. ")]
		[Required()]
		public IfcProjectedOrTrueLengthEnum ProjectedOrTrue { get; set; }
	
	
		public IfcStructuralLinearAction(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralLoad __AppliedLoad, IfcGlobalOrLocalEnum __GlobalOrLocal, Boolean __DestabilizingLoad, IfcStructuralReaction __CausedBy, IfcProjectedOrTrueLengthEnum __ProjectedOrTrue)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __AppliedLoad, __GlobalOrLocal, __DestabilizingLoad, __CausedBy)
		{
			this.ProjectedOrTrue = __ProjectedOrTrue;
		}
	
	
	}
	
}
