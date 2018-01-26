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
	[Guid("41f309c9-a20d-4f1a-a798-a476d2bc5d8c")]
	public partial struct IfcSpecularExponent :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcSpecularHighlightSelect
	{
		[XmlText]
		public Double Value;
	
		public IfcSpecularExponent(Double value)
		{
			this.Value = value;
		}
	}
	
}
