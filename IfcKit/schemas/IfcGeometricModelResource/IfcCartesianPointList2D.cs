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

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	public partial class IfcCartesianPointList2D : IfcCartesianPointList
	{
		[DataMember(Order = 0)] 
		[Description("Two-dimensional list of Cartesian points provided by two coordinates.")]
		[Required()]
		[MinLength(1)]
		public IList<IfcLengthMeasure> CoordList { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("List of tags corresponding to each point that may be used to identify a basis curve according to the Tag attribute at <i>IfcOffsetCurveByDistances</i> or <i>IfcAlignmentCurve</i>.")]
		[MinLength(1)]
		public IList<IfcLabel> TagList { get; protected set; }
	
	
		public IfcCartesianPointList2D(IfcLengthMeasure[] __CoordList, IfcLabel[] __TagList)
		{
			this.CoordList = new List<IfcLengthMeasure>(__CoordList);
			this.TagList = new List<IfcLabel>(__TagList);
		}
	
	
	}
	
}
