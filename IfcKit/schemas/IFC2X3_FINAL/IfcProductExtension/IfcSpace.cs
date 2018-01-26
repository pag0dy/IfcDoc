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

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("3289e523-2eef-4bfe-b002-fe259f78ee64")]
	public partial class IfcSpace : IfcSpatialStructureElement
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcInternalOrExternalEnum _InteriorOrExteriorSpace;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcLengthMeasure? _ElevationWithFlooring;
	
		[InverseProperty("RelatedSpace")] 
		ISet<IfcRelCoversSpaces> _HasCoverings = new HashSet<IfcRelCoversSpaces>();
	
		[InverseProperty("RelatingSpace")] 
		ISet<IfcRelSpaceBoundary> _BoundedBy = new HashSet<IfcRelSpaceBoundary>();
	
	
		public IfcSpace()
		{
		}
	
		public IfcSpace(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcLabel? __LongName, IfcElementCompositionEnum __CompositionType, IfcInternalOrExternalEnum __InteriorOrExteriorSpace, IfcLengthMeasure? __ElevationWithFlooring)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __LongName, __CompositionType)
		{
			this._InteriorOrExteriorSpace = __InteriorOrExteriorSpace;
			this._ElevationWithFlooring = __ElevationWithFlooring;
		}
	
		[Description("Defines, whether the Space is interior (Internal), or exterior (External), i.e. p" +
	    "art of the outer space.\r\n")]
		public IfcInternalOrExternalEnum InteriorOrExteriorSpace { get { return this._InteriorOrExteriorSpace; } set { this._InteriorOrExteriorSpace = value;} }
	
		[Description("Level of flooring of this space; the average shall be taken, if the space ground " +
	    "surface is sloping or if there are level differences within this space. ")]
		public IfcLengthMeasure? ElevationWithFlooring { get { return this._ElevationWithFlooring; } set { this._ElevationWithFlooring = value;} }
	
		[Description(@"<EPM-HTML>
	Reference to <i>IfcCovering</i> by virtue of the objectified relationship <i>IfcRelCoversSpaces</i>. It defines the concept of a space having coverings assigned. Those coverings may represent different flooring, or tiling areas.
	<blockquote><small>
	NOTE&nbsp; Coverings are often managed by the space, and not by the building element, which they cover.<br>
	<font color=""#ff0000"">IFC2x Edition3 CHANGE&nbsp; New inverse relationship. Upward compatibility for file based exchange is guaranteed.</font>
	</small></blockquote>
	</EPM-HTML>
	")]
		public ISet<IfcRelCoversSpaces> HasCoverings { get { return this._HasCoverings; } }
	
		[Description("Reference to Set of Space Boundaries that defines the physical or virtual delimit" +
	    "ation of that Space.\r\n")]
		public ISet<IfcRelSpaceBoundary> BoundedBy { get { return this._BoundedBy; } }
	
	
	}
	
}
