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
	[Guid("7b2e30ff-3e94-443a-9e20-2fbf226ef0ce")]
	public partial class IfcTextureMap : IfcTextureCoordinate
	{
		[DataMember(Order=0)] 
		[Required()]
		ISet<IfcVertexBasedTextureMap> _TextureMaps = new HashSet<IfcVertexBasedTextureMap>();
	
	
		[Description("Reference to a list of texture vertex assignment to coordinates within a vertex b" +
	    "ased geometry.")]
		public ISet<IfcVertexBasedTextureMap> TextureMaps { get { return this._TextureMaps; } }
	
	
	}
	
}
