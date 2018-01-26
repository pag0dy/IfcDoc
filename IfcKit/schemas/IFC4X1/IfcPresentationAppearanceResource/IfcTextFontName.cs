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
	[Guid("35803e05-3697-4be5-ac82-04eda1b4f43b")]
	public partial struct IfcTextFontName
	{
		[XmlText]
		public String Value;
	
		public IfcTextFontName(String value)
		{
			this.Value = value;
		}
	}
	
}
