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
	[Guid("3c47ec9e-49c3-45b3-b715-56c9c7a298c0")]
	public partial struct IfcModulusOfLinearSubgradeReactionMeasure :
		BuildingSmart.IFC.IfcMeasureResource.IfcDerivedMeasureValue,
		BuildingSmart.IFC.IfcStructuralLoadResource.IfcModulusOfTranslationalSubgradeReactionSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcModulusOfLinearSubgradeReactionMeasure(Double value)
		{
			this.Value = value;
		}
	}
	
}
