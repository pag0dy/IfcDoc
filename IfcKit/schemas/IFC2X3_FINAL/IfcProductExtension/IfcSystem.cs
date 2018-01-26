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
	[Guid("cc7be996-d1ea-43ef-8969-e97b06238a34")]
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
	
		[Description("<EPM-HTML>Reference to the <strike>building</strike> spatial structure via the ob" +
	    "jectified relationship <i>IfcRelServicesBuildings</i>, which is serviced by the " +
	    "system.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcRelServicesBuildings> ServicesBuildings { get { return this._ServicesBuildings; } }
	
	
	}
	
}
