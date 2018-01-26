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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("211a7b82-6217-476c-8ecd-feaed2e8b2b9")]
	public partial class IfcRightCircularCone : IfcCsgPrimitive3D
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _Height;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcPositiveLengthMeasure _BottomRadius;
	
	
		public IfcRightCircularCone()
		{
		}
	
		public IfcRightCircularCone(IfcAxis2Placement3D __Position, IfcPositiveLengthMeasure __Height, IfcPositiveLengthMeasure __BottomRadius)
			: base(__Position)
		{
			this._Height = __Height;
			this._BottomRadius = __BottomRadius;
		}
	
		[Description("The distance between the base of the cone and the apex.")]
		public IfcPositiveLengthMeasure Height { get { return this._Height; } set { this._Height = value;} }
	
		[Description("The radius of the cone at the base.")]
		public IfcPositiveLengthMeasure BottomRadius { get { return this._BottomRadius; } set { this._BottomRadius = value;} }
	
	
	}
	
}
