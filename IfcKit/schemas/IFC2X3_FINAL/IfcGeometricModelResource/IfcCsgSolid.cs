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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("274baa9b-e977-4d41-b4ed-98f3fe7fc3ad")]
	public partial class IfcCsgSolid : IfcSolidModel
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCsgSelect _TreeRootExpression;
	
	
		[Description("Boolean expression of regularized operators describing the solid. The root of the" +
	    " tree of Boolean expressions is given explicitly as an IfcBooleanResult (the onl" +
	    "y item in the Select IfcCsgSelect).")]
		public IfcCsgSelect TreeRootExpression { get { return this._TreeRootExpression; } set { this._TreeRootExpression = value;} }
	
	
	}
	
}
