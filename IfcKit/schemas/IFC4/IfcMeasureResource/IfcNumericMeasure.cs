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

using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;

namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("2e99a2de-5976-4fb7-9671-b95ab8c69523")]
	public partial struct IfcNumericMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcMeasureValue
	{
		[XmlText]
		public Decimal Value;
	
		public IfcNumericMeasure(Decimal value)
		{
			this.Value = value;
		}
	}
	
}
