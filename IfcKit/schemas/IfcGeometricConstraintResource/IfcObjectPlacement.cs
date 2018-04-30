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

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public abstract partial class IfcObjectPlacement
	{
		[InverseProperty("ObjectPlacement")] 
		[Description("<EPM-HTML>  The <i>IfcObjectPlacement</i> shall be used to provide a placement and an object coordinate system for a single instance of <i>IfcProduct</i>.  <blockquote><small>    <font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>  </small></blockquote>  </EPM-HTML>")]
		[MinLength(1)]
		[MaxLength(1)]
		public ISet<IfcProduct> PlacesObject { get; protected set; }
	
		[InverseProperty("PlacementRelTo")] 
		[Description("Placements that are given relative to this placement of an object.")]
		public ISet<IfcLocalPlacement> ReferencedByPlacements { get; protected set; }
	
	
		protected IfcObjectPlacement()
		{
			this.PlacesObject = new HashSet<IfcProduct>();
			this.ReferencedByPlacements = new HashSet<IfcLocalPlacement>();
		}
	
	
	}
	
}
