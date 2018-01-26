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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("ed00857d-0af6-48ff-a71e-f00c81e1589d")]
	public partial class IfcVirtualGridIntersection
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(2)]
		[MaxLength(2)]
		IList<IfcGridAxis> _IntersectingAxes = new List<IfcGridAxis>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		[MaxLength(3)]
		IList<IfcLengthMeasure> _OffsetDistances = new List<IfcLengthMeasure>();
	
	
		public IfcVirtualGridIntersection()
		{
		}
	
		public IfcVirtualGridIntersection(IfcGridAxis[] __IntersectingAxes, IfcLengthMeasure[] __OffsetDistances)
		{
			this._IntersectingAxes = new List<IfcGridAxis>(__IntersectingAxes);
			this._OffsetDistances = new List<IfcLengthMeasure>(__OffsetDistances);
		}
	
		[Description(@"Two grid axes which intersects at exactly one intersection (see also informal proposition at IfcGrid). If attribute OffsetDistances is omitted, the intersection defines the placement or ref direction of a grid placement directly. If OffsetDistances are given, the intersection is defined by the offset curves to the grid axes.")]
		public IList<IfcGridAxis> IntersectingAxes { get { return this._IntersectingAxes; } }
	
		[Description("Offset distances to the grid axes. If given, it defines virtual offset curves to " +
	    "the grid axes. The intersection of the offset curves specify the virtual grid in" +
	    "tersection.\r\n")]
		public IList<IfcLengthMeasure> OffsetDistances { get { return this._OffsetDistances; } }
	
	
	}
	
}
