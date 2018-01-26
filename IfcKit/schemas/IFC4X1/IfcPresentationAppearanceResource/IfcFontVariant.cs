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
	[Guid("5af73e06-d478-4f63-985c-c7659b253ded")]
	public partial struct IfcFontVariant
	{
		[XmlText]
		public String Value;
	
		public IfcFontVariant(String value)
		{
			this.Value = value;
		}
	}
	
}
