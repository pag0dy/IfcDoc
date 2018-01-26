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


namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("4ad31f65-4cec-4f7d-823e-bf7f9f3f99e9")]
	public enum IfcElementCompositionEnum
	{
		[Description("A group or aggregation of similar elements.")]
		COMPLEX = 1,
	
		[Description("An (undivided) element itself.")]
		ELEMENT = 2,
	
		[Description("A subelement or part.")]
		PARTIAL = 3,
	
	}
}
