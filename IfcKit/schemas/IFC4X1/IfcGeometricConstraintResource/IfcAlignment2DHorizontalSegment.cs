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
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("d2950a95-9126-46e8-8c7b-58904077ae5c")]
	public partial class IfcAlignment2DHorizontalSegment : IfcAlignment2DSegment
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurveSegment2D _CurveGeometry;
	
		[InverseProperty("Segments")] 
		ISet<IfcAlignment2DHorizontal> _ToHorizontal = new HashSet<IfcAlignment2DHorizontal>();
	
	
		[Description("Geometric representation of the horizontal alignment within the 2D X/Y coordinate" +
	    " space.")]
		public IfcCurveSegment2D CurveGeometry { get { return this._CurveGeometry; } set { this._CurveGeometry = value;} }
	
		public ISet<IfcAlignment2DHorizontal> ToHorizontal { get { return this._ToHorizontal; } }
	
	
	}
	
}
