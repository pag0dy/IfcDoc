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
	[Guid("2a0a31c3-599a-4a77-a001-daa5b627e73f")]
	public partial struct IfcPlaneAngleMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcMeasureValue,
		BuildingSmart.IFC.IfcStructuralAnalysisDomain.IfcOrientationSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcPlaneAngleMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
