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
	[Guid("dffb2f7f-2ba0-4b5f-88e4-bde0fa72fa1d")]
	public partial class IfcSystem : IfcGroup
	{
		[InverseProperty("RelatingSystem")] 
		[MaxLength(1)]
		ISet<IfcRelServicesBuildings> _ServicesBuildings = new HashSet<IfcRelServicesBuildings>();
	
	
		public IfcSystem()
		{
		}
	
		public IfcSystem(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __ObjectType)
			: base(__GlobalId, __OwnerHistory, __Name, __Description, __ObjectType)
		{
		}
	
		[Description("Reference to the <strike>building</strike> spatial structure via the objectified " +
	    "relationship <em>IfcRelServicesBuildings</em>, which is serviced by the system.\r" +
	    "\n")]
		public ISet<IfcRelServicesBuildings> ServicesBuildings { get { return this._ServicesBuildings; } }
	
	
	}
	
}
