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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("02deb347-62f1-4f86-9a06-f61a278b9f47")]
	public abstract partial class IfcObjectPlacement
	{
		[InverseProperty("ObjectPlacement")] 
		ISet<IfcProduct> _PlacesObject = new HashSet<IfcProduct>();
	
		[InverseProperty("PlacementRelTo")] 
		ISet<IfcLocalPlacement> _ReferencedByPlacements = new HashSet<IfcLocalPlacement>();
	
	
		[Description(@"<EPM-HTML>
	The <i>IfcObjectPlacement</i> shall be used to provide a placement and an object coordinate system for a single instance of <i>IfcProduct</i>.
	<blockquote><small>
	  <font color=""#FF0000"">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>
	</small></blockquote>
	</EPM-HTML>")]
		public ISet<IfcProduct> PlacesObject { get { return this._PlacesObject; } }
	
		[Description("Placements that are given relative to this placement of an object.")]
		public ISet<IfcLocalPlacement> ReferencedByPlacements { get { return this._ReferencedByPlacements; } }
	
	
	}
	
}
