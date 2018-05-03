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
		[Description("The <em>IfcObjectPlacement</em> shall be used to provide a placement and   an object coordinate system for instances of <em>IfcProduct</em>.   <blockquote class=\"note\">     If an <em>IfcObjectPlacement</em> is shared by many instances of <em>IfcProduct</em>      it does not apply a semantic meaning of being a shared placement that needs to be      maintained. The same instance of <em>IfcObjectPlacement</em> could simply be used to     reduce exchange file size.  </blockquote>  <blockquote class=\"change-ifc2x3\">     IFC2x3 CHANGE&nbsp; New inverse attribute.  </blockquote>  <blockquote class=\"change-ifc2x4\">     IFC4 CHANGE&nbsp; The cardinality has changed to 0..n to allow reuse of instances of      <em>IfcObjectPlacement</em> as placement object in one to many products. It takes also     into account that it can act as a placement for <em>IfcStructuralAnalysisModel</em>.  </blockquote>")]
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
