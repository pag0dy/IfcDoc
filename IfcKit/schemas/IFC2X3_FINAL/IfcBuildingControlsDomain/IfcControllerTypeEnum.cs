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
	[Guid("306ed67f-7492-4acd-9bd1-8fae78d81860")]
	public enum IfcControllerTypeEnum
	{
		FLOATING = 1,
	
		PROPORTIONAL = 2,
	
		PROPORTIONALINTEGRAL = 3,
	
		PROPORTIONALINTEGRALDERIVATIVE = 4,
	
		TIMEDTWOPOSITION = 5,
	
		TWOPOSITION = 6,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
