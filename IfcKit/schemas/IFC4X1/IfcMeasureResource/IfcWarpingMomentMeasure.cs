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
	[Guid("815d41cd-035f-4317-9f9e-5af33389091f")]
	public partial struct IfcWarpingMomentMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcDerivedMeasureValue,
		BuildingSmart.IFC.IfcStructuralLoadResource.IfcWarpingStiffnessSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcWarpingMomentMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
