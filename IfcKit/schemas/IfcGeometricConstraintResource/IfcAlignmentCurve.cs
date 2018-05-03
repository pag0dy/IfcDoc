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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcAlignmentCurve : IfcBoundedCurve
	{
		[DataMember(Order = 0)] 
		[Description("The horizontal component of the curve.")]
		[Required()]
		public IfcAlignment2DHorizontal Horizontal { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("The vertical component of the curve, which is defined relative to the horizontal curve.")]
		public IfcAlignment2DVertical Vertical { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Optional identifier of the curve, which may be used to correlate points from a variable cross-section.")]
		public IfcLabel? Tag { get; set; }
	
	
		public IfcAlignmentCurve(IfcAlignment2DHorizontal __Horizontal, IfcAlignment2DVertical __Vertical, IfcLabel? __Tag)
		{
			this.Horizontal = __Horizontal;
			this.Vertical = __Vertical;
			this.Tag = __Tag;
		}
	
	
	}
	
}
