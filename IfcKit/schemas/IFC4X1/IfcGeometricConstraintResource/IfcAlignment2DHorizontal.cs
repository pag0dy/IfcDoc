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
	[Guid("e57f51f6-a65e-414c-b15d-0bb4b722efd9")]
	public partial class IfcAlignment2DHorizontal : IfcGeometricRepresentationItem
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLengthMeasure? _StartDistAlong;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcAlignment2DHorizontalSegment> _Segments = new List<IfcAlignment2DHorizontalSegment>();
	
		[InverseProperty("Horizontal")] 
		[MinLength(1)]
		ISet<IfcAlignmentCurve> _ToAlignmentCurve = new HashSet<IfcAlignmentCurve>();
	
	
		public IfcAlignment2DHorizontal()
		{
		}
	
		public IfcAlignment2DHorizontal(IfcLengthMeasure? __StartDistAlong, IfcAlignment2DHorizontalSegment[] __Segments)
		{
			this._StartDistAlong = __StartDistAlong;
			this._Segments = new List<IfcAlignment2DHorizontalSegment>(__Segments);
		}
	
		[Description("The value of the distance along at the start of the horizontal alignment. If omit" +
	    "ed (standard) it is set to zero.")]
		public IfcLengthMeasure? StartDistAlong { get { return this._StartDistAlong; } set { this._StartDistAlong = value;} }
	
		[Description("An ordered list of unique horizontal alignment segments, each (but the last) are " +
	    "joint end to start")]
		public IList<IfcAlignment2DHorizontalSegment> Segments { get { return this._Segments; } }
	
		public ISet<IfcAlignmentCurve> ToAlignmentCurve { get { return this._ToAlignmentCurve; } }
	
	
	}
	
}
