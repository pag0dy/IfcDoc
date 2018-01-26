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
	[Guid("4d72148d-01ae-4e34-a77d-a0ad700a2675")]
	public abstract partial class IfcOffsetCurve : IfcCurve
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcCurve _BasisCurve;
	
	
		public IfcOffsetCurve()
		{
		}
	
		public IfcOffsetCurve(IfcCurve __BasisCurve)
		{
			this._BasisCurve = __BasisCurve;
		}
	
		[Description("The curve that is being offset.")]
		public IfcCurve BasisCurve { get { return this._BasisCurve; } set { this._BasisCurve = value;} }
	
	
	}
	
}
