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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcLocalPlacement : IfcObjectPlacement
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Reference to Object that provides the relative placement by its local coordinate system. If it is omitted, then the local placement is given to the WCS, established by the geometric representation context.  ")]
		public IfcObjectPlacement PlacementRelTo { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Geometric placement that defines the transformation from the related coordinate system into the relating. The placement can be either 2D or 3D, depending on the dimension count of the coordinate system.")]
		[Required()]
		public IfcAxis2Placement RelativePlacement { get; set; }
	
	
		public IfcLocalPlacement(IfcObjectPlacement __PlacementRelTo, IfcAxis2Placement __RelativePlacement)
		{
			this.PlacementRelTo = __PlacementRelTo;
			this.RelativePlacement = __RelativePlacement;
		}
	
	
	}
	
}
