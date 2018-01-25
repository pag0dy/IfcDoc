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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("c20a99dd-1e06-4e4e-9e8d-d41be8950380")]
	public enum IfcGridTypeEnum
	{
		[Description(@"An <em>IfcGrid</em> with straight u-axes and straight v-axes being perpendicular to each other. All grid axes being part of u-axes can be described by one axis line and all other axes being 2D offsets from this axis line. The same applies to all grid axes being part of V-axes.")]
		RECTANGULAR = 1,
	
		[Description("An <em>IfcGrid</em> with straight u-axes and curved v-axes. All grid axes being p" +
	    "art of V-axes have the same center point and are concentric circular arcs. All g" +
	    "rid axes being part of u-axes intersect at the same center point and rotate coun" +
	    "ter clockwise.")]
		RADIAL = 2,
	
		[Description("An <em>IfcGrid</em> with u-axes, v-axes, and w-axes all being co-linear axis line" +
	    "s with a 2D offset. The v-axes are at 60 degree rotated counter clockwise from t" +
	    "he u-axes, and the w-axes are at 120 degree rotated counter clockwise from the u" +
	    "-axes.")]
		TRIANGULAR = 3,
	
		[Description("An <em>IfcGrid</em> with u-axes, v-axes, and optionally w-axes that cannot be des" +
	    "cribed by the patterns.")]
		IRREGULAR = 4,
	
		[Description("Any other grid not conforming to any of the above restrictions.")]
		USERDEFINED = -1,
	
		[Description("Not known whether grid conforms to any standard type.")]
		NOTDEFINED = 0,
	
	}
}
