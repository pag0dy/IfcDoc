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
	[Guid("edeb1de5-4f00-43b2-8746-ad8d66e56e18")]
	public partial struct IfcTextAlignment
	{
		[XmlText]
		public String Value;
	
		public IfcTextAlignment(String value)
		{
			this.Value = value;
		}
	}
	
}
