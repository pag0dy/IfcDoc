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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	[Guid("c55468d2-4e66-449a-9e37-6795ea684389")]
	public partial class IfcReinforcingMeshType : IfcReinforcingElementType
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcReinforcingMeshTypeEnum _PredefinedType;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshLength;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _MeshWidth;
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarNominalDiameter;
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarNominalDiameter;
	
		[DataMember(Order=5)] 
		[XmlAttribute]
		IfcAreaMeasure? _LongitudinalBarCrossSectionArea;
	
		[DataMember(Order=6)] 
		[XmlAttribute]
		IfcAreaMeasure? _TransverseBarCrossSectionArea;
	
		[DataMember(Order=7)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _LongitudinalBarSpacing;
	
		[DataMember(Order=8)] 
		[XmlAttribute]
		IfcPositiveLengthMeasure? _TransverseBarSpacing;
	
		[DataMember(Order=9)] 
		[XmlAttribute]
		IfcLabel? _BendingShapeCode;
	
		[DataMember(Order=10)] 
		IList<IfcBendingParameterSelect> _BendingParameters = new List<IfcBendingParameterSelect>();
	
	
		[Description("Subtype of reinforcing mesh.")]
		public IfcReinforcingMeshTypeEnum PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("The overall length of the mesh measured in its longitudinal direction.")]
		public IfcPositiveLengthMeasure? MeshLength { get { return this._MeshLength; } set { this._MeshLength = value;} }
	
		[Description("The overall width of the mesh measured in its transversal direction.")]
		public IfcPositiveLengthMeasure? MeshWidth { get { return this._MeshWidth; } set { this._MeshWidth = value;} }
	
		[Description("The nominal diameter denoting the cross-section size of the longitudinal bars.")]
		public IfcPositiveLengthMeasure? LongitudinalBarNominalDiameter { get { return this._LongitudinalBarNominalDiameter; } set { this._LongitudinalBarNominalDiameter = value;} }
	
		[Description("The nominal diameter denoting the cross-section size of the transverse bars.")]
		public IfcPositiveLengthMeasure? TransverseBarNominalDiameter { get { return this._TransverseBarNominalDiameter; } set { this._TransverseBarNominalDiameter = value;} }
	
		[Description("The effective cross-section area of the longitudinal bars of the mesh.")]
		public IfcAreaMeasure? LongitudinalBarCrossSectionArea { get { return this._LongitudinalBarCrossSectionArea; } set { this._LongitudinalBarCrossSectionArea = value;} }
	
		[Description("The effective cross-section area of the transverse bars of the mesh.")]
		public IfcAreaMeasure? TransverseBarCrossSectionArea { get { return this._TransverseBarCrossSectionArea; } set { this._TransverseBarCrossSectionArea = value;} }
	
		[Description("The spacing between the longitudinal bars.  Note: an even distribution of bars is" +
	    " presumed; other cases are handled by classification or property sets.")]
		public IfcPositiveLengthMeasure? LongitudinalBarSpacing { get { return this._LongitudinalBarSpacing; } set { this._LongitudinalBarSpacing = value;} }
	
		[Description("The spacing between the transverse bars.  Note: an even distribution of bars is p" +
	    "resumed; other cases are handled by classification or property sets.")]
		public IfcPositiveLengthMeasure? TransverseBarSpacing { get { return this._TransverseBarSpacing; } set { this._TransverseBarSpacing = value;} }
	
		[Description(@"If this mesh type is bent rather than planar, this attribute provides a shape code per a standard like ACI 315, ISO 3766, or a similar standard.  It is presumed that a single standard for defining the mesh bending is used throughout the project and that this standard is referenced from the <em>IfcProject</em> object through the <em>IfcDocumentReference</em> mechanism.")]
		public IfcLabel? BendingShapeCode { get { return this._BendingShapeCode; } set { this._BendingShapeCode = value;} }
	
		[Description("If this mesh type is bent rather than planar, this attribute provides bending sha" +
	    "pe parameters. Their meaning is defined by the bending shape code and the respec" +
	    "tive standard.")]
		public IList<IfcBendingParameterSelect> BendingParameters { get { return this._BendingParameters; } }
	
	
	}
	
}
