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
	public partial class IfcStructuralSurfaceMemberVarying : IfcStructuralSurfaceMember
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Defines the variable thickness of the structural face member using two or more subsequent and additional thickness values. The first thickness value is already given by the inherited Thickness value and shall not be included in the list.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcPositiveLengthMeasure> SubsequentThickness { get; protected set; }
	
		[DataMember(Order = 1)] 
		[Description("A shape aspect, containing a list of shape representations, each defining either one Cartesian point or one point on surface (by parameter values) which are needed to provide the positions of the VaryingThickness. The values contained in the list of IfcShapeAspect.ShapeRepresentations correspond to the values at the same position in the list VaryingThickness. The locations shall be along the outer bounds of the face (or surface) only.")]
		[Required()]
		public IfcShapeAspect VaryingThicknessLocation { get; set; }
	
	
		public IfcStructuralSurfaceMemberVarying(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralSurfaceTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __Thickness, IfcPositiveLengthMeasure[] __SubsequentThickness, IfcShapeAspect __VaryingThicknessLocation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __PredefinedType, __Thickness)
		{
			this.SubsequentThickness = new List<IfcPositiveLengthMeasure>(__SubsequentThickness);
			this.VaryingThicknessLocation = __VaryingThicknessLocation;
		}
	
		public new IList<IfcPositiveLengthMeasure> VaryingThickness { get { return null; } }
	
	
	}
	
}
