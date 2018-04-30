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
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcAlignment2DVertical : IfcGeometricRepresentationItem
	{
		[DataMember(Order = 0)] 
		[Description("An ordered list of unique vertical alignment segments, each (but the last) are joint end to start")]
		[Required()]
		[MinLength(1)]
		public IList<IfcAlignment2DVerticalSegment> Segments { get; protected set; }
	
		[InverseProperty("Vertical")] 
		[MinLength(1)]
		[MaxLength(1)]
		public ISet<IfcAlignmentCurve> ToAlignmentCurve { get; protected set; }
	
	
		public IfcAlignment2DVertical(IfcAlignment2DVerticalSegment[] __Segments)
		{
			this.Segments = new List<IfcAlignment2DVerticalSegment>(__Segments);
			this.ToAlignmentCurve = new HashSet<IfcAlignmentCurve>();
		}
	
	
	}
	
}
