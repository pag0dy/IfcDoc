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
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public partial class IfcReinforcingMesh : IfcReinforcingElement
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? MeshLength { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? MeshWidth { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get; set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get; set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcAreaMeasure? LongitudinalBarCrossSectionArea { get; set; }
	
		[DataMember(Order = 5)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcAreaMeasure? TransverseBarCrossSectionArea { get; set; }
	
		[DataMember(Order = 6)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? LongitudinalBarSpacing { get; set; }
	
		[DataMember(Order = 7)] 
		[XmlAttribute]
		[Description("Deprecated.    <blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? TransverseBarSpacing { get; set; }
	
		[DataMember(Order = 8)] 
		[XmlAttribute]
		[Description("Kind of mesh.")]
		public IfcReinforcingMeshTypeEnum? PredefinedType { get; set; }
	
	
		public IfcReinforcingMesh(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade, IfcPositiveLengthMeasure? __MeshLength, IfcPositiveLengthMeasure? __MeshWidth, IfcPositiveLengthMeasure? __LongitudinalBarNominalDiameter, IfcPositiveLengthMeasure? __TransverseBarNominalDiameter, IfcAreaMeasure? __LongitudinalBarCrossSectionArea, IfcAreaMeasure? __TransverseBarCrossSectionArea, IfcPositiveLengthMeasure? __LongitudinalBarSpacing, IfcPositiveLengthMeasure? __TransverseBarSpacing, IfcReinforcingMeshTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag, __SteelGrade)
		{
			this.MeshLength = __MeshLength;
			this.MeshWidth = __MeshWidth;
			this.LongitudinalBarNominalDiameter = __LongitudinalBarNominalDiameter;
			this.TransverseBarNominalDiameter = __TransverseBarNominalDiameter;
			this.LongitudinalBarCrossSectionArea = __LongitudinalBarCrossSectionArea;
			this.TransverseBarCrossSectionArea = __TransverseBarCrossSectionArea;
			this.LongitudinalBarSpacing = __LongitudinalBarSpacing;
			this.TransverseBarSpacing = __TransverseBarSpacing;
			this.PredefinedType = __PredefinedType;
		}
	
	
	}
	
}
