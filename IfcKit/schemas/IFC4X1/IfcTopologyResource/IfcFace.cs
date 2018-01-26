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
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	[Guid("30261543-34bc-4fcc-bd68-c6643fc090c9")]
	public partial class IfcFace : IfcTopologicalRepresentationItem
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcFaceBound> _Bounds = new HashSet<IfcFaceBound>();
	
		[InverseProperty("MappedTo")] 
		ISet<IfcTextureMap> _HasTextureMaps = new HashSet<IfcTextureMap>();
	
	
		public IfcFace()
		{
		}
	
		public IfcFace(IfcFaceBound[] __Bounds)
		{
			this._Bounds = new HashSet<IfcFaceBound>(__Bounds);
		}
	
		[Description("Boundaries of the face.\r\n")]
		public ISet<IfcFaceBound> Bounds { get { return this._Bounds; } }
	
		public ISet<IfcTextureMap> HasTextureMaps { get { return this._HasTextureMaps; } }
	
	
	}
	
}
