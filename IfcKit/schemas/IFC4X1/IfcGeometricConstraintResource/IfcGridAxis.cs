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
	[Guid("c88238d9-0400-4b8f-846c-03fd460a7fa9")]
	public partial class IfcGridAxis
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _AxisTag;
	
		[DataMember(Order=1)] 
		[XmlElement]
		[Required()]
		IfcCurve _AxisCurve;
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _SameSense;
	
		[InverseProperty("WAxes")] 
		ISet<IfcGrid> _PartOfW = new HashSet<IfcGrid>();
	
		[InverseProperty("VAxes")] 
		ISet<IfcGrid> _PartOfV = new HashSet<IfcGrid>();
	
		[InverseProperty("UAxes")] 
		ISet<IfcGrid> _PartOfU = new HashSet<IfcGrid>();
	
		[InverseProperty("IntersectingAxes")] 
		ISet<IfcVirtualGridIntersection> _HasIntersections = new HashSet<IfcVirtualGridIntersection>();
	
	
		[Description("The tag or name for this grid axis.")]
		public IfcLabel? AxisTag { get { return this._AxisTag; } set { this._AxisTag = value;} }
	
		[Description("Underlying curve which provides the geometry for this grid axis.")]
		public IfcCurve AxisCurve { get { return this._AxisCurve; } set { this._AxisCurve = value;} }
	
		[Description("Defines whether the original sense of curve is used or whether it is reversed in " +
	    "the context of the grid axis.")]
		public IfcBoolean SameSense { get { return this._SameSense; } set { this._SameSense = value;} }
	
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>WAxes</em> of <em>IfcGri" +
	    "d</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attri" +
	    "bute.</blockquote>")]
		public ISet<IfcGrid> PartOfW { get { return this._PartOfW; } }
	
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>VAxes</em> of <em>IfcGri" +
	    "d</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attri" +
	    "bute.</blockquote>")]
		public ISet<IfcGrid> PartOfV { get { return this._PartOfV; } }
	
		[Description("If provided, the <em>IfcGridAxis</em> is part of the <em>UAxes</em> of <em>IfcGri" +
	    "d</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New inverse attri" +
	    "bute.</blockquote>")]
		public ISet<IfcGrid> PartOfU { get { return this._PartOfU; } }
	
		[Description("The reference to a set of <IfcVirtualGridIntersection</em>\'s, that connect other " +
	    "grid axes to this grid axis.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nb" +
	    "sp; New inverse attribute.</blockquote>")]
		public ISet<IfcVirtualGridIntersection> HasIntersections { get { return this._HasIntersections; } }
	
	
	}
	
}
