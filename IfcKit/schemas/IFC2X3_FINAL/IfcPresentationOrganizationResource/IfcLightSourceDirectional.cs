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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;

namespace BuildingSmart.IFC.IfcPresentationOrganizationResource
{
	[Guid("9b92d734-c9c0-4a8f-85c1-aaff4b5dacbd")]
	public partial class IfcLightSourceDirectional : IfcLightSource
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcDirection _Orientation;
	
	
		[Description(@"Definition from ISO/CD 10303-46:1992: This direction is the direction of the light source.
	Definition from VRML97 - ISO/IEC 14772-1:1997: The direction field specifies the direction vector of the illumination emanating from the light source in the local coordinate system. Light is emitted along parallel rays from an infinite distance away. 
	")]
		public IfcDirection Orientation { get { return this._Orientation; } set { this._Orientation = value;} }
	
	
	}
	
}
