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

using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;

namespace BuildingSmart.IFC.IfcElectricalDomain
{
	[Guid("b2535988-9815-4668-9676-4d1f7bbba831")]
	public enum IfcElectricGeneratorTypeEnum
	{
		[Description("Combined heat and power supply, used not only as a source of electric energy but " +
	    "also as a heating source for the building. It may therefore be not only part of " +
	    "an electrical system but also of a heating system.")]
		CHP = 1,
	
		[Description("Electrical generator with a fuel-driven engine, for example a diesel-driven emerg" +
	    "ency power supply.")]
		ENGINEGENERATOR = 2,
	
		[Description("Electrical generator which does not include its source of kinetic energy, that is" +
	    ", a motor, engine, or turbine are all modeled separately.")]
		STANDALONE = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
