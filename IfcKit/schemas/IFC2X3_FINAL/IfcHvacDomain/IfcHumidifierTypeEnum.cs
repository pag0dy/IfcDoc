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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("d543a4bc-7682-4345-8f8b-0e015e7faf4f")]
	public enum IfcHumidifierTypeEnum
	{
		STEAMINJECTION = 1,
	
		ADIABATICAIRWASHER = 2,
	
		ADIABATICPAN = 3,
	
		ADIABATICWETTEDELEMENT = 4,
	
		ADIABATICATOMIZING = 5,
	
		ADIABATICULTRASONIC = 6,
	
		ADIABATICRIGIDMEDIA = 7,
	
		ADIABATICCOMPRESSEDAIRNOZZLE = 8,
	
		ASSISTEDELECTRIC = 9,
	
		ASSISTEDNATURALGAS = 10,
	
		ASSISTEDPROPANE = 11,
	
		ASSISTEDBUTANE = 12,
	
		ASSISTEDSTEAM = 13,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
