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
	public enum IfcAudioVisualApplianceTypeEnum
	{
		[Description("A device that receives an audio signal and amplifies it to play through speakers." +
	    "")]
		AMPLIFIER = 1,
	
		[Description(@"A device that records images, either as a still photograph or as moving images known as videos or movies.  Note that a camera may operate with light from the visible spectrum or from other parts of the electromagnetic spectrum such as infrared or ultraviolet.")]
		CAMERA = 2,
	
		[Description("An electronic device that represents information in visual form such as a flat-pa" +
	    "nel display or television.")]
		DISPLAY = 3,
	
		[Description(@"An acoustic-to-electric transducer or sensor that converts sound into an electrical signal.  Microphones types in use include electromagnetic induction (dynamic microphones), capacitance change (condenser microphones) or piezoelectric generation to produce the signal from mechanical vibration.")]
		MICROPHONE = 4,
	
		[Description("A device that plays audio and/or video content directly or to another device, hav" +
	    "ing fixed or removable storage media.")]
		PLAYER = 5,
	
		[Description("An apparatus for projecting a picture on a screen. Whether the device is an overh" +
	    "ead, slide projector, or a film projector, it is usually referred to as simply a" +
	    " projector.")]
		PROJECTOR = 6,
	
		[Description("A device that receives audio and/or video signals, switches sources, and amplifie" +
	    "s signals to play through speakers.")]
		RECEIVER = 7,
	
		[Description("A loudspeaker, speaker, or speaker system is an electroacoustical transducer that" +
	    " converts an electrical signal to sound.")]
		SPEAKER = 8,
	
		[Description("A device that receives audio and/or video signals, switches sources, and transmit" +
	    "s signals to downstream devices.")]
		SWITCHER = 9,
	
		[Description("A telecommunications device that is used to transmit and receive sound, and optio" +
	    "nally video.")]
		TELEPHONE = 10,
	
		[Description("An electronic receiver that detects, demodulates, and amplifies transmitted signa" +
	    "ls.")]
		TUNER = 11,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
