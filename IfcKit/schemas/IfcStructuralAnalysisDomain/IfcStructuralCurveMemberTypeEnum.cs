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


namespace BuildingSmart.IFC.IfcStructuralAnalysisDomain
{
	public enum IfcStructuralCurveMemberTypeEnum
	{
		[Description("A member with capacity to carry transverse and axial loads, i.e. a beam. Its actu" +
	    "al joints may be rigid or pinned. Typically used in rigid frames.")]
		RIGID_JOINED_MEMBER = 1,
	
		[Description("A member with capacity to carry axial loads only, i.e. a link. Typically used in " +
	    "trusses.")]
		PIN_JOINED_MEMBER = 2,
	
		[Description("A tension member which is able to carry transverse loads only under large deflect" +
	    "ion.")]
		CABLE = 3,
	
		[Description("A member without compressional stiffness.")]
		TENSION_MEMBER = 4,
	
		[Description("A member without tensional stiffness.")]
		COMPRESSION_MEMBER = 5,
	
		[Description("A specially defined member.")]
		USERDEFINED = -1,
	
		[Description("A member without further categorization.")]
		NOTDEFINED = 0,
	
	}
}
