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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("0262a777-3276-41d2-b84c-be6de10e1811")]
	public partial class IfcArbitraryOpenProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcBoundedCurve _Curve;
	
	
		[Description("Open bounded curve defining the profile.")]
		public IfcBoundedCurve Curve { get { return this._Curve; } set { this._Curve = value;} }
	
	
	}
	
}
