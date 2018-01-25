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
	[Guid("4e2569b1-6ae8-47ca-8bc2-23920a37fbd8")]
	public partial struct IfcDuration :
		BuildingSmart.IFC.IfcMeasureResource.IfcSimpleValue,
		BuildingSmart.IFC.IfcDateTimeResource.IfcTimeOrRatioSelect
	{
		[XmlText]
		public String Value;
	
		public IfcDuration(String value)
		{
			this.Value = value;
		}
	}
	
}
