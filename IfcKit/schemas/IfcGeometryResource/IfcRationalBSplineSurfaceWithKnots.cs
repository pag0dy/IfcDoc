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
	public partial class IfcRationalBSplineSurfaceWithKnots : IfcBSplineSurfaceWithKnots
	{
		[DataMember(Order = 0)] 
		[XmlElement("IfcReal")]
		[Description("The weights associated with the control points in the rational case.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcReal> WeightsData { get; protected set; }
	
	
		public IfcRationalBSplineSurfaceWithKnots(IfcInteger __UDegree, IfcInteger __VDegree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineSurfaceForm __SurfaceForm, IfcLogical __UClosed, IfcLogical __VClosed, IfcLogical __SelfIntersect, IfcInteger[] __UMultiplicities, IfcInteger[] __VMultiplicities, IfcParameterValue[] __UKnots, IfcParameterValue[] __VKnots, IfcKnotType __KnotSpec, IfcReal[] __WeightsData)
			: base(__UDegree, __VDegree, __ControlPointsList, __SurfaceForm, __UClosed, __VClosed, __SelfIntersect, __UMultiplicities, __VMultiplicities, __UKnots, __VKnots, __KnotSpec)
		{
			this.WeightsData = new List<IfcReal>(__WeightsData);
		}
	
		public new IfcReal Weights { get { return new IfcReal(); } }
	
	
	}
	
}
