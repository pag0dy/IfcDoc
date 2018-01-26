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

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("18fe3405-d1b4-4632-b93d-b36e1cdf00c1")]
	public partial class IfcCartesianPointList3D : IfcCartesianPointList
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		IList<IfcLengthMeasure> _CoordList = new List<IfcLengthMeasure>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[MinLength(1)]
		IList<IfcLabel> _TagList = new List<IfcLabel>();
	
	
		public IfcCartesianPointList3D()
		{
		}
	
		public IfcCartesianPointList3D(IfcLengthMeasure[] __CoordList, IfcLabel[] __TagList)
		{
			this._CoordList = new List<IfcLengthMeasure>(__CoordList);
			this._TagList = new List<IfcLabel>(__TagList);
		}
	
		[Description("Two-dimensional list of Cartesian points provided by three coordinates.")]
		public IList<IfcLengthMeasure> CoordList { get { return this._CoordList; } }
	
		[Description("List of tags corresponding to each point that may be used to identify a basis cur" +
	    "ve according to the Tag attribute at <i>IfcOffsetCurveByDistances</i> or <i>IfcA" +
	    "lignmentCurve</i>.")]
		public IList<IfcLabel> TagList { get { return this._TagList; } }
	
	
	}
	
}
