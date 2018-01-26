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
	[Guid("b071348d-3e08-4ae1-a193-ba601f2ab26a")]
	public partial struct IfcRotationalStiffnessMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcDerivedMeasureValue,
		BuildingSmart.IFC.IfcStructuralLoadResource.IfcRotationalStiffnessSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcRotationalStiffnessMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
