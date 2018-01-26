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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("28220f1d-2ef9-48f4-9aa6-198f7af996d8")]
	public partial class IfcLine : IfcCurve
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCartesianPoint _Pnt;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcVector _Dir;
	
	
		public IfcLine()
		{
		}
	
		public IfcLine(IfcCartesianPoint __Pnt, IfcVector __Dir)
		{
			this._Pnt = __Pnt;
			this._Dir = __Dir;
		}
	
		[Description("The location of the <em>IfcLine</em>.")]
		public IfcCartesianPoint Pnt { get { return this._Pnt; } set { this._Pnt = value;} }
	
		[Description("The direction of the <em>IfcLine</em>, the magnitude and units of <em>Dir</em> af" +
	    "fect the parameterization of the line.")]
		public IfcVector Dir { get { return this._Dir; } set { this._Dir = value;} }
	
	
	}
	
}
