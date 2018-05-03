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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public partial class IfcRelConnectsWithEccentricity : IfcRelConnectsStructuralMember
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The connection constraint explicitly states the eccentricity between a structural member and a structural connection by means of two topological objects (vertex and vertex, or edge and edge, or face and face).")]
		[Required()]
		public IfcConnectionGeometry ConnectionConstraint { get; set; }
	
	
		public IfcRelConnectsWithEccentricity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcStructuralMember __RelatingStructuralMember, IfcStructuralConnection __RelatedStructuralConnection, IfcBoundaryCondition __AppliedCondition, IfcStructuralConnectionCondition __AdditionalConditions, IfcLengthMeasure? __SupportedLength, IfcAxis2Placement3D __ConditionCoordinateSystem, IfcConnectionGeometry __ConnectionConstraint)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatingStructuralMember, __RelatedStructuralConnection, __AppliedCondition, __AdditionalConditions, __SupportedLength, __ConditionCoordinateSystem)
		{
			this.ConnectionConstraint = __ConnectionConstraint;
		}
	
	
	}
	
}
