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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("2b778252-2505-4592-bf1a-8d3e44492157")]
	public partial class IfcAlignmentCurve : IfcBoundedCurve
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcAlignment2DHorizontal _Horizontal;
	
		[DataMember(Order=1)] 
		IfcAlignment2DVertical _Vertical;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		IfcLabel? _Tag;
	
	
		public IfcAlignmentCurve()
		{
		}
	
		public IfcAlignmentCurve(IfcAlignment2DHorizontal __Horizontal, IfcAlignment2DVertical __Vertical, IfcLabel? __Tag)
		{
			this._Horizontal = __Horizontal;
			this._Vertical = __Vertical;
			this._Tag = __Tag;
		}
	
		[Description("The horizontal component of the curve.")]
		public IfcAlignment2DHorizontal Horizontal { get { return this._Horizontal; } set { this._Horizontal = value;} }
	
		[Description("The vertical component of the curve, which is defined relative to the horizontal " +
	    "curve.")]
		public IfcAlignment2DVertical Vertical { get { return this._Vertical; } set { this._Vertical = value;} }
	
		[Description("Optional identifier of the curve, which may be used to correlate points from a va" +
	    "riable cross-section.")]
		public IfcLabel? Tag { get { return this._Tag; } set { this._Tag = value;} }
	
	
	}
	
}
