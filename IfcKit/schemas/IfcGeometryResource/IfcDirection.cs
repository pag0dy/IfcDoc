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
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcDirection : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcGridPlacementDirectionSelect,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The components in the direction of X axis (DirectionRatios[1]), of Y axis (DirectionRatios[2]), and of Z axis (DirectionRatios[3])   ")]
		[Required()]
		[MinLength(2)]
		[MaxLength(3)]
		public IList<IfcReal> DirectionRatios { get; protected set; }
	
	
		public IfcDirection(IfcReal[] __DirectionRatios)
		{
			this.DirectionRatios = new List<IfcReal>(__DirectionRatios);
		}
	
		public IfcDirection(Double x, Double y) : this(new IfcReal[]{ new IfcReal(x), new IfcReal(y)})
		{
		}
	
		public IfcDirection(Double x, Double y, Double z) : this(new IfcReal[]{ new IfcReal(x), new IfcReal(y), new IfcReal(z)})
		{
		}
	
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
