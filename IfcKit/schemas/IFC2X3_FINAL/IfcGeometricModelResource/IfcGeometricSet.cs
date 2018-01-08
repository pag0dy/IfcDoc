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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("9522d96d-936b-4320-84eb-f580b83766d8")]
	public partial class IfcGeometricSet : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcGeometricSetSelect> _Elements = new HashSet<IfcGeometricSetSelect>();
	
	
		[Description("The geometric elements which make up the geometric set, these may be points, curv" +
	    "es or surfaces; but are required to be of the same coordinate space dimensionali" +
	    "ty.")]
		public ISet<IfcGeometricSetSelect> Elements { get { return this._Elements; } }
	
	
	}
	
}
