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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("33066633-cf11-455b-af76-a502e5affa9c")]
	public partial class IfcCsgSolid : IfcSolidModel
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCsgSelect _TreeRootExpression;
	
	
		public IfcCsgSolid()
		{
		}
	
		public IfcCsgSolid(IfcCsgSelect __TreeRootExpression)
		{
			this._TreeRootExpression = __TreeRootExpression;
		}
	
		[Description(@"Boolean expression of primitives and regularized operators describing the solid. The root of the tree of Boolean expressions is given explicitly as an <em>IfcBooleanResult</em> entitiy or as a primitive (subtypes of <em>IfcCsgPrimitive3D</em>).
	</EPM-HMTL>")]
		public IfcCsgSelect TreeRootExpression { get { return this._TreeRootExpression; } set { this._TreeRootExpression = value;} }
	
	
	}
	
}
