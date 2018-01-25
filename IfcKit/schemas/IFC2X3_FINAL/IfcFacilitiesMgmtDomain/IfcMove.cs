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
using BuildingSmart.IFC.IfcArchitectureDomain;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcSharedMgmtElements;

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	[Guid("fc8522b4-c759-407e-a896-1ae680a0dd83")]
	public partial class IfcMove : IfcTask
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSpatialStructureElement _MoveFrom;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcSpatialStructureElement _MoveTo;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IList<IfcText> _PunchList = new List<IfcText>();
	
	
		[Description("The place from which actors and their associated equipment are moving.")]
		public IfcSpatialStructureElement MoveFrom { get { return this._MoveFrom; } set { this._MoveFrom = value;} }
	
		[Description("The place to which actors and their associated equipment are moving.")]
		public IfcSpatialStructureElement MoveTo { get { return this._MoveTo; } set { this._MoveTo = value;} }
	
		[Description("A list of points concerning a move that require attention.")]
		public IList<IfcText> PunchList { get { return this._PunchList; } }
	
	
	}
	
}
