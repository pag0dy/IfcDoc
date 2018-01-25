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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("61fd2886-beef-4d12-816b-7bede5274866")]
	public enum IfcSwitchingDeviceTypeEnum
	{
		CONTACTOR = 1,
	
		EMERGENCYSTOP = 2,
	
		STARTER = 3,
	
		SWITCHDISCONNECTOR = 4,
	
		TOGGLESWITCH = 5,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
