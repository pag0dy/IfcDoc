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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcTimeSeriesResource
{
	[Guid("724be972-8c35-41bf-898d-85dbf1a9ea76")]
	public enum IfcDataOriginEnum
	{
		MEASURED = 1,
	
		PREDICTED = 2,
	
		SIMULATED = 3,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
