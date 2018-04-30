// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
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

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcOffsetCurve3D : IfcOffsetCurve
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The distance of the offset curve from the basis curve. The distance may be positive, negative or zero.")]
		[Required()]
		public IfcLengthMeasure Distance { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("An indication of whether the offset curve self-intersects, this is for information only.")]
		[Required()]
		public IfcLogical SelfIntersect { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlElement]
		[Description("The direction used to define the direction of the offset curve 3d from the basis curve.")]
		[Required()]
		public IfcDirection RefDirection { get; set; }
	
	
		public IfcOffsetCurve3D(IfcCurve __BasisCurve, IfcLengthMeasure __Distance, IfcLogical __SelfIntersect, IfcDirection __RefDirection)
			: base(__BasisCurve)
		{
			this.Distance = __Distance;
			this.SelfIntersect = __SelfIntersect;
			this.RefDirection = __RefDirection;
		}
	
	
	}
	
}
