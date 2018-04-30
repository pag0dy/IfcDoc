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
	public partial class IfcPolyline : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[Description("The points defining the polyline.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcCartesianPoint> Points { get; protected set; }
	
	
		public IfcPolyline(IfcCartesianPoint[] __Points)
		{
			this.Points = new List<IfcCartesianPoint>(__Points);
		}
	
	
	}
	
}
