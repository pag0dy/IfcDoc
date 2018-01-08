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
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcSharedComponentElements;
using BuildingSmart.IFC.IfcSharedFacilitiesElements;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("dffb2f7f-2ba0-4b5f-88e4-bde0fa72fa1d")]
	public partial class IfcSystem : IfcGroup
	{
		[InverseProperty("RelatingSystem")] 
		ISet<IfcRelServicesBuildings> _ServicesBuildings = new HashSet<IfcRelServicesBuildings>();
	
	
		[Description("<EPM-HTML>Reference to the <strike>building</strike> spatial structure via the ob" +
	    "jectified relationship <em>IfcRelServicesBuildings</em>, which is serviced by th" +
	    "e system.\r\n</EPM-HTML>\r\n")]
		public ISet<IfcRelServicesBuildings> ServicesBuildings { get { return this._ServicesBuildings; } }
	
	
	}
	
}
