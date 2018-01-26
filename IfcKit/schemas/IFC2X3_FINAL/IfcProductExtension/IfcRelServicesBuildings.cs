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
	[Guid("10f0323d-4a18-4ef3-a7ed-de9488cd0b5c")]
	public partial class IfcRelServicesBuildings : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSystem _RelatingSystem;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcSpatialStructureElement> _RelatedBuildings = new HashSet<IfcSpatialStructureElement>();
	
	
		public IfcRelServicesBuildings()
		{
		}
	
		public IfcRelServicesBuildings(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcSystem __RelatingSystem, IfcSpatialStructureElement[] __RelatedBuildings)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._RelatingSystem = __RelatingSystem;
			this._RelatedBuildings = new HashSet<IfcSpatialStructureElement>(__RelatedBuildings);
		}
	
		[Description("System that services the Buildings. \r\n")]
		public IfcSystem RelatingSystem { get { return this._RelatingSystem; } set { this._RelatingSystem = value;} }
	
		[Description(@"<EPM-HTML>
	Spatial structure elements (including site, building, storeys) that are serviced by the system.
	<blockquote><small><font color=""#FF0000"">
	IFC2x PLATFORM CHANGE&nbsp; The data type has been changed from <i>IfcBuilding</i> to <i>IfcSpatialStructureElement</i> with upward compatibility for file based exchange.
	</font></small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcSpatialStructureElement> RelatedBuildings { get { return this._RelatedBuildings; } }
	
	
	}
	
}
