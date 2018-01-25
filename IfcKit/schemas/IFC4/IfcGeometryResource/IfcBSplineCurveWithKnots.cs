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
	[Guid("5cf374d3-9550-4d89-8870-9e50d9d4d7f6")]
	public partial class IfcBSplineCurveWithKnots : IfcBSplineCurve
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IList<IfcInteger> _KnotMultiplicities = new List<IfcInteger>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _Knots = new List<IfcParameterValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcKnotType _KnotSpec;
	
	
		[Description("The multiplicities of the knots. This list defines the number of times each knot " +
	    "in the knots list is to be repeated in constructing the knot array.")]
		public IList<IfcInteger> KnotMultiplicities { get { return this._KnotMultiplicities; } }
	
		[Description("The list of distinct knots used to define the B-spline basis functions.")]
		public IList<IfcParameterValue> Knots { get { return this._Knots; } }
	
		[Description("The description of the knot type. This is for information only.")]
		public IfcKnotType KnotSpec { get { return this._KnotSpec; } set { this._KnotSpec = value;} }
	
	
	}
	
}
