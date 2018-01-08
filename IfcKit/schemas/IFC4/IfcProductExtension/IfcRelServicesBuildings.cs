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
	[Guid("db89d737-4bde-4aef-bb04-156d8b2c8097")]
	public partial class IfcRelServicesBuildings : IfcRelConnects
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcSystem")]
		[Required()]
		IfcSystem _RelatingSystem;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcSpatialElement> _RelatedBuildings = new HashSet<IfcSpatialElement>();
	
	
		[Description("System that services the Buildings. \r\n")]
		public IfcSystem RelatingSystem { get { return this._RelatingSystem; } set { this._RelatingSystem = value;} }
	
		[Description(@"<EPM-HTML>
	Spatial structure elements (including site, building, storeys) that are serviced by the system.
	<blockquote class=""change-ifc2x"">
	  IFC2x CHANGE&nbsp; The data type has been changed from <em>IfcBuilding</em> to <em>IfcSpatialStructureElement</em> with upward compatibility for file based exchange.
	</blockquote>
	<blockquote class=""change-ifc2x4"">
	  IFC4 CHANGE&nbsp; The data type has been changed from <em>IfcSpatialStructureElement</em> to <em>IfcSpatialElement</em> with upward compatibility for file based exchange.
	</blockquote>
	</EPM-HTML>")]
		public ISet<IfcSpatialElement> RelatedBuildings { get { return this._RelatedBuildings; } }
	
	
	}
	
}
