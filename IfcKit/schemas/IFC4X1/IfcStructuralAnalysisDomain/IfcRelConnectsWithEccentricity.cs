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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("a66f70d6-cdc3-47b6-b2a1-9b9c2991e6f5")]
	public partial class IfcRelConnectsWithEccentricity : IfcRelConnectsStructuralMember
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcConnectionGeometry _ConnectionConstraint;
	
	
		public IfcRelConnectsWithEccentricity()
		{
		}
	
		public IfcRelConnectsWithEccentricity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcStructuralMember __RelatingStructuralMember, IfcStructuralConnection __RelatedStructuralConnection, IfcBoundaryCondition __AppliedCondition, IfcStructuralConnectionCondition __AdditionalConditions, IfcLengthMeasure? __SupportedLength, IfcAxis2Placement3D __ConditionCoordinateSystem, IfcConnectionGeometry __ConnectionConstraint)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __RelatingStructuralMember, __RelatedStructuralConnection, __AppliedCondition, __AdditionalConditions, __SupportedLength, __ConditionCoordinateSystem)
		{
			this._ConnectionConstraint = __ConnectionConstraint;
		}
	
		[Description("The connection constraint explicitly states the eccentricity between a structural" +
	    " member and a structural connection by means of two topological objects (vertex " +
	    "and vertex, or edge and edge, or face and face).")]
		public IfcConnectionGeometry ConnectionConstraint { get { return this._ConnectionConstraint; } set { this._ConnectionConstraint = value;} }
	
	
	}
	
}
