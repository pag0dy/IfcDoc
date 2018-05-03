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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcStructuralSurfaceMember : IfcStructuralMember
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Type of member with respect to its load carrying behavior in this analysis idealization.")]
		[Required()]
		public IfcStructuralSurfaceMemberTypeEnum PredefinedType { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Defines the typically understood thickness of the structural surface member, measured normal to its reference surface.")]
		public IfcPositiveLengthMeasure? Thickness { get; set; }
	
	
		public IfcStructuralSurfaceMember(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralSurfaceMemberTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __Thickness)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this.PredefinedType = __PredefinedType;
			this.Thickness = __Thickness;
		}
	
	
	}
	
}
