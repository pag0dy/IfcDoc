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
	[Guid("385df7bd-5ead-42f9-a622-2a0516779bef")]
	public partial class IfcLine : IfcCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCartesianPoint _Pnt;
	
		[DataMember(Order=1)] 
		[Required()]
		IfcVector _Dir;
	
	
		[Description("The location of the line.")]
		public IfcCartesianPoint Pnt { get { return this._Pnt; } set { this._Pnt = value;} }
	
		[Description("The direction of the line, the magnitude and units of Dir affect the parameteriza" +
	    "tion of the line.")]
		public IfcVector Dir { get { return this._Dir; } set { this._Dir = value;} }
	
	
	}
	
}
