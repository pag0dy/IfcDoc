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
	public partial class IfcLine : IfcCurve
	{
		[DataMember(Order = 0)] 
		[Description("The location of the line.")]
		[Required()]
		public IfcCartesianPoint Pnt { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The direction of the line, the magnitude and units of Dir affect the parameterization of the line.")]
		[Required()]
		public IfcVector Dir { get; set; }
	
	
		public IfcLine(IfcCartesianPoint __Pnt, IfcVector __Dir)
		{
			this.Pnt = __Pnt;
			this.Dir = __Dir;
		}
	
	
	}
	
}
