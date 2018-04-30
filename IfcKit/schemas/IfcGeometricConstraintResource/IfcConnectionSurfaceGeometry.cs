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


namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcConnectionSurfaceGeometry : IfcConnectionGeometry
	{
		[DataMember(Order = 0)] 
		[Description("Surface at which related object is aligned at the relating element, given in the LCS of the relating element.")]
		[Required()]
		public IfcSurfaceOrFaceSurface SurfaceOnRelatingElement { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("Surface at which the relating element is aligned at the related element, given in the LCS of the related element. If the information is omitted, then the origin of the related element is used.  ")]
		public IfcSurfaceOrFaceSurface SurfaceOnRelatedElement { get; set; }
	
	
		public IfcConnectionSurfaceGeometry(IfcSurfaceOrFaceSurface __SurfaceOnRelatingElement, IfcSurfaceOrFaceSurface __SurfaceOnRelatedElement)
		{
			this.SurfaceOnRelatingElement = __SurfaceOnRelatingElement;
			this.SurfaceOnRelatedElement = __SurfaceOnRelatedElement;
		}
	
	
	}
	
}
