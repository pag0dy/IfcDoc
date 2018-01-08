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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("276b65b6-ad1b-4f76-9a7e-2ed708c3c554")]
	public partial class IfcBoundaryNodeConditionWarping : IfcBoundaryNodeCondition
	{
		[DataMember(Order=0)] 
		IfcWarpingStiffnessSelect _WarpingStiffness;
	
	
		[Description("Defines the warping stiffness value.")]
		public IfcWarpingStiffnessSelect WarpingStiffness { get { return this._WarpingStiffness; } set { this._WarpingStiffness = value;} }
	
	
	}
	
}
