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

using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("c9a6fe1f-b072-45ab-ba40-8c1f8c01e132")]
	public partial class IfcDirection : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcGridPlacementDirectionSelect,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		[MinLength(2)]
		[MaxLength(3)]
		IList<IfcReal> _DirectionRatios = new List<IfcReal>();
	
	
		public IfcDirection()
		{
		}
	
		public IfcDirection(IfcReal[] __DirectionRatios)
		{
			this._DirectionRatios = new List<IfcReal>(__DirectionRatios);
		}
	
		public IfcDirection(Double x, Double y) : this(new IfcReal[]{ new IfcReal(x), new IfcReal(y)})
		{
		}
	
		public IfcDirection(Double x, Double y, Double z) : this(new IfcReal[]{ new IfcReal(x), new IfcReal(y), new IfcReal(z)})
		{
		}
	
	
		[Description("The components in the direction of X axis (DirectionRatios[1]), of Y axis (Direct" +
	    "ionRatios[2]), and of Z axis (DirectionRatios[3]) \r\n")]
		public IList<IfcReal> DirectionRatios { get { return this._DirectionRatios; } }
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
