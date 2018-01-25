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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("33f5691b-7957-46f4-a44c-3b5069f82548")]
	public partial class IfcFaceSurface : IfcFace,
		BuildingSmart.IFC.IfcGeometricConstraintResource.IfcSurfaceOrFaceSurface
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSurface _FaceSurface;
	
		[DataMember(Order=1)] 
		[Required()]
		Boolean _SameSense;
	
	
		[Description("The surface which defines the internal shape of the face. This surface may be unb" +
	    "ounded. The domain of the face is defined by this surface and the bounding loops" +
	    " in the inherited attribute SELF\\FaceBounds.")]
		public IfcSurface FaceSurface { get { return this._FaceSurface; } set { this._FaceSurface = value;} }
	
		[Description("This flag indicates whether the sense of the surface normal agrees with (TRUE), o" +
	    "r opposes (FALSE), the sense of the topological normal to the face.")]
		public Boolean SameSense { get { return this._SameSense; } set { this._SameSense = value;} }
	
	
	}
	
}
