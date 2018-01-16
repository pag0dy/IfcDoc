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
	[Guid("8af578ab-a0d2-4d1e-b725-2f0d1ac24326")]
	public partial class IfcBSplineSurfaceWithKnots : IfcBSplineSurface
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _UMultiplicities = new List<IfcInteger>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _VMultiplicities = new List<IfcInteger>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _UKnots = new List<IfcParameterValue>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _VKnots = new List<IfcParameterValue>();
	
		[DataMember(Order=4)] 
		[XmlAttribute]
		[Required()]
		IfcKnotType _KnotSpec;
	
	
		[Description("The multiplicities of the knots in the <em>u</em> parameter direction.")]
		public IList<IfcInteger> UMultiplicities { get { return this._UMultiplicities; } }
	
		[Description("The multiplicities of the knots in the <em>v</em> parameter direction.")]
		public IList<IfcInteger> VMultiplicities { get { return this._VMultiplicities; } }
	
		[Description("The list of the distinct knots in the <em>u</em> parameter direction.")]
		public IList<IfcParameterValue> UKnots { get { return this._UKnots; } }
	
		[Description("The list of the distinct knots in the <em>v</em> parameter direction.")]
		public IList<IfcParameterValue> VKnots { get { return this._VKnots; } }
	
		[Description("The description of the knot type.")]
		public IfcKnotType KnotSpec { get { return this._KnotSpec; } set { this._KnotSpec = value;} }
	
		public new IfcInteger KnotVUpper { get { return new IfcInteger(); } }
	
		public new IfcInteger KnotUUpper { get { return new IfcInteger(); } }
	
	
	}
	
}
