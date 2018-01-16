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
	[Guid("1038acc6-27c4-461c-b25e-99db38043735")]
	public partial class IfcGridAxis
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _AxisTag;
	
		[DataMember(Order=1)] 
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
	
		[Description("<EPM-HTML>\r\nIf provided, the <i>IfcGridAxis</i> is part of the <i>WAxes</i> of <i" +
	    ">IfcGrid</i>.\r\n<blockquote><small>\r\n  <font color=\"#FF0000\">IFC2x Edition 3 CHAN" +
	    "GE&nbsp; New inverse attribute.</font>\r\n</small></blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfW { get { return this._PartOfW; } }
	
		[Description("<EPM-HTML>\r\nIf provided, the <i>IfcGridAxis</i> is part of the <i>VAxes</i> of <i" +
	    ">IfcGrid</i>.\r\n<blockquote><small>\r\n  <font color=\"#FF0000\">IFC2x Edition 3 CHAN" +
	    "GE&nbsp; New inverse attribute.</font>\r\n</small></blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfV { get { return this._PartOfV; } }
	
		[Description("<EPM-HTML>\r\nIf provided, the <i>IfcGridAxis</i> is part of the <i>UAxes</i> of <i" +
	    ">IfcGrid</i>.\r\n<blockquote><small>\r\n  <font color=\"#FF0000\">IFC2x Edition 3 CHAN" +
	    "GE&nbsp; New inverse attribute.</font>\r\n</small></blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfU { get { return this._PartOfU; } }
	
		[Description("<EPM-HTML>\r\nThe reference to a set of <IfcVirtualGridIntersection</i>\'s, that con" +
	    "nect other grid axes to this grid axis.\r\n<blockquote><small>\r\n  <font color=\"#FF" +
	    "0000\">IFC2x3 CHANGE&nbsp; New inverse attribute.</font>\r\n</small></blockquote>\r\n" +
	    "</EPM-HTML>")]
		public ISet<IfcVirtualGridIntersection> HasIntersections { get { return this._HasIntersections; } }
	
	
	}
	
}
