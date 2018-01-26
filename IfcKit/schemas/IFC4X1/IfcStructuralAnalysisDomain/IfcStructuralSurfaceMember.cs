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
	[Guid("98531769-b684-4095-a8e0-843609f7cef0")]
	public partial class IfcStructuralSurfaceMember : IfcStructuralMember
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStructuralSurfaceMemberTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _Thickness;
	
	
		public IfcStructuralSurfaceMember()
		{
		}
	
		public IfcStructuralSurfaceMember(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralSurfaceMemberTypeEnum __PredefinedType, IfcPositiveLengthMeasure? __Thickness)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._PredefinedType = __PredefinedType;
			this._Thickness = __Thickness;
		}
	
		[Description("Type of member with respect to its load carrying behavior in this analysis ideali" +
	    "zation.")]
		public IfcStructuralSurfaceMemberTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("Defines the typically understood thickness of the structural surface member, meas" +
	    "ured normal to its reference surface.")]
		public IfcPositiveLengthMeasure? Thickness { get { return this._Thickness; } set { this._Thickness = value;} }
	
	
	}
	
}
