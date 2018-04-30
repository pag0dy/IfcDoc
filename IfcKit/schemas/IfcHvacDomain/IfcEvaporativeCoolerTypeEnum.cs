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
	public enum IfcEvaporativeCoolerTypeEnum
	{
		[Description("Direct evaporative random media air cooler: Cools the air stream by evaporating w" +
	    "ater dircectly into the air stream using coolers with evaporative pads, usually " +
	    "of aspen wood or plastic fiber/foam.")]
		DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER = 1,
	
		[Description("Direct evaporative rigid media air cooler: Cools the air stream by evaporating wa" +
	    "ter dircectly into the air stream using coolers with sheets of rigid, corrugated" +
	    " material as the wetted surface.")]
		DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER = 2,
	
		[Description("Direct evaporative slingers packaged air cooler: Cools the air stream by evaporat" +
	    "ing water dircectly into the air stream using coolers with a water slinger in an" +
	    " evaporative cooling section and a fan section.")]
		DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER = 3,
	
		[Description("Direct evaporative packaged rotary air cooler: Cools the air stream by evaporatin" +
	    "g water dircectly into the air stream using coolers that wet and wash the evapor" +
	    "ative pad by rotating it through a water bath.")]
		DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER = 4,
	
		[Description(@"Direct evaporative air washer: Cools the air stream by evaporating water dircectly into the air stream using coolers with spray-type air washer consist of a chamber or casing containing spray nozzles, and tank for collecting spray water, and an eliminator section for removing entrained drops of water from the air.")]
		DIRECTEVAPORATIVEAIRWASHER = 5,
	
		[Description(@"Indirect evaporative package air cooler: Cools the air stream by evaporating water indirectly and without adding moisture into the air stream. On one side of the heat exchanger, the secondary air stream is cooled by evaporation, while on the other side of heat exchanger, the primary air stream (conditioned air to be supplied to the room) is sensibly cooled by the heat exchanger surfaces.")]
		INDIRECTEVAPORATIVEPACKAGEAIRCOOLER = 6,
	
		[Description(@"Indirect evaporative wet coil: Cools the air stream by evaporating water indirectly and without adding moisture into the air stream. Water is sprayed directly on the tubes of the heat exchanger where latent cooling takes place and the vaporization of the water on the outside of the heat exchanger tubes allows the simultaneous heat and mass transfer which removes heat from the supply air on the tube side.")]
		INDIRECTEVAPORATIVEWETCOIL = 7,
	
		[Description(@"Indirect evaporative cooling tower or coil cooler: Cools the air stream by evaporating water indirectly and without adding moisture into the air stream using a combination of a cooling tower or other evaporative water cooler with a water-to-air heat exchanger coil and water circulating pump.")]
		INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER = 8,
	
		[Description("Indirect/Direct combination: Cools the air stream by evaporating water indirectly" +
	    " and without adding moisture into the air stream using a two-stage cooler with a" +
	    " first-stage indirect evaporative cooler and second-stage direct evaporative coo" +
	    "ler.")]
		INDIRECTDIRECTCOMBINATION = 9,
	
		[Description("User-defined evaporative cooler type.")]
		USERDEFINED = -1,
	
		[Description("Undefined evaporative cooler type.")]
		NOTDEFINED = 0,
	
	}
}
