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

using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationResource;
using BuildingSmart.IFC.IfcRepresentationResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationDefinitionResource
{
	[Guid("b2cdbd80-cb69-4247-ac58-2a3ef452036e")]
	public abstract partial class IfcTextureCoordinate
	{
		[InverseProperty("TextureCoordinates")] 
		ISet<IfcAnnotationSurface> _AnnotatedSurface = new HashSet<IfcAnnotationSurface>();
	
	
		public ISet<IfcAnnotationSurface> AnnotatedSurface { get { return this._AnnotatedSurface; } }
	
	
	}
	
}
