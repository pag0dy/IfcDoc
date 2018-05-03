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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcCsgSolid : IfcSolidModel
	{
		[DataMember(Order = 0)] 
		[Description("Boolean expression of primitives and regularized operators describing the solid. The root of the tree of Boolean expressions is given explicitly as an <em>IfcBooleanResult</em> entitiy or as a primitive (subtypes of <em>IfcCsgPrimitive3D</em>).  </EPM-HMTL>")]
		[Required()]
		public IfcCsgSelect TreeRootExpression { get; set; }
	
	
		public IfcCsgSolid(IfcCsgSelect __TreeRootExpression)
		{
			this.TreeRootExpression = __TreeRootExpression;
		}
	
	
	}
	
}
