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
using BuildingSmart.IFC.IfcStructuralLoadResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("79f64af6-81ab-4779-a424-b1df2d05afd6")]
	public partial class IfcStructuralPlanarActionVarying : IfcStructuralPlanarAction
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcShapeAspect _VaryingAppliedLoadLocation;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(2)]
		IList<IfcStructuralLoad> _SubsequentAppliedLoads = new List<IfcStructuralLoad>();
	
	
		public IfcStructuralPlanarActionVarying()
		{
		}
	
		public IfcStructuralPlanarActionVarying(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcObjectPlacement __ObjectPlacement, IfcProductRepresentation __Representation, IfcStructuralLoad __AppliedLoad, IfcGlobalOrLocalEnum __GlobalOrLocal, Boolean __DestabilizingLoad, IfcStructuralReaction __CausedBy, IfcProjectedOrTrueLengthEnum __ProjectedOrTrue, IfcShapeAspect __VaryingAppliedLoadLocation, IfcStructuralLoad[] __SubsequentAppliedLoads)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __ObjectPlacement, __Representation, __AppliedLoad, __GlobalOrLocal, __DestabilizingLoad, __CausedBy, __ProjectedOrTrue)
		{
			this._VaryingAppliedLoadLocation = __VaryingAppliedLoadLocation;
			this._SubsequentAppliedLoads = new List<IfcStructuralLoad>(__SubsequentAppliedLoads);
		}
	
		[Description(@"A shape aspect, containing a list of shape representations, each defining either one Cartesian point or one point on curve (by parameter values) which are needed to provide the positions of the VaryingAppliedLoads. The values contained in the list of IfcShapeAspect.ShapeRepresentations correspond to the values at the same position in the list VaryingAppliedLoads.")]
		public IfcShapeAspect VaryingAppliedLoadLocation { get { return this._VaryingAppliedLoadLocation; } set { this._VaryingAppliedLoadLocation = value;} }
	
		[Description("A list containing load values which are assigned to the position defined through " +
	    "the shape aspect. The first load is already defined by the inherited attribute A" +
	    "ppliedLoad and shall not be contained in this list.")]
		public IList<IfcStructuralLoad> SubsequentAppliedLoads { get { return this._SubsequentAppliedLoads; } }
	
		public new IList<IfcStructuralLoad> VaryingAppliedLoads { get { return null; } }
	
	
	}
	
}
