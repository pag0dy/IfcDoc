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
		[Description("Underlying curve which provides the geometry for this grid axis.")]
		[Required()]
		public IfcCurve AxisCurve { get; set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("Defines whether the original sense of curve is used or whether it is reversed in the context of the grid axis.")]
		[Required()]
		public IfcBoolean SameSense { get; set; }
	
		[InverseProperty("WAxes")] 
		[Description("<EPM-HTML>  If provided, the <i>IfcGridAxis</i> is part of the <i>WAxes</i> of <i>IfcGrid</i>.  <blockquote><small>    <font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>  </small></blockquote>  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfW { get; protected set; }
	
		[InverseProperty("VAxes")] 
		[Description("<EPM-HTML>  If provided, the <i>IfcGridAxis</i> is part of the <i>VAxes</i> of <i>IfcGrid</i>.  <blockquote><small>    <font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>  </small></blockquote>  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfV { get; protected set; }
	
		[InverseProperty("UAxes")] 
		[Description("<EPM-HTML>  If provided, the <i>IfcGridAxis</i> is part of the <i>UAxes</i> of <i>IfcGrid</i>.  <blockquote><small>    <font color=\"#FF0000\">IFC2x Edition 3 CHANGE&nbsp; New inverse attribute.</font>  </small></blockquote>  </EPM-HTML>")]
		[MaxLength(1)]
		public ISet<IfcGrid> PartOfU { get; protected set; }
	
		[InverseProperty("IntersectingAxes")] 
		[Description("<EPM-HTML>  The reference to a set of <IfcVirtualGridIntersection</i>'s, that connect other grid axes to this grid axis.  <blockquote><small>    <font color=\"#FF0000\">IFC2x3 CHANGE&nbsp; New inverse attribute.</font>  </small></blockquote>  </EPM-HTML>")]
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
