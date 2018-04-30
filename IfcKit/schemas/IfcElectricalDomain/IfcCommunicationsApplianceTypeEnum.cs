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
	public enum IfcCommunicationsApplianceTypeEnum
	{
		[Description("A transducer designed to transmit or receive electromagnetic waves.")]
		ANTENNA = 1,
	
		[Description("A desktop, laptop, tablet, or other type of computer that can be moved from one p" +
	    "lace to another and connected to an electrical supply via a plugged outlet.")]
		COMPUTER = 2,
	
		[Description("A machine that has the primary function of transmitting a facsimile copy of print" +
	    "ed matter using a telephone line.")]
		FAX = 3,
	
		[Description("A gateway connects multiple network segments with different protocols at all laye" +
	    "rs (layers 1-7) of the Open Systems Interconnection (OSI) model.")]
		GATEWAY = 4,
	
		[Description("A modem (from modulator-demodulator) is a device that modulates an analog carrier" +
	    " signal to encode digital information, and also demodulates such a carrier signa" +
	    "l to decode the transmitted information.")]
		MODEM = 5,
	
		[Description("A network appliance performs a dedicated function such as firewall protection, co" +
	    "ntent filtering, load balancing, or equipment management.")]
		NETWORKAPPLIANCE = 6,
	
		[Description("A network bridge connects multiple network segments at the data link layer (layer" +
	    " 2) of the OSI model, and the term layer 2 switch is very often used interchange" +
	    "ably with bridge.")]
		NETWORKBRIDGE = 7,
	
		[Description("A network hub connects multiple network segments at the physical layer (layer 1) " +
	    "of the OSI model.")]
		NETWORKHUB = 8,
	
		[Description("A machine that has the primary function of printing text and/or graphics onto pap" +
	    "er or other media.")]
		PRINTER = 9,
	
		[Description("A repeater is an electronic device that receives a signal and retransmits it at a" +
	    " higher level and/or higher power, or onto the other side of an obstruction, so " +
	    "that the signal can cover longer distances without degradation.")]
		REPEATER = 10,
	
		[Description("A router is a networking device whose software and hardware are usually tailored " +
	    "to the tasks of routing and forwarding information. For example, on the Internet" +
	    ", information is directed to various paths by routers.")]
		ROUTER = 11,
	
		[Description("A machine that has the primary function of scanning the content of printed matter" +
	    " and converting it to digital format that can be stored in a computer.")]
		SCANNER = 12,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
