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


namespace BuildingSmart.IFC.IfcPresentationResource
{
	[Guid("49fff44a-390a-40ad-8d04-fd1ff8538dd7")]
	public partial struct IfcPresentableText
	{
		[XmlText]
		public String Value;
	
		public IfcPresentableText(String value)
		{
			this.Value = value;
		}
	}
	
}
