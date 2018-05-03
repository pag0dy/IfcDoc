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


namespace BuildingSmart.IFC.IfcConstraintResource
{
	public enum IfcLogicalOperatorEnum
	{
		[Description("Defines a relationship between operands whereby the result is true if all operand" +
	    "s are true, and false if at least one operand is false.")]
		LOGICALAND = 1,
	
		[Description("Defines a relationship between operands whereby the result is true if at least on" +
	    "e operand is true, and false if all operands are false.")]
		LOGICALOR = 2,
	
		[Description("Defines a relationship between operands whereby the result is true if exactly one" +
	    " operand is true (exclusive or).")]
		LOGICALXOR = 3,
	
		[Description("Defines a relationship between operands whereby the result is true if at least on" +
	    "e operand is false, and false if all operands are true.")]
		LOGICALNOTAND = 4,
	
		[Description("Defines a relationship between operands whereby the result is true if all operand" +
	    "s are false, and false if at least one operand is true.")]
		LOGICALNOTOR = 5,
	
	}
}
