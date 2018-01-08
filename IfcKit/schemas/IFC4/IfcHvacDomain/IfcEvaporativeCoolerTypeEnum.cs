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
	[Guid("cd28a05d-efdb-4ca6-b365-a66ed22a1894")]
	public enum IfcEvaporativeCoolerTypeEnum
	{
		DIRECTEVAPORATIVERANDOMMEDIAAIRCOOLER = 1,
	
		DIRECTEVAPORATIVERIGIDMEDIAAIRCOOLER = 2,
	
		DIRECTEVAPORATIVESLINGERSPACKAGEDAIRCOOLER = 3,
	
		DIRECTEVAPORATIVEPACKAGEDROTARYAIRCOOLER = 4,
	
		DIRECTEVAPORATIVEAIRWASHER = 5,
	
		INDIRECTEVAPORATIVEPACKAGEAIRCOOLER = 6,
	
		INDIRECTEVAPORATIVEWETCOIL = 7,
	
		INDIRECTEVAPORATIVECOOLINGTOWERORCOILCOOLER = 8,
	
		INDIRECTDIRECTCOMBINATION = 9,
	
		USERDEFINED = -1,
	
		NOTDEFINED = 0,
	
	}
}
