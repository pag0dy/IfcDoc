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

using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;
using BuildingSmart.IFC.IfcStructuralAnalysisDomain;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcDirection : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcStructuralAnalysisDomain.IfcOrientationSelect,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order = 0)] 
		[Description("The components in the direction of X axis (DirectionRatios[1]), of Y axis (DirectionRatios[2]), and of Z axis (DirectionRatios[3])   ")]
		[Required()]
		[MinLength(2)]
		[MaxLength(3)]
		public IList<Double> DirectionRatios { get; protected set; }
	
	
		public IfcDirection(Double[] __DirectionRatios)
		{
			this.DirectionRatios = new List<Double>(__DirectionRatios);
		}
	
		public new IfcDimensionCount Dim { get { return new IfcDimensionCount(); } }
	
	
	}
	
}
