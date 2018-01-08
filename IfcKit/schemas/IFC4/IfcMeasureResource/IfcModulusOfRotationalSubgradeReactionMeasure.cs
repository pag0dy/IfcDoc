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
	[Guid("f872b6a3-ff4e-4d55-948f-780502e4b939")]
	public partial struct IfcModulusOfRotationalSubgradeReactionMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcDerivedMeasureValue,
		BuildingSmart.IFC.IfcStructuralLoadResource.IfcModulusOfRotationalSubgradeReactionSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcModulusOfRotationalSubgradeReactionMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
