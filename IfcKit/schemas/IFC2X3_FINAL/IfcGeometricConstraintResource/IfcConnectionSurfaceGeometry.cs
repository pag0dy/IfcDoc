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


namespace BuildingSmart.IFC.IfcGeometricConstraintResource
{
	[Guid("7a36837d-1de2-43a5-86b8-821bd21acb1b")]
	public partial class IfcConnectionSurfaceGeometry : IfcConnectionGeometry
	{
		[DataMember(Order=0)] 
		[Required()]
		IfcSurfaceOrFaceSurface _SurfaceOnRelatingElement;
	
		[DataMember(Order=1)] 
		IfcSurfaceOrFaceSurface _SurfaceOnRelatedElement;
	
	
		public IfcConnectionSurfaceGeometry()
		{
		}
	
		public IfcConnectionSurfaceGeometry(IfcSurfaceOrFaceSurface __SurfaceOnRelatingElement, IfcSurfaceOrFaceSurface __SurfaceOnRelatedElement)
		{
			this._SurfaceOnRelatingElement = __SurfaceOnRelatingElement;
			this._SurfaceOnRelatedElement = __SurfaceOnRelatedElement;
		}
	
		[Description("Surface at which related object is aligned at the relating element, given in the " +
	    "LCS of the relating element.")]
		public IfcSurfaceOrFaceSurface SurfaceOnRelatingElement { get { return this._SurfaceOnRelatingElement; } set { this._SurfaceOnRelatingElement = value;} }
	
		[Description("Surface at which the relating element is aligned at the related element, given in" +
	    " the LCS of the related element. If the information is omitted, then the origin " +
	    "of the related element is used.\r\n")]
		public IfcSurfaceOrFaceSurface SurfaceOnRelatedElement { get { return this._SurfaceOnRelatedElement; } set { this._SurfaceOnRelatedElement = value;} }
	
	
	}
	
}
