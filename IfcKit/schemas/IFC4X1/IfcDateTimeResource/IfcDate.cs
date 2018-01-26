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
	[Guid("e3930d95-d03e-449e-965a-c87264896bce")]
	public partial struct IfcDate :
		BuildingSmart.IFC.IfcMeasureResource.IfcSimpleValue
	{
		[XmlText]
		public String Value;
	
		public IfcDate(String value)
		{
			this.Value = value;
		}
	}
	
}
