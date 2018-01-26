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
	[Guid("7a0321d6-98bb-4c1d-8c3f-197847d7fc5e")]
	public partial class IfcGrid : IfcProduct
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcGridAxis> _UAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcGridAxis> _VAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=2)] 
		[MinLength(1)]
		IList<IfcGridAxis> _WAxes = new List<IfcGridAxis>();
	
		[InverseProperty("RelatedElements")] 
		[MaxLength(1)]
		ISet<IfcRelContainedInSpatialStructure> _ContainedInStructure = new HashSet<IfcRelContainedInSpatialStructure>();
	
	
		public IfcGrid()
		{
		}
	
		public IfcGrid(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcGridAxis[] __UAxes, IfcGridAxis[] __VAxes, IfcGridAxis[] __WAxes)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation)
		{
			this._UAxes = new List<IfcGridAxis>(__UAxes);
			this._VAxes = new List<IfcGridAxis>(__VAxes);
			this._WAxes = new List<IfcGridAxis>(__WAxes);
		}
	
		[Description("List of grid axes defining the first row of grid lines.")]
		public IList<IfcGridAxis> UAxes { get { return this._UAxes; } }
	
		[Description("List of grid axes defining the second row of grid lines.")]
		public IList<IfcGridAxis> VAxes { get { return this._VAxes; } }
	
		[Description("List of grid axes defining the third row of grid lines. It may be given in the ca" +
	    "se of a triangular grid.")]
		public IList<IfcGridAxis> WAxes { get { return this._WAxes; } }
	
		[Description(@"<EPM-HTML>
	Relationship to a spatial structure element, to which the grid is primarily associated.
	<blockquote><small><font color=""#FF0000"">IFC2x PLATFORM CHANGE&nbsp; The inverse relationship has been added to <I>IfcGrid</I> with upward compatibility</font>
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcRelContainedInSpatialStructure> ContainedInStructure { get { return this._ContainedInStructure; } }
	
	
	}
	
}
