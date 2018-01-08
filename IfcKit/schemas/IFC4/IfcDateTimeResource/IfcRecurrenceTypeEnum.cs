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
using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("e1785355-bfe9-45c1-9315-21500359980b")]
	public enum IfcRecurrenceTypeEnum
	{
		DAILY = 1,
	
		WEEKLY = 2,
	
		MONTHLY_BY_DAY_OF_MONTH = 3,
	
		MONTHLY_BY_POSITION = 4,
	
		BY_DAY_COUNT = 5,
	
		BY_WEEKDAY_COUNT = 6,
	
		YEARLY_BY_DAY_OF_MONTH = 7,
	
		YEARLY_BY_POSITION = 8,
	
	}
}
