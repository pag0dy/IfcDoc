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
	[Guid("98253b09-c304-4f3b-993b-a1940bd58e52")]
	public abstract partial class IfcConic : IfcCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAxis2Placement _Position;
	
	
		[Description("The location and orientation of the conic. Further details of the interpretation " +
	    "of this attribute are given for the individual subtypes.\" \r\n")]
		public IfcAxis2Placement Position { get { return this._Position; } set { this._Position = value;} }
	
	
	}
	
}
