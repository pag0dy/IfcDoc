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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("a7b35010-4a44-4a36-bb3c-6aa6300f33bf")]
	public partial class IfcCartesianPoint : IfcPoint,
		BuildingSmart.IFC.IfcGeometryResource.IfcTrimmingSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcLengthMeasure> _Coordinates = new List<IfcLengthMeasure>();
	
	
		[Description(@"The first, second, and third coordinate of the point location. If placed in a two or three dimensional rectangular Cartesian coordinate system, Coordinates[1] is the X coordinate, Coordinates[2] is the Y coordinate, and Coordinates[3] is the Z coordinate.
	")]
		public IList<IfcLengthMeasure> Coordinates { get { return this._Coordinates; } }
	
	
	}
	
}
