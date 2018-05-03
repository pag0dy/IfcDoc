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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcAlignment2DHorizontalSegment : IfcAlignment2DSegment
	{
		[DataMember(Order = 0)] 
		[Description("Geometric representation of the horizontal alignment within the 2D X/Y coordinate space.")]
		[Required()]
		public IfcCurveSegment2D CurveGeometry { get; set; }
	
		[InverseProperty("Segments")] 
		[MinLength(1)]
		[MaxLength(1)]
		public ISet<IfcAlignment2DHorizontal> ToHorizontal { get; protected set; }
	
	
		public IfcAlignment2DHorizontalSegment(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcCurveSegment2D __CurveGeometry)
			: base(__TangentialContinuity, __StartTag, __EndTag)
		{
			this.CurveGeometry = __CurveGeometry;
			this.ToHorizontal = new HashSet<IfcAlignment2DHorizontal>();
		}
	
	
	}
	
}
