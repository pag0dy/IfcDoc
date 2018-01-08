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
	[Guid("9cdbc084-dee1-43de-9ed2-efe2e4264613")]
	public partial struct IfcAmountOfSubstanceMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcMeasureValue
	{
		[XmlText]
		public Double Value;
	
		public IfcAmountOfSubstanceMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
