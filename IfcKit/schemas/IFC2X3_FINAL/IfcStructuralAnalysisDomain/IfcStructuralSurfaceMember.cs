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
	[Guid("0220cd79-a55b-4394-b463-e381c4e5129c")]
	public partial class IfcStructuralSurfaceMember : IfcStructuralMember
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStructuralSurfaceTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Thickness;
	
	
		public IfcStructuralSurfaceMember()
		{
		}
	
		public IfcStructuralSurfaceMember(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralSurfaceTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __Thickness)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._PredefinedType = __PredefinedType;
			this._Thickness = __Thickness;
		}
	
		[Description("Defines the load carrying behavior of the member, as far as it is taken into acco" +
	    "unt in the analysis.")]
		public IfcStructuralSurfaceTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Defines the typically understood thickness of the structural face member, i.e. th" +
	    "e smallest spatial dimension of the element.")]
		public IfcPositiveLengthMeasure? Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
	
	}
	
}
