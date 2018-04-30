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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProcessExtension;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcFacilitiesMgmtDomain
{
	public partial class IfcMove : IfcTask
	{
		[DataMember(Order = 0)] 
		[Description("The place from which actors and their associated equipment are moving.")]
		[Required()]
		public IfcSpatialStructureElement MoveFrom { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The place to which actors and their associated equipment are moving.")]
		[Required()]
		public IfcSpatialStructureElement MoveTo { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("A list of points concerning a move that require attention.")]
		[MinLength(1)]
		public IList<IfcText> PunchList { get; protected set; }
	
	
		public IfcMove(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType, IfcIdentifier __TaskId, IfcLabel? __Status, IfcLabel? __WorkMethod, Boolean __IsMilestone, Int64? __Priority, IfcSpatialStructureElement __MoveFrom, IfcSpatialStructureElement __MoveTo, IfcText[] __PunchList)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType, __TaskId, __Status, __WorkMethod, __IsMilestone, __Priority)
		{
			this.MoveFrom = __MoveFrom;
			this.MoveTo = __MoveTo;
			this.PunchList = new List<IfcText>(__PunchList);
		}
	
	
	}
	
}
