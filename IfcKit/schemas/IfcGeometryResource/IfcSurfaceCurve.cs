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

using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcGeometryResource
{
	public partial class IfcSurfaceCurve : IfcCurve,
		BuildingSmart.IFC.IfcGeometryResource.IfcCurveOnSurface
	{
		[DataMember(Order = 0)] 
		[Description("The curve which is the three-dimensional representation of the surface curve.")]
		[Required()]
		public IfcCurve Curve3D { get; set; }
	
		[DataMember(Order = 1)] 
		[Description("A list of one or two pcurves which define the surface or surfaces associated with the surface curve. Two elements in this list indicate that the curve has two surface associations which need not be two distinct surfaces. Being a pcurve, it also associates a basis curve in the parameter space of this surface as an alternative representation of the surface curve.")]
		[Required()]
		[MinLength(1)]
		[MaxLength(2)]
		public IList<IfcPcurve> AssociatedGeometry { get; protected set; }
	
		[DataMember(Order = 2)] 
		[XmlAttribute]
		[Description("The <em<MasterRepresentation</em> defines the curve used to determine the unique parametrisation of the <em>IfcSurfaceCurve</em>.<br>   The master_representation takes one of the values <em>Curve3D</em>, <em>PCurve_S1</em> or <em>PCurve_S2</em> to indicate a preference for the 3D curve, or the first or second pcurve, in the associated geometry list, respectively. Multiple representations provide the ability to communicate data in more than one form, even though the data is expected to be geometrically identical.<br><br>  NOTE&nbsp; The master representation attribute acknowledges the impracticality of ensuring that multiple forms are indeed identical and allows the indication of a preferred form. This would probably be determined by the creator of the data. All characteristics, such as parametrisation, domain, and results of evaluation, for an entity having multiple representations, are derived from the master representation. Any use of the other representations is a compromise for practical considerations. ")]
		[Required()]
		public IfcPreferredSurfaceCurveRepresentation MasterRepresentation { get; set; }
	
	
		public IfcSurfaceCurve(IfcCurve __Curve3D, IfcPcurve[] __AssociatedGeometry, IfcPreferredSurfaceCurveRepresentation __MasterRepresentation)
		{
			this.Curve3D = __Curve3D;
			this.AssociatedGeometry = new List<IfcPcurve>(__AssociatedGeometry);
			this.MasterRepresentation = __MasterRepresentation;
		}
	
		public new ISet<IfcSurface> BasisSurface { get { return null; } }
	
	
	}
	
}
