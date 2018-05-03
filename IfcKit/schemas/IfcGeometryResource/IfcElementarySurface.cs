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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public abstract partial class IfcElementarySurface : IfcSurface
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The position and orientation of the surface. This attribute is used in the definition of the parameterization of the surface.  ")]
		[Required()]
		public IfcAxis2Placement3D Position { get; set; }
	
	
		protected IfcElementarySurface(IfcAxis2Placement3D __Position)
		{
			this.Position = __Position;
		}
	
	
	}
	
}
