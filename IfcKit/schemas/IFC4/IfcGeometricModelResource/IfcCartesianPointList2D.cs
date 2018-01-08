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
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometricModelResource
{
	[Guid("14ee71bc-ac06-4564-9ce3-0b8651e89195")]
	public partial class IfcCartesianPointList2D : IfcCartesianPointList
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcLengthMeasure> _CoordList = new List<IfcLengthMeasure>();
	
	
		[Description("Two-dimensional list of Cartesian points provided by two coordinates.")]
		public IList<IfcLengthMeasure> CoordList { get { return this._CoordList; } }
	
	
	}
	
}
