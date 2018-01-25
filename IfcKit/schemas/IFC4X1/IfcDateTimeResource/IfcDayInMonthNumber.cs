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
	[Guid("0c42411a-5567-46b3-bef9-616aab9e1028")]
	public partial struct IfcDayInMonthNumber
	{
		[XmlText]
		public Int64 Value;
	
		public IfcDayInMonthNumber(Int64 value)
		{
			this.Value = value;
		}
	}
	
}
