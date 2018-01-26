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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("e7bc798b-f213-4320-9b4c-1bab121f3533")]
	public partial struct IfcLanguageId
	{
		[XmlText]
		public IfcIdentifier Value;
	
		public IfcLanguageId(IfcIdentifier value)
		{
			this.Value = value;
		}
		public IfcLanguageId(String value)
		{
			this.Value = new IfcIdentifier(value);
		}
	}
	
}
