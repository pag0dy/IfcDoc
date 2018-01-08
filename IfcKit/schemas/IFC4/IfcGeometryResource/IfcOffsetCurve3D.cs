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
	[Guid("993ba75f-6b94-4c8c-b4c4-ba41608e3dc4")]
	public partial class IfcOffsetCurve3D : IfcCurve
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcCurve")]
		[Required()]
		IfcCurve _BasisCurve;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IfcLengthMeasure _Distance;
	
		[DataMember(Order=2)] 
		[Required()]
		Boolean? _SelfIntersect;
	
		[DataMember(Order=3)] 
		[XmlElement("IfcDirection")]
		[Required()]
		IfcDirection _RefDirection;
	
	
		[Description("The curve that is being offset.")]
		public IfcCurve BasisCurve { get { return this._BasisCurve; } set { this._BasisCurve = value;} }
	
		[Description("The distance of the offset curve from the basis curve. The distance may be positi" +
	    "ve, negative or zero.")]
		public IfcLengthMeasure Distance { get { return this._Distance; } set { this._Distance = value;} }
	
		[Description("An indication of whether the offset curve self-intersects, this is for informatio" +
	    "n only.")]
		public Boolean? SelfIntersect { get { return this._SelfIntersect; } set { this._SelfIntersect = value;} }
	
		[Description("The direction used to define the direction of the offset curve 3d from the basis " +
	    "curve.")]
		public IfcDirection RefDirection { get { return this._RefDirection; } set { this._RefDirection = value;} }
	
	
	}
	
}
