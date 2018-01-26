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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	[Guid("fa4d0f85-ebcc-4a94-aa4d-e9876009463c")]
	public partial class IfcRationalBSplineSurfaceWithKnots : IfcBSplineSurfaceWithKnots
	{
		[DataMember(Order=0)] 
		[XmlElement("IfcReal")]
		[Required()]
		[MinLength(2)]
		IList<IfcReal> _WeightsData = new List<IfcReal>();
	
	
		public IfcRationalBSplineSurfaceWithKnots()
		{
		}
	
		public IfcRationalBSplineSurfaceWithKnots(IfcInteger __UDegree, IfcInteger __VDegree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineSurfaceForm __SurfaceForm, IfcLogical __UClosed, IfcLogical __VClosed, IfcLogical __SelfIntersect, IfcInteger[] __UMultiplicities, IfcInteger[] __VMultiplicities, IfcParameterValue[] __UKnots, IfcParameterValue[] __VKnots, IfcKnotType __KnotSpec, IfcReal[] __WeightsData)
			: base(__UDegree, __VDegree, __ControlPointsList, __SurfaceForm, __UClosed, __VClosed, __SelfIntersect, __UMultiplicities, __VMultiplicities, __UKnots, __VKnots, __KnotSpec)
		{
			this._WeightsData = new List<IfcReal>(__WeightsData);
		}
	
		[Description("The weights associated with the control points in the rational case.")]
		public IList<IfcReal> WeightsData { get { return this._WeightsData; } }
	
		public new IfcReal Weights { get { return new IfcReal(); } }
	
	
	}
	
}
