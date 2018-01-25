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
using BuildingSmart.IFC.IfcGeometricModelResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationDefinitionResource;
using BuildingSmart.IFC.IfcTopologyResource;

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("bcd71dc5-c1c1-46c9-8dcf-2d9155a3edff")]
	public abstract partial class IfcTextureCoordinate : IfcPresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		IList<IfcSurfaceTexture> _Maps = new List<IfcSurfaceTexture>();
	
	
		[Description("Reference to the one (or many in case of multi textures with identity transformat" +
	    "ion to geometric surfaces) subtype(s) of <em>IfcSurfaceTexture</em> that are map" +
	    "ped to a geometric surface by the texture coordinate transformation.")]
		public IList<IfcSurfaceTexture> Maps { get { return this._Maps; } }
	
	
	}
	
}
