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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcCartesianPoint : IfcPoint,
		BuildingSmart.IFC.IfcGeometryResource.IfcTrimmingSelect
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The first, second, and third coordinate of the point location. If placed in a two or three dimensional rectangular Cartesian coordinate system, Coordinates[1] is the X coordinate, Coordinates[2] is the Y coordinate, and Coordinates[3] is the Z coordinate.  ")]
		[Required()]
		[MinLength(1)]
		[MaxLength(3)]
		public IList<IfcLengthMeasure> Coordinates { get; protected set; }
	
	
		public IfcCartesianPoint(IfcLengthMeasure[] __Coordinates)
		{
			this.Coordinates = new List<IfcLengthMeasure>(__Coordinates);
		}
	
		public IfcCartesianPoint(Double x, Double y) : this(new IfcLengthMeasure[]{ new IfcLengthMeasure(x), new IfcLengthMeasure(y)})
		{
		}
	
		public IfcCartesianPoint(Double x, Double y, Double z) : this(new IfcLengthMeasure[]{ new IfcLengthMeasure(x), new IfcLengthMeasure(y), new IfcLengthMeasure(z)})
		{
		}
	
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
