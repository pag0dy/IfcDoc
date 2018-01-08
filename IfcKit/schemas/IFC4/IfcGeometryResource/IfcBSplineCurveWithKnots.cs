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
		[Required()]
		IList<Int64> _KnotMultiplicities = new List<Int64>();
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		[Required()]
		IList<IfcParameterValue> _Knots = new List<IfcParameterValue>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcKnotType _KnotSpec;
	
	
		[Description("<EPM-HTML>\r\nThe multiplicities of the knots. This list defines the number of time" +
	    "s each knot in the knots list is to be repeated in constructing the knot array.\r" +
	    "\n</EPM-HTML>")]
		public IList<Int64> KnotMultiplicities { get { return this._KnotMultiplicities; } }
	
		[Description("<EPM-HTML>\r\nThe list of distinct knots used to define the B-spline basis function" +
	    "s.\r\n</EPM-HTML>")]
		public IList<IfcParameterValue> Knots { get { return this._Knots; } }
	
		[Description("<EPM-HTML>\r\nThe description of the knot type. This is for information only.\r\n</EP" +
	    "M-HTML>")]
		public IfcKnotType KnotSpec { get { return this._KnotSpec; } set { this._KnotSpec = value;} }
	
	
	}
	
}
