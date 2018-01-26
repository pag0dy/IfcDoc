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

namespace BuildingSmart.IFC.IfcProfileResource
{
	[Guid("b6ccca8d-998a-47ed-beac-ef1b44ee5681")]
	public partial class IfcArbitraryClosedProfileDef : IfcProfileDef
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCurve _OuterCurve;
	
	
		public IfcArbitraryClosedProfileDef()
		{
		}
	
		public IfcArbitraryClosedProfileDef(IfcProfileTypeEnum __ProfileType, IfcLabel? __ProfileName, IfcCurve __OuterCurve)
			: base(__ProfileType, __ProfileName)
		{
			this._OuterCurve = __OuterCurve;
		}
	
		[Description("Bounded curve, defining the outer boundaries of the arbitrary profile.")]
		public IfcCurve OuterCurve { get { return this._OuterCurve; } set { this._OuterCurve = value;} }
	
	
	}
	
}
