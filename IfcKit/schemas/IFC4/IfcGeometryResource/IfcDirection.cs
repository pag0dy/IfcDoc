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
	[Guid("c9a6fe1f-b072-45ab-ba40-8c1f8c01e132")]
	public partial class IfcDirection : IfcGeometricRepresentationItem,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcGridPlacementDirectionSelect,
		BuildingSmart.IFC.IfcGeometryResource.IfcVectorOrDirection
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<Double> _DirectionRatios = new List<Double>();
	
	
		[Description("The components in the direction of X axis (DirectionRatios[1]), of Y axis (Direct" +
	    "ionRatios[2]), and of Z axis (DirectionRatios[3]) \r\n")]
		public IList<Double> DirectionRatios { get { return this._DirectionRatios; } }
	
	
	}
	
}
