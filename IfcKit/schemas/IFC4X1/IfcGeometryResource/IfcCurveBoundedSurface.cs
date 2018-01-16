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
	[Guid("8606dc84-8a2a-415b-8415-b98039c064b8")]
	public partial class IfcCurveBoundedSurface : IfcBoundedSurface
	{
		[DataMember(Order=0)] 
		[XmlElement]
		[Required()]
		IfcSurface _BasisSurface;
	
		[DataMember(Order=1)] 
		[Required()]
		ISet<IfcBoundaryCurve> _Boundaries = new HashSet<IfcBoundaryCurve>();
	
		[DataMember(Order=2)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _ImplicitOuter;
	
	
		[Description("The surface to be bounded.")]
		public IfcSurface BasisSurface { get { return this._BasisSurface; } set { this._BasisSurface = value;} }
	
		[Description("The outer boundary of the surface.")]
		public ISet<IfcBoundaryCurve> Boundaries { get { return this._Boundaries; } }
	
		public IfcBoolean ImplicitOuter { get { return this._ImplicitOuter; } set { this._ImplicitOuter = value;} }
	
	
	}
	
}
