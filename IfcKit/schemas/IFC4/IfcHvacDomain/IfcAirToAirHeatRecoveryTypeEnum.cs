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
	[Guid("86afaf68-bf1b-41fc-950e-8e174ebee678")]
	public enum IfcAirToAirHeatRecoveryTypeEnum
	{
		FIXEDPLATECOUNTERFLOWEXCHANGER = 1,
	
		FIXEDPLATECROSSFLOWEXCHANGER = 2,
	
		FIXEDPLATEPARALLELFLOWEXCHANGER = 3,
	
		ROTARYWHEEL = 4,
	
		RUNAROUNDCOILLOOP = 5,
	
		HEATPIPE = 6,
	
		TWINTOWERENTHALPYRECOVERYLOOPS = 7,
	
		THERMOSIPHONSEALEDTUBEHEATEXCHANGERS = 8,
	
		THERMOSIPHONCOILTYPEHEATEXCHANGERS = 9,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
