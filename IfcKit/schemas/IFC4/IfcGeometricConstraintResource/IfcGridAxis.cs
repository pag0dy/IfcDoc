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
		[XmlElement("IfcCurve")]
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
	
		[Description("<EPM-HTML>\r\nIf provided, the <em>IfcGridAxis</em> is part of the <em>WAxes</em> o" +
	    "f <em>IfcGrid</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New i" +
	    "nverse attribute.</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfW { get { return this._PartOfW; } }
	
		[Description("<EPM-HTML>\r\nIf provided, the <em>IfcGridAxis</em> is part of the <em>VAxes</em> o" +
	    "f <em>IfcGrid</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New i" +
	    "nverse attribute.</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfV { get { return this._PartOfV; } }
	
		[Description("<EPM-HTML>\r\nIf provided, the <em>IfcGridAxis</em> is part of the <em>UAxes</em> o" +
	    "f <em>IfcGrid</em>.\r\n<blockquote class=\"change-ifc2x3\">IFC2x3 CHANGE&nbsp; New i" +
	    "nverse attribute.</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcGrid> PartOfU { get { return this._PartOfU; } }
	
		[Description("<EPM-HTML>\r\nThe reference to a set of <IfcVirtualGridIntersection</em>\'s, that co" +
	    "nnect other grid axes to this grid axis.\r\n<blockquote class=\"change-ifc2x3\">IFC2" +
	    "x3 CHANGE&nbsp; New inverse attribute.</blockquote>\r\n</EPM-HTML>")]
		public ISet<IfcVirtualGridIntersection> HasIntersections { get { return this._HasIntersections; } }
	
	
	}
	
}
