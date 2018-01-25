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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedComponentElements
{
	[Guid("f28c4b99-9bf9-4934-befa-a179ed76232f")]
	public enum IfcBuildingElementPartTypeEnum
	{
		[Description("The part provides thermal insulation, for example as insulation layer between wal" +
	    "l panels in sandwich walls or as infill in stud walls.")]
		INSULATION = 1,
	
		[Description("The part is a precast panel, usually as an internal or external layer in a sandwi" +
	    "ch wall panel.")]
		PRECASTPANEL = 2,
	
		[Description("User-defined accessory.")]
		USERDEFINED = -1,
	
		[Description("Undefined accessory.")]
		NOTDEFINED = 0,
	
	}
}
