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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcPcurve : IfcCurve,
		BuildingSmart.IFC.IfcGeometryResource.IfcCurveOnSurface
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Required()]
		public IfcSurface BasisSurface { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Required()]
		public IfcCurve ReferenceCurve { get; set; }
	
	
		public IfcPcurve(IfcSurface __BasisSurface, IfcCurve __ReferenceCurve)
		{
			this.BasisSurface = __BasisSurface;
			this.ReferenceCurve = __ReferenceCurve;
		}
	
	
	}
	
}
