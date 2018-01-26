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
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("bd23f603-d57b-4521-9674-c7358abc338e")]
	public partial class IfcStructuralSurfaceMemberVarying : IfcStructuralSurfaceMember
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		IList<IfcPositiveLengthMeasure> _SubsequentThickness = new List<IfcPositiveLengthMeasure>();
	
		[DataMember(Order=1)] 
		[Required()]
		IfcShapeAspect _VaryingThicknessLocation;
	
	
		public IfcStructuralSurfaceMemberVarying()
		{
		}
	
		public IfcStructuralSurfaceMemberVarying(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralSurfaceTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __Thickness, IfcPositiveLengthMeasure[] __SubsequentThickness, IfcShapeAspect __VaryingThicknessLocation)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __PredefinedType, __Thickness)
		{
			this._SubsequentThickness = new List<IfcPositiveLengthMeasure>(__SubsequentThickness);
			this._VaryingThicknessLocation = __VaryingThicknessLocation;
		}
	
		[Description("Defines the variable thickness of the structural face member using two or more su" +
	    "bsequent and additional thickness values. The first thickness value is already g" +
	    "iven by the inherited Thickness value and shall not be included in the list.")]
		public IList<IfcPositiveLengthMeasure> SubsequentThickness { get { return this._SubsequentThickness; } }
	
		[Description(@"A shape aspect, containing a list of shape representations, each defining either one Cartesian point or one point on surface (by parameter values) which are needed to provide the positions of the VaryingThickness. The values contained in the list of IfcShapeAspect.ShapeRepresentations correspond to the values at the same position in the list VaryingThickness. The locations shall be along the outer bounds of the face (or surface) only.")]
		public IfcShapeAspect VaryingThicknessLocation { get { return this._VaryingThicknessLocation; } set { this._VaryingThicknessLocation = value;} }
	
		public new IList<IfcPositiveLengthMeasure> VaryingThickness { get { return null; } }
	
	
	}
	
}
