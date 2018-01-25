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
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialPropertyResource;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("440545a0-993e-4d1f-976f-6369dcd98a3d")]
	public enum IfcThermalLoadSourceEnum
	{
		PEOPLE = 1,
	
		LIGHTING = 2,
	
		EQUIPMENT = 3,
	
		VENTILATIONINDOORAIR = 4,
	
		VENTILATIONOUTSIDEAIR = 5,
	
		RECIRCULATEDAIR = 6,
	
		EXHAUSTAIR = 7,
	
		AIREXCHANGERATE = 8,
	
		DRYBULBTEMPERATURE = 9,
	
		RELATIVEHUMIDITY = 10,
	
		INFILTRATION = 11,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
