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
	[Guid("3d4616c2-ef4d-4143-b236-06f85b9d563a")]
	public enum IfcCableCarrierSegmentTypeEnum
	{
		CABLELADDERSEGMENT = 1,
	
		CABLETRAYSEGMENT = 2,
	
		CABLETRUNKINGSEGMENT = 3,
	
		CONDUITSEGMENT = 4,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
