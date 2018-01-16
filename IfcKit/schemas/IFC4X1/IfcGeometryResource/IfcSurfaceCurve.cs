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
	[Guid("2a55825b-2385-4b12-bba1-1672cb441a35")]
	public partial class IfcSurfaceCurve : IfcCurve,
		BuildingSmart.IFC.IfcGeometryResource.IfcCurveOnSurface
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcCurve _Curve3D;
	
		[DataMember(Order=1)] 
		[Required()]
		IList<IfcPcurve> _AssociatedGeometry = new List<IfcPcurve>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcPreferredSurfaceCurveRepresentation _MasterRepresentation;
	
	
		[Description("The curve which is the three-dimensional representation of the surface curve.")]
		public IfcCurve Curve3D { get { return this._Curve3D; } set { this._Curve3D = value;} }
	
		[Description(@"A list of one or two pcurves which define the surface or surfaces associated with the surface curve. Two elements in this list indicate that the curve has two surface associations which need not be two distinct surfaces. Being a pcurve, it also associates a basis curve in the parameter space of this surface as an alternative representation of the surface curve.")]
		public IList<IfcPcurve> AssociatedGeometry { get { return this._AssociatedGeometry; } }
	
		[Description(@"The <em<MasterRepresentation</em> defines the curve used to determine the unique parametrisation of the <em>IfcSurfaceCurve</em>.<br> 
	The master_representation takes one of the values <em>Curve3D</em>, <em>PCurve_S1</em> or <em>PCurve_S2</em> to indicate a preference for the 3D curve, or the first or second pcurve, in the associated geometry list, respectively. Multiple representations provide the ability to communicate data in more than one form, even though the data is expected to be geometrically identical.<br><br>
	NOTE&nbsp; The master representation attribute acknowledges the impracticality of ensuring that multiple forms are indeed identical and allows the indication of a preferred form. This would probably be determined by the creator of the data. All characteristics, such as parametrisation, domain, and results of evaluation, for an entity having multiple representations, are derived from the master representation. Any use of the other representations is a compromise for practical considerations. ")]
		public IfcPreferredSurfaceCurveRepresentation MasterRepresentation { get { return this._MasterRepresentation; } set { this._MasterRepresentation = value;} }
	
		public new ISet<IfcSurface> BasisSurface { get { return null; } }
	
	
	}
	
}
