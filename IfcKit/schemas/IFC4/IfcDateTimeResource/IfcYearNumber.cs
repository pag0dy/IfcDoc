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
	[Guid("90c022bf-26c4-47f8-a878-ceab3e709fc1")]
	public partial struct IfcYearNumber
	{
		[XmlText]
		public Int64 Value;
	
		public IfcYearNumber(Int64 value)
		{
			this.Value = value;
		}
	}
	
}
