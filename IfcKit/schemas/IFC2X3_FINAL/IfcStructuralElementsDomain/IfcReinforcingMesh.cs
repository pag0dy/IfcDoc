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

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("f1b23e5d-c76d-4754-8b04-ea3d52f51a16")]
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
		[Required()]
		IfcPositiveLengthMeasure _LongitudinalBarNominalDiameter;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _TransverseBarNominalDiameter;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _LongitudinalBarCrossSectionArea;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		[Required()]
		IfcAreaMeasure _TransverseBarCrossSectionArea;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _LongitudinalBarSpacing;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _TransverseBarSpacing;
	
	
		public IfcReinforcingMesh()
		{
		}
	
		public IfcReinforcingMesh(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcIdentifier? __Tag, IfcLabel? __SteelGrade, IfcPositiveLengthMeasure? __MeshLength, IfcPositiveLengthMeasure? __MeshWidth, IfcPositiveLengthMeasure __LongitudinalBarNominalDiameter, IfcPositiveLengthMeasure __TransverseBarNominalDiameter, IfcAreaMeasure __LongitudinalBarCrossSectionArea, IfcAreaMeasure __TransverseBarCrossSectionArea, IfcPositiveLengthMeasure __LongitudinalBarSpacing, IfcPositiveLengthMeasure __TransverseBarSpacing)
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
		}
	
		[Description("The overall length of the mesh measured in its longitudinal direction.")]
		public IfcPositiveLengthMeasure? MeshLength { get { return this._MeshLength; } set { this._MeshLength = value;} }
	
		[Description("The overall width of the mesh measured in its transversal direction.")]
		public IfcPositiveLengthMeasure? MeshWidth { get { return this._MeshWidth; } set { this._MeshWidth = value;} }
	
		[Description("The nominal diameter denoting the cross-section size of the longitudinal bars.")]
		public IfcPositiveLengthMeasure LongitudinalBarNominalDiameter { get { return this._LongitudinalBarNominalDiameter; } set { this._LongitudinalBarNominalDiameter = value;} }
	
		[Description("The nominal diameter denoting the cross-section size of the transverse bars.")]
		public IfcPositiveLengthMeasure TransverseBarNominalDiameter { get { return this._TransverseBarNominalDiameter; } set { this._TransverseBarNominalDiameter = value;} }
	
		[Description("The effective cross-section area of the longitudinal bars of the mesh.")]
		public IfcAreaMeasure LongitudinalBarCrossSectionArea { get { return this._LongitudinalBarCrossSectionArea; } set { this._LongitudinalBarCrossSectionArea = value;} }
	
		[Description("The effective cross-section area of the transverse bars of the mesh.")]
		public IfcAreaMeasure TransverseBarCrossSectionArea { get { return this._TransverseBarCrossSectionArea; } set { this._TransverseBarCrossSectionArea = value;} }
	
		[Description("The spacing between the longitudinal bars. Note: an even distribution of bars is " +
	    "presumed; other cases are handled by Psets.")]
		public IfcPositiveLengthMeasure LongitudinalBarSpacing { get { return this._LongitudinalBarSpacing; } set { this._LongitudinalBarSpacing = value;} }
	
		[Description("The spacing between the transverse bars. Note: an even distribution of bars is pr" +
	    "esumed; other cases are handled by Psets.")]
		public IfcPositiveLengthMeasure TransverseBarSpacing { get { return this._TransverseBarSpacing; } set { this._TransverseBarSpacing = value;} }
	
	
	}
	
}
