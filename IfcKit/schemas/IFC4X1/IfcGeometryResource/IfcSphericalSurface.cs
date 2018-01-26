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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("670a9c08-2e52-4be6-b130-434587b3a111")]
	public partial class IfcSphericalSurface : IfcElementarySurface
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Radius;
	
	
		public IfcSphericalSurface()
		{
		}
	
		public IfcSphericalSurface(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __Radius)
			: base(__Position)
		{
			this._Radius = __Radius;
		}
	
		[Description("The radius of the sphere.")]
		public IfcPositiveLengthMeasure Radius { get { return this._Radius; } set { this._Radius = value;} }
	
	
	}
	
}
