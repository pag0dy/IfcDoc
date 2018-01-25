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
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfilePropertyResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcSharedBldgElements;
using BuildingSmart.IFC.IfcSharedBldgServiceElements;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;
using BuildingSmart.IFC.IfcStructuralElementsDomain;

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
		ISet<IfcSpatialStructureElement> _RelatedBuildings = new HashSet<IfcSpatialStructureElement>();
	
	
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
