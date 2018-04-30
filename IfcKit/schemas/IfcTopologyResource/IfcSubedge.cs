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

using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcPresentationOrganizationResource;

namespace BuildingSmart.IFC.IfcTopologyResource
{
	public partial class IfcSubedge : IfcEdge
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("The Edge, or Subedge, which contains the Subedge.")]
		[Required()]
		public IfcEdge ParentEdge { get; set; }
	
	
		public IfcSubedge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd, IfcEdge __ParentEdge)
			: base(__EdgeStart, __EdgeEnd)
		{
			this.ParentEdge = __ParentEdge;
		}
	
	
	}
	
}
