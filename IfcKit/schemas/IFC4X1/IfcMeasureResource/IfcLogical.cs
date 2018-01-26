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
	[Guid("2a191086-1f02-4f9e-afa0-d0ab049914e7")]
	public partial struct IfcLogical :
		BuildingSmart.IFC.IfcMeasureResource.IfcSimpleValue
	{
		[XmlText]
		public Boolean? Value;
	
		public IfcLogical(Boolean? value)
		{
			this.Value = value;
		}
	}
	
}
