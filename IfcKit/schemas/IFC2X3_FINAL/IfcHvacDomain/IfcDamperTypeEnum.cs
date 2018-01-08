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
	[Guid("657f39ba-97c4-4e78-9c8b-e3898314f388")]
	public enum IfcDamperTypeEnum
	{
		CONTROLDAMPER = 1,
	
		FIREDAMPER = 2,
	
		SMOKEDAMPER = 3,
	
		FIRESMOKEDAMPER = 4,
	
		BACKDRAFTDAMPER = 5,
	
		RELIEFDAMPER = 6,
	
		BLASTDAMPER = 7,
	
		GRAVITYDAMPER = 8,
	
		GRAVITYRELIEFDAMPER = 9,
	
		BALANCINGDAMPER = 10,
	
		FUMEHOODEXHAUST = 11,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
