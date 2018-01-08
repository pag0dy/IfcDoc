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
	[Guid("d04cfc70-6990-4fa0-97ee-21ef68d32ca6")]
	public partial struct IfcLabel :
		BuildingSmart.IFC.IfcFacilitiesMgmtDomain.IfcConditionCriterionSelect,
		BuildingSmart.IFC.IfcMeasureResource.IfcSimpleValue
	{
		[XmlText]
		public String Value;
	
		public IfcLabel(String value)
		{
			this.Value = value;
		}
	}
	
}
