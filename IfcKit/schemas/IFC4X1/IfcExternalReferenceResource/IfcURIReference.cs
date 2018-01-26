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


namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("a42d2807-6ecc-4243-9ce7-adeb1950089a")]
	public partial struct IfcURIReference
	{
		[XmlText]
		public String Value;
	
		public IfcURIReference(String value)
		{
			this.Value = value;
		}
	}
	
}
