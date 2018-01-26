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
	[Guid("ab684a10-9929-49b2-991a-ce9a77594e0e")]
	public partial struct IfcLuminousFluxMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcDerivedMeasureValue
	{
		[XmlText]
		public Double Value;
	
		public IfcLuminousFluxMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
