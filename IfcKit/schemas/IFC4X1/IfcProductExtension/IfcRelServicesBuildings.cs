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

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("db89d737-4bde-4aef-bb04-156d8b2c8097")]
	public partial class IfcRelServicesBuildings : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcSystem _RelatingSystem;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcSpatialElement> _RelatedBuildings = new HashSet<IfcSpatialElement>();
	
	
		public IfcRelServicesBuildings()
		{
		}
	
		public IfcRelServicesBuildings(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSystem __RelatingSystem, IfcSpatialElement[] __RelatedBuildings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingSystem = __RelatingSystem;
			this._RelatedBuildings = new HashSet<IfcSpatialElement>(__RelatedBuildings);
		}
	
		[Description("System that services the Buildings. \r\n")]
		public IfcSystem RelatingSystem { get { return this._RelatingSystem; } set { this._RelatingSystem = value;} }
	
		[Description(@"Spatial structure elements (including site, building, storeys) that are serviced by the system.
	<blockquote class=""change-ifc2x"">
	  IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuilding</em> to <em>IfcSpatialStructureElement</em> with upward compatibility for file based exchange.
	</blockquote>
	<blockquote class=""change-ifc2x4"">
	  IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcSpatialStructureElement</em> to <em>IfcSpatialElement</em> with upward compatibility for file based exchange.
	</blockquote>")]
		public ISet<IfcSpatialElement> RelatedBuildings { get { return this._RelatedBuildings; } }
	
	
	}
	
}
