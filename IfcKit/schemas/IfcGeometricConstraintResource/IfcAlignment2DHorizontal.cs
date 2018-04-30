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
	public partial class IfcAlignment2DHorizontal : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The value of the distance along at the start of the horizontal alignment. If omited (standard) it is set to zero.")]
		public IfcLengthMeasure? StartDistAlong { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("An ordered list of unique horizontal alignment segments, each (but the last) are joint end to start")]
		[Required()]
		[MinLength(1)]
		public IList<IfcAlignment2DHorizontalSegment> Segments { get; protected set; }
	
		[InverseProperty("Horizontal")] 
		[MinLength(1)]
		public ISet<IfcAlignmentCurve> ToAlignmentCurve { get; protected set; }
	
	
		public IfcAlignment2DHorizontal(IfcLengthMeasure? __StartDistAlong, IfcAlignment2DHorizontalSegment[] __Segments)
		{
			this.StartDistAlong = __StartDistAlong;
			this.Segments = new List<IfcAlignment2DHorizontalSegment>(__Segments);
			this.ToAlignmentCurve = new HashSet<IfcAlignmentCurve>();
		}
	
	
	}
	
}
