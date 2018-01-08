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
	[Guid("645aac37-12b4-454a-a956-53ef3087f755")]
	public partial struct IfcMonthInYearNumber
	{
		[XmlText]
		public Int64 Value;
	
		public IfcMonthInYearNumber(Int64 value)
		{
			this.Value = value;
		}
	}
	
}
