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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcSharedBldgElements
{
	[Guid("76c3b2d8-410b-4108-aaf7-b5147dad4278")]
	public partial class IfcStair : IfcBuildingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcStairTypeEnum _ShapeType;
	
	
		public IfcStair()
		{
		}
	
		public IfcStair(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcStairTypeEnum __ShapeType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag)
		{
			this._ShapeType = __ShapeType;
		}
	
		[Description("Predefined shape types for a stair that are specified in an Enum.")]
		public IfcStairTypeEnum ShapeType { get { return this._ShapeType; } set { this._ShapeType = value;} }
	
	
	}
	
}
