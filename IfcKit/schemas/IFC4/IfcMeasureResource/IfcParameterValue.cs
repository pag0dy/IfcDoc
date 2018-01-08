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


namespace BuildingSmart.IFC.IfcMeasureResource
{
	[Guid("18b81db8-1d21-43cd-b028-322e743fface")]
	public partial struct IfcParameterValue :
		BuildingSmart.IFC.IfcMeasureResource.IfcMeasureValue,
		BuildingSmart.IFC.IfcGeometryResource.IfcTrimmingSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcParameterValue(Double value)
		{
			this.Value = value;
		}
	}
	
}
