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


namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("4c44d8df-27a6-4b48-b0e2-9a07efd6e642")]
	public partial struct IfcTextDecoration
	{
		[XmlText]
		public String Value;
	
		public IfcTextDecoration(String value)
		{
			this.Value = value;
		}
	}
	
}
