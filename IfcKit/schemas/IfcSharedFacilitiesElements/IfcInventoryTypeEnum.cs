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


namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	public enum IfcInventoryTypeEnum
	{
		[Description("A collection of asset instances of type IfcAsset.")]
		ASSETINVENTORY = 1,
	
		[Description("A collection of space instances of type IfcSpace.")]
		SPACEINVENTORY = 2,
	
		[Description("A collection of furniture instances of type IfcFurnishingElement.")]
		FURNITUREINVENTORY = 3,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
