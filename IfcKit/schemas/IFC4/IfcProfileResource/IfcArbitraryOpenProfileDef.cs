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
using BuildingSmart.IFC.IfcPropertyResource;

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("65ea2e1f-aa07-4338-9f78-43c237e707f8")]
	public partial class IfcArbitraryOpenProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcBoundedCurve")]
		[Required()]
		IfcBoundedCurve _Curve;
	
	
		[Description("Open bounded curve defining the profile.")]
		public IfcBoundedCurve Curve { get { return this._Curve; } set { this._Curve = value;} }
	
	
	}
	
}
