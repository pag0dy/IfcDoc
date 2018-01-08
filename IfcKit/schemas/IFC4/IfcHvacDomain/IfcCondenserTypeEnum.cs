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

using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;

namespace BuildingSmart.IFC.IfcHvacDomain
{
	[Guid("bdc6c4e2-1bc4-4f7b-935f-2ff8a71a6ab9")]
	public enum IfcCondenserTypeEnum
	{
		AIRCOOLED = 1,
	
		EVAPORATIVECOOLED = 2,
	
		WATERCOOLED = 3,
	
		WATERCOOLEDBRAZEDPLATE = 4,
	
		WATERCOOLEDSHELLCOIL = 5,
	
		WATERCOOLEDSHELLTUBE = 6,
	
		WATERCOOLEDTUBEINTUBE = 7,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
