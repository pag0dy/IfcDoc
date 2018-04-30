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
	public partial class IfcEdge : IfcTopologicalRepresentationItem
	{
		[DataMember(Order = 0)] 
		[XmlElement]
		[Description("Start point (vertex) of the edge.  ")]
		[Required()]
		public IfcVertex EdgeStart { get; set; }
	
		[DataMember(Order = 1)] 
		[XmlElement]
		[Description("End point (vertex) of the edge. The same vertex can be used for both EdgeStart and EdgeEnd.  ")]
		[Required()]
		public IfcVertex EdgeEnd { get; set; }
	
	
		public IfcEdge(IfcVertex __EdgeStart, IfcVertex __EdgeEnd)
		{
			this.EdgeStart = __EdgeStart;
			this.EdgeEnd = __EdgeEnd;
		}
	
	
	}
	
}
