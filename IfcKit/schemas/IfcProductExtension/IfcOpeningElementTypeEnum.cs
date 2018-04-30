// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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
	public enum IfcOpeningElementTypeEnum
	{
		[Description(@"An opening as subtraction feature that cuts through the element it voids. It thereby creates a hole. An opening in addiion have a particular meaning for either providing a void for doors or windows, or an opening to permit flow of air and passing of light.")]
		OPENING = 1,
	
		[Description("An opening as subtraction feature that does not cut through the element it voids." +
	    " It creates a niche or similar voiding pattern.")]
		RECESS = 2,
	
		[Description("User-defined opening element.")]
		USERDEFINED = -1,
	
		[Description("Undefined opening element.")]
		NOTDEFINED = 0,
	
	}
}
