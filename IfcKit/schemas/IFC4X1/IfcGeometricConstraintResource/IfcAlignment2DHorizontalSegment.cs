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

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("d2950a95-9126-46e8-8c7b-58904077ae5c")]
	public partial class IfcAlignment2DHorizontalSegment : IfcAlignment2DSegment
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurveSegment2D _CurveGeometry;
	
		[InverseProperty("Segments")] 
		[MinLength(1)]
		[MaxLength(1)]
		ISet<IfcAlignment2DHorizontal> _ToHorizontal = new HashSet<IfcAlignment2DHorizontal>();
	
	
		public IfcAlignment2DHorizontalSegment()
		{
		}
	
		public IfcAlignment2DHorizontalSegment(IfcBoolean? __TangentialContinuity, IfcLabel? __StartTag, IfcLabel? __EndTag, IfcCurveSegment2D __CurveGeometry)
			: base(__TangentialContinuity, __StartTag, __EndTag)
		{
			this._CurveGeometry = __CurveGeometry;
		}
	
		[Description("Geometric representation of the horizontal alignment within the 2D X/Y coordinate" +
	    " space.")]
		public IfcCurveSegment2D CurveGeometry { get { return this._CurveGeometry; } set { this._CurveGeometry = value;} }
	
		public ISet<IfcAlignment2DHorizontal> ToHorizontal { get { return this._ToHorizontal; } }
	
	
	}
	
}
