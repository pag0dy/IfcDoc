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


namespace BuildingSmart.IFC.IfcProductExtension
{
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
