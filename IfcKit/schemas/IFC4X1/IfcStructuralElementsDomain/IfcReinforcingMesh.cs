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
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("60c27225-1396-4914-94fa-e4ace351eb81")]
	public partial class IfcReinforcingMesh : IfcReinforcingElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshLength;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshWidth;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarNominalDiameter;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarNominalDiameter;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcAreaMeasure? _LongitudinalBarCrossSectionArea;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcAreaMeasure? _TransverseBarCrossSectionArea;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarSpacing;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarSpacing;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcReinforcingMeshTypeEnum? _PredefinedType;
	
	
		public IfcReinforcingMesh()
		{
		}
	
		public IfcReinforcingMesh(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade, IfcPositiveLengthMeasure? __MeshLength, IfcPositiveLengthMeasure? __MeshWidth, IfcPositiveLengthMeasure? __LongitudinalBarNominalDiameter, IfcPositiveLengthMeasure? __TransverseBarNominalDiameter, IfcAreaMeasure? __LongitudinalBarCrossSectionArea, IfcAreaMeasure? __TransverseBarCrossSectionArea, IfcPositiveLengthMeasure? __LongitudinalBarSpacing, IfcPositiveLengthMeasure? __TransverseBarSpacing, IfcReinforcingMeshTypeEnum? __PredefinedType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __Tag, __SteelGrade)
		{
			this._MeshLength = __MeshLength;
			this._MeshWidth = __MeshWidth;
			this._LongitudinalBarNominalDiameter = __LongitudinalBarNominalDiameter;
			this._TransverseBarNominalDiameter = __TransverseBarNominalDiameter;
			this._LongitudinalBarCrossSectionArea = __LongitudinalBarCrossSectionArea;
			this._TransverseBarCrossSectionArea = __TransverseBarCrossSectionArea;
			this._LongitudinalBarSpacing = __LongitudinalBarSpacing;
			this._TransverseBarSpacing = __TransverseBarSpacing;
			this._PredefinedType = __PredefinedType;
		}
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute depr" +
	    "ecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</b" +
	    "lockquote>")]
		public IfcPositiveLengthMeasure? MeshLength { get { return this._MeshLength; } set { this._MeshLength = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute depr" +
	    "ecated.  Use respective attribute at <em>IfcReinforcingMeshType</em> instead.</b" +
	    "lockquote>")]
		public IfcPositiveLengthMeasure? MeshWidth { get { return this._MeshWidth; } set { this._MeshWidth = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get { return this._LongitudinalBarNominalDiameter; } set { this._LongitudinalBarNominalDiameter = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get { return this._TransverseBarNominalDiameter; } set { this._TransverseBarNominalDiameter = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcAreaMeasure? LongitudinalBarCrossSectionArea { get { return this._LongitudinalBarCrossSectionArea; } set { this._LongitudinalBarCrossSectionArea = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcAreaMeasure? TransverseBarCrossSectionArea { get { return this._TransverseBarCrossSectionArea; } set { this._TransverseBarCrossSectionArea = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? LongitudinalBarSpacing { get { return this._LongitudinalBarSpacing; } set { this._LongitudinalBarSpacing = value;} }
	
		[Description("Deprecated.\r\n\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE&nbsp; Attribute made" +
	    " optional and deprecated.  Use respective attribute at <em>IfcReinforcingMeshTyp" +
	    "e</em> instead.</blockquote>")]
		public IfcPositiveLengthMeasure? TransverseBarSpacing { get { return this._TransverseBarSpacing; } set { this._TransverseBarSpacing = value;} }
	
		[Description("Kind of mesh.")]
		public IfcReinforcingMeshTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
