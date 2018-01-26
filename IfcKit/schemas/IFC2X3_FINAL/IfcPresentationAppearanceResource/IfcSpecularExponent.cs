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
	[Guid("1cbccaa8-8e20-4d76-9a62-7ecdf4b693f0")]
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
