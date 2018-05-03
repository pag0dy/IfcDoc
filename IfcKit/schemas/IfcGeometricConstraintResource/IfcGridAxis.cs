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
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	public partial class IfcGridAxis
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The tag or name for this grid axis.")]
		public IfcLabel? AxisTag { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("Underlying curve which provides the geometry for this grid axis.")]
		[Required()]
		public IfcCurve AxisCurve { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Defines whether the original sense of curve is used or whether it is reversed in the context of the grid axis.")]
		[Required()]
		public IfcBoolean SameSense { get; set; }
	
		[InverseProperty("WAxes")] 
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>WAxes</em> of <em>IfcGrid</em>.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfW { get; protected set; }
	
		[InverseProperty("VAxes")] 
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>VAxes</em> of <em>IfcGrid</em>.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfV { get; protected set; }
	
		[InverseProperty("UAxes")] 
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>UAxes</em> of <em>IfcGrid</em>.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfU { get; protected set; }
	
		[InverseProperty("IntersectingAxes")] 
		[Description("The reference to a set of <IfcVirtualGridIntersection</em>'s, that connect other grid axes to this grid axis.  <blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attribute.</blockquote>")]
		public ISet<IfcVirtualGridIntersection> HasIntersections { get; protected set; }
	
	
		public IfcGridAxis(IfcLabel? __AxisTag, IfcCurve __AxisCurve, IfcBoolean __SameSense)
		{
			this.AxisTag = __AxisTag;
			this.AxisCurve = __AxisCurve;
			this.SameSense = __SameSense;
			this.PartOfW = new HashSet<IfcGrid>();
			this.PartOfV = new HashSet<IfcGrid>();
			this.PartOfU = new HashSet<IfcGrid>();
			this.HasIntersections = new HashSet<IfcVirtualGridIntersection>();
		}
	
	
	}
	
}
