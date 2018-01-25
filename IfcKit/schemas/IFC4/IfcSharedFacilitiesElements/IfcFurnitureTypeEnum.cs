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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("b0721a11-753e-44ee-b595-bc550b79b1c3")]
	public enum IfcFurnitureTypeEnum
	{
		[Description("Furniture for seating a single person.")]
		CHAIR = 1,
	
		[Description("Furniture with a countertop for multiple people.")]
		TABLE = 2,
	
		[Description("Furniture with a countertop and optional drawers for a single person.")]
		DESK = 3,
	
		[Description("Furniture for sleeping.")]
		BED = 4,
	
		[Description("Furniture with sliding drawers for storing files.")]
		FILECABINET = 5,
	
		[Description("Furniture for storing books or other items.")]
		SHELF = 6,
	
		[Description("Furniture for seating multiple people.")]
		SOFA = 7,
	
		[Description("User-defined type.")]
		USERDEFINED = -1,
	
		[Description("Undefined type.")]
		NOTDEFINED = 0,
	
	}
}
