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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("dd30ecc9-e76f-48d9-b2d9-5340b2f0c0b8")]
	public partial class IfcPcurve : IfcCurve,
		BuildingSmart.IFC.IfcGeometryResource.IfcCurveOnSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcSurface _BasisSurface;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcCurve _ReferenceCurve;
	
	
		public IfcSurface BasisSurface { get { return this._BasisSurface; } set { this._BasisSurface = value;} }
	
		public IfcCurve ReferenceCurve { get { return this._ReferenceCurve; } set { this._ReferenceCurve = value;} }
	
	
	}
	
}
