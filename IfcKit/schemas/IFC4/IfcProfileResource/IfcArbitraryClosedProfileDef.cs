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
	[Guid("7bd49124-3b02-4378-9c53-cfe91d261947")]
	public partial class IfcArbitraryClosedProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _OuterCurve;
	
	
		[Description("Bounded curve, defining the outer boundaries of the arbitrary profile.")]
		public IfcCurve OuterCurve { get { return this._OuterCurve; } set { this._OuterCurve = value;} }
	
	
	}
	
}
