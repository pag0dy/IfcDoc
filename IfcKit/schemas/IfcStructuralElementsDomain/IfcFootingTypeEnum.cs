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


namespace BuildingSmart.IFC.IfcStructuralElementsDomain
{
	public enum IfcFootingTypeEnum
	{
		[Description("A foundation construction type used in underwater construction.")]
		CAISSON_FOUNDATION = 1,
	
		[Description(@"Footing elements that are in bending and are supported clear of the ground. They will normally span between piers, piles or pile caps. They are distinguished from beams in the building superstructure since they will normally require a lower grade of finish. They are distinguished from <em>STRIP_FOOTING</em> since they are clear of the ground surface and hence require support to the lower face while the concrete is curing.")]
		FOOTING_BEAM = 2,
	
		[Description("An element that transfers the load of a single column (possibly two) to the groun" +
	    "d.")]
		PAD_FOOTING = 3,
	
		[Description("An element that transfers the load from a column or group of columns to a pier or" +
	    " pile or group of piers or piles.")]
		PILE_CAP = 4,
	
		[Description("A linear element that transfers loads into the ground from either a continuous el" +
	    "ement, such as a wall, or from a series of elements, such as columns.")]
		STRIP_FOOTING = 5,
	
		[Description("Special types of footings which meet specific local requirements.")]
		USERDEFINED = -1,
	
		[Description("The type of footing is not defined.")]
		NOTDEFINED = 0,
	
	}
}
