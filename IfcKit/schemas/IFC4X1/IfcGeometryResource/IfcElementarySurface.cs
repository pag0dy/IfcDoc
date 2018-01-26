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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("dab568ba-aad6-4d74-963d-d3f397cfcea1")]
	public abstract partial class IfcElementarySurface : IfcSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcAxis2Placement3D _Position;
	
	
		public IfcElementarySurface()
		{
		}
	
		public IfcElementarySurface(IfcAxis2Placement3D __Position)
		{
			this._Position = __Position;
		}
	
		[Description("The position and orientation of the surface. This attribute is used in the defini" +
	    "tion of the parameterization of the surface.\r\n")]
		public IfcAxis2Placement3D Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
