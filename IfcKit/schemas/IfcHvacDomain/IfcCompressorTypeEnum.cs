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


namespace BuildingSmart.IFC.IfcHvacDomain
{
	public enum IfcCompressorTypeEnum
	{
		[Description("The pressure of refrigerant vapor is increased by a continuous transfer of angula" +
	    "r momentum from a rotating member to the vapor followed by conversion of this mo" +
	    "mentum into static pressure.")]
		DYNAMIC = 1,
	
		[Description("Positive-displacement compressor using a piston driven by a connecting rod from a" +
	    " crankshaft.")]
		RECIPROCATING = 2,
	
		[Description("Positive-displacement compressor using a roller or rotor device.")]
		ROTARY = 3,
	
		[Description("Positive-displacement compressor using two inter-fitting, spiral-shaped scroll me" +
	    "mbers.")]
		SCROLL = 4,
	
		[Description("Positive-displacement compressor using a rolling motion of one circle outside or " +
	    "inside the circumference of a basic circle and produce either epitrochoids or hy" +
	    "potrochoids.")]
		TROCHOIDAL = 5,
	
		[Description("Positive-displacement reciprocating compressor where vapor is compressed in a sin" +
	    "gle stage.")]
		SINGLESTAGE = 6,
	
		[Description("Positive-displacement reciprocating compressor where pressure is increased by a b" +
	    "ooster.")]
		BOOSTER = 7,
	
		[Description("Positive-displacement reciprocating compressor where the shaft extends through a " +
	    "seal in the crankcase for an external drive.")]
		OPENTYPE = 8,
	
		[Description("Positive-displacement reciprocating compressor where the motor and compressor are" +
	    " contained within the same housing, with the motor shaft integral with the compr" +
	    "essor crankshaft and the motor in contact with refrigerant.")]
		HERMETIC = 9,
	
		[Description("Positive-displacement reciprocating compressor where the hermetic compressors use" +
	    " bolted construction amenable to field repair.")]
		SEMIHERMETIC = 10,
	
		[Description("Positive-displacement reciprocating compressor where the motor compressor is moun" +
	    "ted inside a steel shell, which, in turn is sealed by welding.")]
		WELDEDSHELLHERMETIC = 11,
	
		[Description("Positive-displacement rotary compressor using a roller mounted on the eccentric o" +
	    "f a shaft with a single vane in the nonrotating cylindrical housing.")]
		ROLLINGPISTON = 12,
	
		[Description("Positive-displacement rotary compressor using a roller mounted on the eccentric o" +
	    "f a shaft with multiple vanes in the nontotating cylindrical housing.")]
		ROTARYVANE = 13,
	
		[Description("Positive-displacement rotary compressor using a single cylindrical main rotor tha" +
	    "t works with a pair of gate rotors.")]
		SINGLESCREW = 14,
	
		[Description("Positive-displacement rotary compressor using two mating helically grooved rotors" +
	    ", male (lobes) and female (flutes) in a stationary housing with inlet and outlet" +
	    " gas ports.")]
		TWINSCREW = 15,
	
		[Description("User-defined compressor type.")]
		USERDEFINED = -1,
	
		[Description("Undefined compressor type.")]
		NOTDEFINED = 0,
	
	}
}
