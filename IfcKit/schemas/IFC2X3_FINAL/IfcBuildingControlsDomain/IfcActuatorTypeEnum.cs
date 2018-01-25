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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcBuildingControlsDomain
{
	[Guid("3912b4e5-15ff-4cb0-b8a9-9b8aeb5c2529")]
	public enum IfcActuatorTypeEnum
	{
		ELECTRICACTUATOR = 1,
	
		HANDOPERATEDACTUATOR = 2,
	
		HYDRAULICACTUATOR = 3,
	
		PNEUMATICACTUATOR = 4,
	
		THERMOSTATICACTUATOR = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
