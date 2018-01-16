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
	[Guid("946a6db8-f79d-4749-802d-7079624d173e")]
	public partial struct IfcMinuteInHour
	{
		[XmlText]
		public Int64 Value;
	
		public IfcMinuteInHour(Int64 value)
		{
			this.Value = value;
		}
	}
	
}
