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


namespace BuildingSmart.IFC.IfcDateTimeResource
{
	[Guid("20ae0f87-3185-4acb-85a7-2a854f3f6820")]
	public partial struct IfcDaylightSavingHour
	{
		[XmlText]
		public Int64 Value;
	
		public IfcDaylightSavingHour(Int64 value)
		{
			this.Value = value;
		}
	}
	
}
