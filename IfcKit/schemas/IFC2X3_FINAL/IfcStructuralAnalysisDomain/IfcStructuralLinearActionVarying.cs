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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcStructuralLoadResource;

namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	[Guid("8a2e92b4-7bc4-4e67-ae3e-629e171ffb1f")]
	public partial class IfcStructuralLinearActionVarying : IfcStructuralLinearAction
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcShapeAspect _VaryingAppliedLoadLocation;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcStructuralLoad> _SubsequentAppliedLoads = new List<IfcStructuralLoad>();
	
	
		[Description(@"A shape aspect, containing a list of shape representations, each defining either one Cartesian point or one point on curve (by parameter values) which are needed to provide the positions of the VaryingAppliedLoads. The values contained in the list of IfcShapeAspect.ShapeRepresentations correspond to the values at the same position in the list VaryingAppliedLoads.")]
		public IfcShapeAspect VaryingAppliedLoadLocation { get { return this._VaryingAppliedLoadLocation; } set { this._VaryingAppliedLoadLocation = value;} }
	
		[Description("A list containing load values which are assigned to the position defined through " +
	    "the shape aspect. The first load is already defined by the inherited attribute A" +
	    "ppliedLoad and shall not be contained in this list.")]
		public IList<IfcStructuralLoad> SubsequentAppliedLoads { get { return this._SubsequentAppliedLoads; } }
	
	
	}
	
}
