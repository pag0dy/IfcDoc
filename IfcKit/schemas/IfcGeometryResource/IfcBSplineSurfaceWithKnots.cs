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
	public partial class IfcBSplineSurfaceWithKnots : IfcBSplineSurface
	{
		[DataMember(Order = 0)] 
		[XmlAttribute]
		[Description("The multiplicities of the knots in the <em>u</em> parameter direction.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcInteger> UMultiplicities { get; protected set; }
	
		[DataMember(Order = 1)] 
		[XmlAttribute]
		[Description("The multiplicities of the knots in the <em>v</em> parameter direction.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcInteger> VMultiplicities { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The list of the distinct knots in the <em>u</em> parameter direction.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcParameterValue> UKnots { get; protected set; }
	
		[DataMember(Order = 3)] 
		[XmlAttribute]
		[Description("The list of the distinct knots in the <em>v</em> parameter direction.")]
		[Required()]
		[MinLength(2)]
		public IList<IfcParameterValue> VKnots { get; protected set; }
	
		[DataMember(Order = 4)] 
		[XmlAttribute]
		[Description("The description of the knot type.")]
		[Required()]
		public IfcKnotType KnotSpec { get; set; }
	
	
		public IfcBSplineSurfaceWithKnots(IfcInteger __UDegree, IfcInteger __VDegree, IfcCartesianPoint[] __ControlPointsList, IfcBSplineSurfaceForm __SurfaceForm, IfcLogical __UClosed, IfcLogical __VClosed, IfcLogical __SelfIntersect, IfcInteger[] __UMultiplicities, IfcInteger[] __VMultiplicities, IfcParameterValue[] __UKnots, IfcParameterValue[] __VKnots, IfcKnotType __KnotSpec)
			: base(__UDegree, __VDegree, __ControlPointsList, __SurfaceForm, __UClosed, __VClosed, __SelfIntersect)
		{
			this.UMultiplicities = new List<IfcInteger>(__UMultiplicities);
			this.VMultiplicities = new List<IfcInteger>(__VMultiplicities);
			this.UKnots = new List<IfcParameterValue>(__UKnots);
			this.VKnots = new List<IfcParameterValue>(__VKnots);
			this.KnotSpec = __KnotSpec;
		}
	
		public new IfcInteger KnotVUpper { get { return new IfcInteger(); } }
	
		public new IfcInteger KnotUUpper { get { return new IfcInteger(); } }
	
	
	}
	
}
