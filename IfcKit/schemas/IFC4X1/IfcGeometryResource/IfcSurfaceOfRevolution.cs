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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("89fd5813-f37e-4602-a4ad-8cdb9bf8869c")]
	public partial class IfcSurfaceOfRevolution : IfcSweptSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcAxis1Placement _AxisPosition;
	
	
		public IfcSurfaceOfRevolution()
		{
		}
	
		public IfcSurfaceOfRevolution(IfcProfileDef __SweptCurve, IfcAxis2Placement3D __Position, IfcAxis1Placement __AxisPosition)
			: base(__SweptCurve, __Position)
		{
			this._AxisPosition = __AxisPosition;
		}
	
		[Description("A point on the axis of revolution and the direction of the axis of revolution.")]
		public IfcAxis1Placement AxisPosition { get { return this._AxisPosition; } set { this._AxisPosition = value;} }
	
		public new IfcLine AxisLine { get { return null; } }
	
	
	}
	
}
