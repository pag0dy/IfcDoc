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
	[Guid("25ccf99a-1eaa-4b97-9f86-66335a753f92")]
	public partial class IfcOccupant : IfcActor
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcOccupantTypeEnum? _PredefinedType;
	
	
		[Description("Predefined occupant types from which that required may be set.\r\n\r\n<blockquote cla" +
	    "ss=\"change-ifc2x4\">IFC4 CHANGE Attribute made optional.</blockquote> ")]
		public IfcOccupantTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
	
	}
	
}
