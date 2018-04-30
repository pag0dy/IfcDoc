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


namespace BuildingSmart.IFC.IfcElectricalDomain
{
	public enum IfcLampTypeEnum
	{
		[Description("A fluorescent lamp having a compact form factor produced by shaping the tube.")]
		COMPACTFLUORESCENT = 1,
	
		[Description("A typically tubular discharge lamp in which most of the light is emitted by one o" +
	    "r several layers of phosphors excited by ultraviolet radiation from the discharg" +
	    "e.")]
		FLUORESCENT = 2,
	
		[Description("An incandescent lamp in which a tungsten filament is sealed into a compact transp" +
	    "ort envelope filled with an inert gas and a small amount of halogen such as iodi" +
	    "ne or bromine.")]
		HALOGEN = 3,
	
		[Description("A discharge lamp in which most of the light is emitted by exciting mercury at hig" +
	    "h pressure.")]
		HIGHPRESSUREMERCURY = 4,
	
		[Description("A discharge lamp in which most of the light is emitted by exciting sodium at high" +
	    " pressure.")]
		HIGHPRESSURESODIUM = 5,
	
		[Description("A solid state lamp that uses light-emitting diodes as the source of light.")]
		LED = 6,
	
		[Description("A discharge lamp in which most of the light is emitted by exciting a metal halide" +
	    ".")]
		METALHALIDE = 7,
	
		[Description("A solid state lamp that uses light-emitting diodes as the source of light whose e" +
	    "missive electroluminescent layer is composed of a film of organic compounds.")]
		OLED = 8,
	
		[Description("A lamp that emits light by passing an electrical current through a tungsten wire " +
	    "filament in a near vacuum.")]
		TUNGSTENFILAMENT = 9,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
